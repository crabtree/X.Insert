namespace X.Insert.DTO.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public bool Locked { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultBarcode { get; set; }
        public string Comments { get; set; }
        public bool Deleted { get; set; }
    }
}
