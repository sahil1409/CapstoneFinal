import { useState, useEffect } from "react";
import agent from "../../agent";
import { Medicine } from "../../models/medicine";
import MedicineList from "./MedicineList";

export default function Inventory() {

    const [medicines, setMedicines] = useState<Medicine[]>([]);

  useEffect(() => {
    agent.Inventory.list().then(medicines => setMedicines(medicines))
  }, [])

    return (
        <>
            <MedicineList medicines={medicines}/>
        </>
    )
}