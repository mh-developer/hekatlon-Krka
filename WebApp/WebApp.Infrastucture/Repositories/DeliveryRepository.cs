using System;
using WebApp.Domain.Models;
using WebApp.Domain.Repositories;

namespace WebApp.Infrastructure.Repositories
{
    public class DeliveryRepository : Repository<Delivery, Guid>, IDeliveryRepository
    {
        public DeliveryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}