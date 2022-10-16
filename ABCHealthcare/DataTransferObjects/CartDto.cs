﻿using System.Collections.Generic;

namespace ABCHealthcare.DataTransferObjects
{
    public class CartDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<CartItemDto> Items { get; set; }
    }
}
