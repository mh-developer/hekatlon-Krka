using System.Collections.Generic;

namespace WebApp.Models.Warehouses
{
    public class WarehouseViewModel : WarehouseDto
    {
        public IList<WarehouseDto> WarehouseDtos { get; set; }
    }
}