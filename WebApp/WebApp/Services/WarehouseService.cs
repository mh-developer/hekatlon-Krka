using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Repositories;
using WebApp.Models;

namespace WebApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(
            IWarehouseRepository warehouseRepository,
            IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public Task<WarehouseDto> CreateAsync(WarehouseDto warehouseDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<WarehouseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseDto> GetAsync(Guid warehouseId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid warehouseId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WarehouseDto warehouseDto)
        {
            throw new NotImplementedException();
        }
    }
}