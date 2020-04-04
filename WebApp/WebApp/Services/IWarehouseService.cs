using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IWarehouseService
    {
        Task<List<WarehouseDto>> GetAllAsync();

        Task<WarehouseDto> GetAsync(Guid warehouseId);

        Task<WarehouseDto> CreateAsync(WarehouseDto warehouseDto);

        Task UpdateAsync(WarehouseDto warehouseDto);

        Task RemoveAsync(Guid warehouseId);
    }
}