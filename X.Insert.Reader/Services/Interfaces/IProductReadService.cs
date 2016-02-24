using System.Collections.Generic;
using X.Insert.DTO.DTOs;

namespace X.Insert.Reader.Services.Interfaces
{
    public interface IProductReadService
    {
        ProductDTO GetProduct(int productId);
        List<ProductDTO> GetProducts(IEnumerable<int> productsIds);
        List<int> GetProductsIdsByGroupId(int productsGroupId);
        List<int> GetProductsIdsByGroupsId(IEnumerable<int> productsGroupsId);
        List<int> GetProductsIds();
    }
}
