using System;
using X.Insert.DTO.Enums;

namespace X.Insert.DTO.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public AddressTypeEnum Type { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }        
        public string City { get; set; }
        public int CountryRegionId { get; set; }
        public int CountryId { get; set; }
        public string TaxNumber { get; set; }
        public string PostOfficeCity { get; set; }
        public string Community { get; set; }
        public string County { get; set; }
        public int CommunityId { get; set; }
        public string PostBox { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
