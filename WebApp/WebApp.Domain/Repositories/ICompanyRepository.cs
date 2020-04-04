using System;
using WebApp.Domain.Models;

namespace WebApp.Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company, Guid>
    {
    }
}