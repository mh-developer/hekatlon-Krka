using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Models;
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

        public async Task<WarehouseDto> CreateAsync(WarehouseDto warehouseDto)
        {
            if (warehouseDto == null)
            {
                throw new ArgumentNullException(nameof(warehouseDto));
            }

            var existingWarehouse = await _warehouseRepository.FilterAsync(x =>
                x.Name == warehouseDto.Name && x.Company.Id == warehouseDto.Company.Id);
            if (existingWarehouse.Count != 0)
            {
                throw new Exception("Warehouse with same name already exists.");
            }

            var warehouse = _mapper.Map<WarehouseDto, Warehouse>(warehouseDto);

            _warehouseRepository.Add(warehouse);

            await _warehouseRepository.SaveChangesAsync();

            return _mapper.Map<Warehouse, WarehouseDto>(warehouse);
        }

        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();

            return _mapper.Map<List<Warehouse>, List<WarehouseDto>>(warehouses);
        }

        public async Task<WarehouseDto> GetAsync(Guid warehouseId)
        {
            if (warehouseId == default)
            {
                throw new ArgumentException("Warehouse id is invalid.", nameof(warehouseId));
            }

            var warehouse = await _warehouseRepository.GetAsync(warehouseId);
            if (warehouse == null)
            {
                throw new Exception($"Could not find warehouse with id = '{warehouseId}'.");
            }

            return _mapper.Map<Warehouse, WarehouseDto>(warehouse);
        }

        public async Task RemoveAsync(Guid warehouseId)
        {
            if (warehouseId == default)
            {
                throw new ArgumentException("Warehouse id is invalid.", nameof(warehouseId));
            }

            var warehouse = await _warehouseRepository.GetAsync(warehouseId);
            if (warehouse == null)
            {
                throw new Exception($"Could not find warehouse with id = '{warehouseId}'.");
            }

            _warehouseRepository.Remove(warehouse);

            await _warehouseRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(WarehouseDto warehouseDto)
        {
            if (warehouseDto == null)
            {
                throw new ArgumentNullException(nameof(warehouseDto));
            }

            if (warehouseDto.Id == default)
            {
                throw new ArgumentException("Warehouse id is invalid.", nameof(warehouseDto.Id));
            }

            var warehouse = await _warehouseRepository.GetAsync(warehouseDto.Id);
            if (warehouse == null)
            {
                throw new Exception($"Could not find warehouse with id = '{warehouseDto.Id}'.");
            }

            _mapper.Map(warehouseDto, warehouse);

            await _warehouseRepository.SaveChangesAsync();
        }
    }
}