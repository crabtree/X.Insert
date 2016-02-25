using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Insert.DTO.DTOs;
using X.Insert.Reader.Services.Interfaces;

namespace X.Insert.Reader.Services
{
    public class WarehouseProductAmountReadService : ReadService, IWarehouseProductAmountReadService
    {
        public WarehouseProductAmountReadService()
                    : base()
        {

        }

        public WarehouseProductAmountReadService(string connectionStringName)
            : base(connectionStringName)
        {

        }

        public WarehouseProductAmountDTO GetWarehouseProductAmount(int productId, int warehouseId, DateTime? date = null)
        {
            return GetWarehousesProductsAmounts(new[] { productId }, new[] { warehouseId }, date).FirstOrDefault();
        }

        public List<WarehouseProductAmountDTO> GetWarehouseProductsAmounts(IEnumerable<int> productsIds, int warehouseId, DateTime? date = null)
        {
            return GetWarehousesProductsAmounts(productsIds, new[] { warehouseId }, date);
        }

        public List<WarehouseProductAmountDTO> GetWarehousesProductAmounts(int productId, IEnumerable<int> warehousesIds, DateTime? date = null)
        {
            return GetWarehousesProductsAmounts(new[] { productId }, warehousesIds, date);
        }

        public List<WarehouseProductAmountDTO> GetWarehousesProductsAmounts(IEnumerable<int> productsIds, IEnumerable<int> warehousesIds, DateTime? date = null)
        {
            if (date == null) date = DateTime.Now;

            var list = new List<WarehouseProductAmountDTO>();

            var db = GetDatabaseConnection() as Simple.Data.Database;
            var query = BuildGetWarehouseAmountQuery(warehousesIds, productsIds);
            var result = db.ToRows(query, new { paramDate = date.Value }).ToList();
            result.ForEach((d) => list.Add(new WarehouseProductAmountDTO
            {
                ProductAmount = d.ProductAmount,
                ProductId = d.ProductId,
                WarehouseId = d.WarehouseId
            }));

            return list;
        }

        private static string BuildGetWarehouseAmountQuery(IEnumerable<int> warehousesIds, IEnumerable<int> productsIds)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT");
            builder.Append(" A.mr_TowId AS ProductId");
            builder.Append(" , sum(A.mr_Ilosc - isnull(R.mr_Ilosc, 0)) AS ProductAmount");
            builder.Append(" , A.mr_MagId AS WarehouseId");
            builder.Append(" FROM dok_MagRuch A");
            builder.Append(" LEFT JOIN (( SELECT ISNULL(SUM(C.mr_Ilosc), 0) mr_Ilosc, C.mr_DoId");
            builder.Append(" FROM dok_MagRuch C");
            builder.Append(" WHERE C.mr_Data <= @paramDate");
            builder.Append(" GROUP BY C.mr_DoId");
            builder.Append(" )) R on R.mr_DoId = A.mr_Id");
            builder.Append(" WHERE");
            builder.Append(" A.mr_Ilosc > ISNULL(R.mr_Ilosc, 0)");
            builder.AppendFormat(" AND A.mr_MagId IN ({0})", string.Join<int>(",", warehousesIds));
            builder.AppendFormat(" AND A.mr_TowId IN ({0})", string.Join<int>(",", productsIds));
            builder.Append(" GROUP BY A.mr_TowId, A.mr_MagId");

            return builder.ToString();
        }
    }
}
