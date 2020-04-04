using System;
using WebApp.Domain.Models;
using WebApp.Domain.Repositories;

namespace WebApp.Infrastructure.Repositories
{
    public class WarehouseRepository : Repository<Warehouse, Guid>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}