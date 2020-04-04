using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Repositories;
using WebApp.Models;

namespace WebApp.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(
            IDeliveryRepository deliveryRepository,
            IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public Task<DeliveryDto> CreateAsync(DeliveryDto deliveryDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeliveryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryDto> GetAsync(Guid deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DeliveryDto deliveryDto)
        {
            throw new NotImplementedException();
        }
    }
}