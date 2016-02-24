using System.Collections.Generic;
using System.Linq;
using X.Insert.DTO.DTOs;
using X.Insert.DTO.Enums;
using X.Insert.Reader.Services.Interfaces;

namespace X.Insert.Reader.Services
{
    public class ContractorReadService : ReadService, IContractorReadService
    {
        public ContractorReadService()
            : base()
        {

        }

        public ContractorReadService(string connectionStringName)
            : base(connectionStringName)
        {

        }

        public ContractorDTO GetContractor(int contractorId)
        {
            var contractors = GetContractors(new[] { contractorId });
            return contractors.FirstOrDefault();
        }

        public List<ContractorDTO> GetContractors(IEnumerable<int> contractorsIds)
        {
            var db = GetDatabaseConnection();
            return db.kh__Kontrahent.FindAll(db.kh__Kontrahent.kh_Id == contractorsIds)
                .LeftJoin(db.adr__Ewid).On(db.adr__Ewid.adr_IdObiektu == db.kh__Kontrahent.kh_Id && db.adr__Ewid.adr_TypAdresu == AddressTypeEnum.Main)
                .Select(
                    db.kh__Kontrahent.kh_Id.As("Id"),
                    db.kh__Kontrahent.kh_Symbol.As("Symbol"),
                    db.kh__Kontrahent.kh_EMail.As("Email"),
                    db.kh__Kontrahent.kh_IdGrupa.As("ContractorGroupId"),
                    db.kh__Kontrahent.kh_Uwagi.As("Comments"),
                    db.kh__Kontrahent.kh_Imie.As("FirstName"),
                    db.kh__Kontrahent.kh_Nazwisko.As("LastName"),
                    db.kh__Kontrahent.kh_Osoba.As("Person"),
                    db.kh__Kontrahent.kh_Rodzaj.As("Direction"),
                    db.adr__Ewid.adr_Nazwa.As("Name"),
                    db.adr__Ewid.adr_NIP.As("TaxNumber"));
        }

        public List<int> GetContractorsIds()
        {
            var db = GetDatabaseConnection();
            return db.kh__Kontrahent.All()
                .Select(db.kh__Kontrahent.kh_Id)
                .ToScalarList<int>();
        }
    }
}
