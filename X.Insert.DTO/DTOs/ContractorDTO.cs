using X.Insert.DTO.Enums;

namespace X.Insert.DTO.DTOs
{
    public class ContractorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Symbol { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        public int ContractorGroupId { get; set; }
        public string Comments { get; set; }
        public bool Person { get; set; }
        public ContractorDirectionEnum Direction { get; set; }
    }
}
