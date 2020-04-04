using System;
using WebApp.Domain.Models;
using WebApp.Domain.Repositories;

namespace WebApp.Infrastructure.Repositories
{
    public class DeliveryPointRepository : Repository<DeliveryPoint, Guid>, IDeliveryPointRepository
    {
        public DeliveryPointRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}