using System.Collections.Generic;
using X.Insert.DTO.DTOs;
using X.Insert.DTO.Enums;

namespace X.Insert.Reader.Services.Interfaces
{
    public interface IAddressReadService
    {
        AddressDTO GetAddress(int addressId);
        AddressDTO GetAddressForObjectByType(int objectId, AddressTypeEnum addressType);
        List<AddressDTO> GetAddresses(IEnumerable<int> addressesIds);
        List<AddressDTO> GetAddressForObjectByTypes(int objectId, IEnumerable<AddressTypeEnum> addressTypes);
        List<int> GetAddressesIdsByAddressType(AddressTypeEnum addressType);
    }
}
