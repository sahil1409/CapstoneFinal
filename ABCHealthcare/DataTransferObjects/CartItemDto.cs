namespace ABCHealthcare.DataTransferObjects
{
    public class CartItemDto
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
        public string Seller { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}