using Simple.Data;
using System.Collections.Generic;
using System.Linq;
using X.Insert.DTO.DTOs;
using X.Insert.Reader.Services.Interfaces;

namespace X.Insert.Reader.Services
{
    public class WarehouseReadService : ReadService, IWarehouseReadService
    {
        public WarehouseReadService()
            : base()
        {

        }

        public WarehouseReadService(string connectionStringName)
            : base(connectionStringName)
        {

        }

        public WarehouseDTO GetMainWarehouse()
        {
            var db = GetDatabaseConnection();
            return db.sl_Magazyn
                .FindAll(db.sl_Magazyn.mag_Glowny == true)
                .Select(GetColumnsMapping())
                .FirstOrDefault();
        }

        public WarehouseDTO GetWarehouse(int warehouseId)
        {
            var warehouses = GetWarehousesByIds(new[] { warehouseId });
            return warehouses.FirstOrDefault();
        }

        public List<WarehouseDTO> GetWarehouses()
        {
            var db = GetDatabaseConnection();
            return db.sl_Magazyn
                .All()
                .Select(GetColumnsMapping());
        }

        public List<WarehouseDTO> GetWarehousesByIds(IEnumerable<int> warehousesIds)
        {
            var db = GetDatabaseConnection();
            return db.sl_Magazyn
                .FindAll(db.sl_Magazyn.mag_Id == warehousesIds)
                .Select(GetColumnsMapping());
        }

        public List<int> GetWarehousesIds()
        {
            var db = GetDatabaseConnection();
            return db.sl_Magazyn
                .All()
                .Select(db.sl_Magazyn.mag_Id)
                .ToScalarList<int>();
        }

        protected IEnumerable<SimpleReference> GetColumnsMapping()
        {
            var db = GetDatabaseConnection();
            return new List<SimpleReference>
            {
                db.sl_Magazyn.mag_Id.As("Id"),
                db.sl_Magazyn.mag_Symbol.As("Symbol"),
                db.sl_Magazyn.mag_Nazwa.As("Name"),
                db.sl_Magazyn.mag_Opis.As("Description"),
                db.sl_Magazyn.mag_Glowny.As("Main")
            };
        }
    }
}
