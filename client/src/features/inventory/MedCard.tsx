import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import agent from "../../agent";
import { Medicine } from "../../models/medicine";
import { LoadingButton } from '@mui/lab';
import { useState } from "react";
import { useStoreContext } from "../../Context";

interface Props {
    medicine: Medicine;
}

export default function MedCard({ medicine }: Props) {

    const [loading, setLoading] = useState(false);
    const { setCart } = useStoreContext();

    function handleAddItem(medicineId: number) {
        setLoading(true);
        agent.Cart.addItem(medicineId)
            .then(cart => setCart(cart))
            .catch(error => console.log())
            .finally(() => setLoading(false));
    }

    return (
        <Card>
            <CardMedia
                sx={{ height: 180, backgroundSize: 'contain' }}
                image={medicine.image}
            />
            <CardContent sx={{ bgcolor: "#F1F1F1" }}>
                <Typography gutterBottom component="div">
                    <span style={{ fontSize: "25px", fontWeight: "bold" }}>{medicine.name}</span> <span style={{ float: "right", fontSize: "20px" }}>₹{medicine.price}</span>
                </Typography>
                <Typography variant="body2" color="text.secondary" align="justify">
                    {medicine.category}
                </Typography>
            </CardContent>
            <CardActions sx={{ bgcolor: "#F1F1F1" }}>
                <Button component={Link} to={`/inventory/${medicine.id}`} size="small">View</Button>
                <LoadingButton loading={loading} onClick={() => handleAddItem(medicine.id)} size="small">Add to cart</LoadingButton>
            </CardActions>
        </Card>

    )
}