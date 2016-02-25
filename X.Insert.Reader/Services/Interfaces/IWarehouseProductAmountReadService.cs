using System;
using System.Collections.Generic;
using X.Insert.DTO.DTOs;

namespace X.Insert.Reader.Services.Interfaces
{
    public interface IWarehouseProductAmountReadService
    {
        WarehouseProductAmountDTO GetWarehouseProductAmount(int productId, int warehouseId, DateTime? date = null);
        List<WarehouseProductAmountDTO> GetWarehouseProductsAmounts(IEnumerable<int> productsIds, int warehouseId, DateTime? date = null);
        List<WarehouseProductAmountDTO> GetWarehousesProductAmounts(int productId, IEnumerable<int> warehousesIds, DateTime? date = null);
        List<WarehouseProductAmountDTO> GetWarehousesProductsAmounts(IEnumerable<int> productsIds, IEnumerable<int> warehousesIds, DateTime? date = null);
    }
}
