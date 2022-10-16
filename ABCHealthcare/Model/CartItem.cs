﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ABCHealthcare.Model
{
    [Table("CartItems")]
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}