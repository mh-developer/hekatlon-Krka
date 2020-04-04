using System;
using WebApp.Domain.Models;

namespace WebApp.Domain.Repositories
{
    public interface IDeliveryRepository : IRepository<Delivery, Guid>
    {
    }
}