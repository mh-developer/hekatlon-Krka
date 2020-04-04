using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllAsync();

        Task<CompanyDto> GetAsync(Guid companyId);

        Task<CompanyDto> CreateAsync(CompanyDto companyDto);

        Task UpdateAsync(CompanyDto companyDto);

        Task RemoveAsync(Guid companyId);
    }
}