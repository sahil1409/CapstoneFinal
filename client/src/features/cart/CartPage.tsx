import { Add, Delete, Remove } from "@mui/icons-material";
import { Button, Divider, Grid, IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import agent from "../../agent";
import { useStoreContext } from "../../Context";

export default function BasketPage() {

    const { cart, setCart, removeItem } = useStoreContext();

    function addQuantity(medicineId: number) {
        agent.Cart.addItem(medicineId)
            .then(cart => setCart(cart))
            .catch(error => console.log(error));
    }

    function reduceQuantity(medicineId: number, quantity = 1) {
        agent.Cart.removeItem(medicineId, quantity)
            .then(() => removeItem(medicineId, quantity))
            .catch(error => console.log(error));
    }

    const total = cart?.items.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;

    if (!cart) return <Typography variant='h3'>Your cart is empty</Typography>

    return (
        <>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell align="center">Medicine</TableCell>
                            <TableCell align="center">Price</TableCell>
                            <TableCell align="center">Quantity</TableCell>
                            <TableCell align="center">Subtotal</TableCell>
                            <TableCell align="center"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {cart.items.map(item => (
                            <TableRow
                                key={item.medicineId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell align="center" component="th" scope="row">
                                    {item.name}
                                </TableCell>
                                <TableCell align="center">₹{item.price}</TableCell>
                                <TableCell align="center">
                                    {item.quantity}
                                    <IconButton onClick={() => reduceQuantity(item.medicineId)} color='error'>
                                        <Remove />
                                    </IconButton>
                                    <IconButton onClick={() => addQuantity(item.medicineId)} sx={{ color: "green" }}>
                                        <Add />
                                    </IconButton>
                                </TableCell>
                                <TableCell align="center">₹{item.price * item.quantity}</TableCell>
                                <TableCell align="left">
                                    <IconButton onClick={() => reduceQuantity(item.medicineId, item.quantity)} color='error'>
                                        <Delete />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            <Divider />

            <Grid container>
                <Grid item xs={6} />
                <Grid item xs={6}>

                    <TableContainer component={Paper} variant={'outlined'}>
                        <Table>
                            <TableBody>
                                <TableRow>
                                    <TableCell colSpan={2}>Total</TableCell>
                                    <TableCell align="right">₹{total}</TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>

                    <Divider />

                    <Button component={Link} to='/checkout' variant='contained' size='large' fullWidth sx={{'&:hover': {color: '#b39ddb'}}}>
                        Checkout
                    </Button>

                </Grid>
            </Grid>
        </>
    )
}