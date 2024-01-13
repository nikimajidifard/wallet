using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Infrastructure.Data;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using wallet.Domain.Entities;

namespace Wallet.Application.Services
{
    public class CompanyServices : ICompany
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string CreateCompany(CompanyDto companydto)
        {
            var company = _mapper.Map<CompanyDto>(companydto);
            _dbContext.Add<CompanyDto>(company);
            _dbContext.SaveChanges();
            return "company was created";
        }

        public List<CompanyDto> GetALLCompanies()
        {
            var companies = _dbContext.Companies.ToList();
            var companyDtos = _mapper.Map<List<CompanyDto>>(companies);
            return companyDtos;
        }

        public CompanyDto GetCompany(int companyId)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.CompanyId == companyId);
            if (company == null) {throw new CompanyNotFoundException("Company with ID {companyId} not found"); }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public string UpdateCompany(CompanyDto companydto)
        {
            var company = _mapper.Map<Company>(companydto);
            _dbContext.Companies.Update(company);
            _dbContext.SaveChanges();
            return "Comapny was updated";
        }

        public string DeleteCompany(CompanyDto companydto)
        {
            var company = _mapper.Map<Company>(companydto);
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
            return "company was removed";
        }


        public class CompanyNotFoundException : Exception
        {
            public CompanyNotFoundException(string message) : base(message) { }
        }
    }
}
