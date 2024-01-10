using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Infrastructure.Data;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;

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

        public string DeleteCompany(CompanyDto company)
        {
            throw new NotImplementedException();
        }

        public List<CompanyDto> GetALLCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyDto GetCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public string UpdateCompany(CompanyDto company)
        {
            throw new NotImplementedException();
        }
    }
}
