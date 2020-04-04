using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Repositories;
using WebApp.Models;

namespace WebApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<CompanyDto> CreateAsync(CompanyDto companyDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDto> GetAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyDto companyDto)
        {
            throw new NotImplementedException();
        }
    }
}