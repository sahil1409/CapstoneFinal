import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import agent from "../../agent";
import { useStoreContext } from "../../Context";
import { Medicine } from "../../models/medicine";

export default function MedicineDetails() {

    const {id} = useParams<{id: string}>();
    const [medicine, setMedicine] = useState<Medicine | null>(null);

    const {cart} = useStoreContext();
    const item = cart?.items.find(i => i.medicineId === medicine?.id);
    
    useEffect(() => {
        agent.Inventory.details(parseInt(id!))
            .then(response => setMedicine(response))
            .catch(error => console.log(error));
    }, [id])

    if (!medicine) return <h3>Product not found!</h3>

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={medicine.image} alt={medicine.name} style={{width: '100%'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{medicine.name}</Typography>
                <Divider sx={{mb: 2}} />
                <Typography variant='h4' color='primary'>₹{medicine.price}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Name</TableCell>
                                <TableCell>{medicine.name}</TableCell>
                            </TableRow>    
                            <TableRow>
                                <TableCell>Description</TableCell>
                                <TableCell><Typography variant='inherit' align='justify'>{medicine.description}</Typography></TableCell>
                            </TableRow>  
                            <TableRow>
                                <TableCell>Category</TableCell>
                                <TableCell>{medicine.category}</TableCell>
                            </TableRow>  
                            <TableRow>
                                <TableCell>Seller Information</TableCell>
                                <TableCell>{medicine.seller}</TableCell>
                            </TableRow>  
                            <TableRow>
                                <TableCell>Quantity</TableCell>
                                <TableCell>{medicine.quantity} Tablets</TableCell>
                            </TableRow>  
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>
        </Grid>    
    )
}