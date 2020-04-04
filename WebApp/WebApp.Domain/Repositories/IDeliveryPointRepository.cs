using System;
using WebApp.Domain.Models;

namespace WebApp.Domain.Repositories
{
    public interface IDeliveryPointRepository : IRepository<DeliveryPoint, Guid>
    {
    }
}