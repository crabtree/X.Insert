using System.Collections.Generic;
using X.Insert.DTO.DTOs;

namespace X.Insert.Reader.Services.Interfaces
{
    public interface IContractorReadService
    {
        ContractorDTO GetContractor(int contractorId);
        List<ContractorDTO> GetContractors(IEnumerable<int> contractorsIds);
        List<int> GetContractorsIds();
    }
}
