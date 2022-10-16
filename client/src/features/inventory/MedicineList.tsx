import { Grid } from "@mui/material";
import { Medicine } from "../../models/medicine";
import MedCard from "./MedCard";

interface Props {
    medicines: Medicine[];
}

export default function MedicineList({medicines}: Props) {
    return (
        <Grid container spacing={4}>
            {medicines.map(medicine => (
                <Grid item xs={3} key={medicine.id}>
                    <MedCard medicine={medicine}/>
                </Grid>
            ))}
        </Grid>
    )
}