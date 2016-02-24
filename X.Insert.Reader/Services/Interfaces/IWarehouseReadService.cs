using System.Collections.Generic;
using X.Insert.DTO.DTOs;

namespace X.Insert.Reader.Services.Interfaces
{
    public interface IWarehouseReadService
    {
        WarehouseDTO GetMainWarehouse();
        WarehouseDTO GetWarehouse(int warehouseId);
        List<WarehouseDTO> GetWarehousesByIds(IEnumerable<int> warehousesIds);
        List<WarehouseDTO> GetWarehouses();
        List<int> GetWarehousesIds();
    }
}
