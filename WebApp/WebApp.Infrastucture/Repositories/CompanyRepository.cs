using System;
using WebApp.Domain.Models;
using WebApp.Domain.Repositories;

namespace WebApp.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}