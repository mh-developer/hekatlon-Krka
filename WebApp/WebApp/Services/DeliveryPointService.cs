using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Repositories;
using WebApp.Models;

namespace WebApp.Services
{
    public class DeliveryPointService : IDeliveryPointService
    {
        private readonly IDeliveryPointRepository _deliveryPointRepository;
        private readonly IMapper _mapper;

        public DeliveryPointService(
            IDeliveryPointRepository deliveryPointRepository,
            IMapper mapper)
        {
            _deliveryPointRepository = deliveryPointRepository;
            _mapper = mapper;
        }

        public Task<DeliveryPointDto> CreateAsync(DeliveryPointDto deliveryPointDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeliveryPointDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryPointDto> GetAsync(Guid deliveryPointId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid deliveryPointId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DeliveryPointDto deliveryPointDto)
        {
            throw new NotImplementedException();
        }
    }
}