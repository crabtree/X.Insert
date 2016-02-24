using Simple.Data;
using System.Collections.Generic;
using System.Linq;
using X.Insert.DTO.DTOs;
using X.Insert.DTO.Enums;
using X.Insert.Reader.Services.Interfaces;

namespace X.Insert.Reader.Services
{
    public class AddressReadService : ReadService, IAddressReadService
    {
        public AddressReadService()
            : base()
        {

        }

        public AddressReadService(string connectionStringName)
            : base(connectionStringName)
        {

        }

        public AddressDTO GetAddress(int addressId)
        {
            var address = GetAddresses(new[] { addressId });
            return address.FirstOrDefault();
        }

        public AddressDTO GetAddressForObjectByType(int objectId, AddressTypeEnum addressType)
        {
            var addressesForObjectByTypes = GetAddressForObjectByTypes(objectId, new[] { addressType });
            return addressesForObjectByTypes.FirstOrDefault();
        }

        public List<AddressDTO> GetAddresses(IEnumerable<int> addressesIds)
        {
            var db = GetDatabaseConnection();
            return db.adr__Ewid.FindAll(db.adr__Ewid.adr_Id == addressesIds)
                .Select(GetColumnsMapping());
        }

        public List<AddressDTO> GetAddressForObjectByTypes(int objectId, IEnumerable<AddressTypeEnum> addressTypes)
        {
            var db = GetDatabaseConnection();
            return db.adr__Ewid.Find(db.adr__Ewid.adr_IdObiektu == objectId && db.adr__Ewid.adr_TypAdresu == addressTypes)
                .Select(GetColumnsMapping());
        }

        public List<int> GetAddressesIdsByAddressType(AddressTypeEnum addressType)
        {
            var db = GetDatabaseConnection();
            return db.adr__Ewid.FindAll(db.adr__Ewid.adr_TypAdresu == addressType)
                .Select(db.adr__Ewid.adr_Id)
                .ToScalarList<int>();
        }

        protected IEnumerable<SimpleReference> GetColumnsMapping()
        {
            var db = GetDatabaseConnection();
            return new List<SimpleReference> {
                db.adr__Ewid.adr_Id.As("Id"),
                db.adr__Ewid.adr_IdObiektu.As("ObjectId"),
                db.adr__Ewid.adr_TypAdresu.As("Type"),
                db.adr__Ewid.adr_Nazwa.As("Name"),
                db.adr__Ewid.adr_NazwaPelna.As("FullName"),
                db.adr__Ewid.adr_Telefon.As("PhoneNumber"),
                db.adr__Ewid.adr_Faks.As("FaxNumber"),
                db.adr__Ewid.adr_Ulica.As("Street"),
                db.adr__Ewid.adr_NrDomu.As("BuildingNumber"),
                db.adr__Ewid.adr_NrLokalu.As("FlatNumber"),
                db.adr__Ewid.adr_Kod.As("ZipCode"),
                db.adr__Ewid.adr_Miejscowosc.As("City"),
                db.adr__Ewid.adr_IdWojewodztwo.As("CountryRegionId"),
                db.adr__Ewid.adr_IdPanstwo.As("CountryId"),
                db.adr__Ewid.adr_NIP.As("TaxNumber"),
                db.adr__Ewid.adr_Poczta.As("PostOfficeCity"),
                db.adr__Ewid.adr_Gmina.As("Community"),
                db.adr__Ewid.adr_Powiat.As("County"),
                db.adr__Ewid.adr_IdGminy.As("CommunityId"),
                db.adr__Ewid.adr_Skrytka.As("PostBox"),
                db.adr__Ewid.adr_DataZmiany.As("ModificationTime")
            };
        }
    }
}
