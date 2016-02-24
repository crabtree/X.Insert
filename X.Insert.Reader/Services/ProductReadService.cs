using System.Collections.Generic;
using System.Linq;
using X.Insert.DTO.DTOs;
using X.Insert.Reader.Services.Interfaces;

namespace X.Insert.Reader.Services
{
    public class ProductReadService : ReadService, IProductReadService
    {
        public ProductReadService()
            : base()
        {

        }

        public ProductReadService(string connectionStringName)
            : base(connectionStringName)
        {

        }

        public ProductDTO GetProduct(int productId)
        {
            var products = GetProducts(new[] { productId });
            return products.FirstOrDefault();
        }

        public List<ProductDTO> GetProducts(IEnumerable<int> productsIds)
        {
            var db = GetDatabaseConnection();
            return db.tw__Towar
                .FindAll(db.tw__Towar.tw_Id == productsIds)
                .Select(
                    db.tw__Towar.tw_Id.As("Id"),
                    db.tw__Towar.tw_Zablokowany.As("Locked"),
                    db.tw__Towar.tw_Symbol.As("Symbol"),
                    db.tw__Towar.tw_Nazwa.As("Name"),
                    db.tw__Towar.tw_Opis.As("Description"),
                    db.tw__Towar.tw_PodstKodKresk.As("DefaultBarcode"),
                    db.tw__Towar.tw_Uwagi.As("Comments"),
                    db.tw__Towar.tw_Usuniety.As("Deleted"));
        }

        public List<int> GetProductsIdsByGroupId(int productsGroupId)
        {
            return GetProductsIdsByGroupsId(new[] { productsGroupId });
        }

        public List<int> GetProductsIdsByGroupsId(IEnumerable<int> productsGroupsId)
        {
            var db = GetDatabaseConnection();
            return db.tw__Towar
                .FindAll(db.tw__Towar.tw_IdGrupa == productsGroupsId)
                .Select(db.tw__Towar.tw_Id)
                .ToSacalarList<int>();
        }

        public List<int> GetProductsIds()
        {
            var db = GetDatabaseConnection();
            return db.tw__Towar.All()
                .Select(db.tw__Towar.tw_Id)
                .ToScalarList<int>();
        }
    }
}
