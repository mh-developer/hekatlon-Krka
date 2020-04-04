using System;
using WebApp.Domain.Models;

namespace WebApp.Domain.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse, Guid>
    {
    }
}