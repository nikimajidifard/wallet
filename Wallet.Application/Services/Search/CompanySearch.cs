using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using wallet.Domain.Enums;
using Wallet.Infrastructure.Data;
using AutoMapper;
using System.Transactions;
using static System.TimeZoneInfo;
using wallet.Domain.Entities;
using System.Collections;

namespace Wallet.Application.Services.Search
{
    public class CompanySearch : ISearchCompany
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;

        public CompanySearch(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<CompanyDto> GetCompanybyCompanyNo(string CompanyNo)
        {
            var filteredCompanies = _dbContext.Companies.Where(t => t.CompanyNo == CompanyNo).ToList();
            var CompaniesDto = _mapper.Map<List<CompanyDto>>(filteredCompanies);
            return CompaniesDto;
        }

        public CompanyDto GetCompanybyId(int CompanyID)
        {
            var Company = _dbContext.Companies.FirstOrDefault(u => u.CompanyId == CompanyID);
            if (Company == null)
                return null;

            var CompanyDto = _mapper.Map<CompanyDto>(Company);

            return CompanyDto;
        }

        public CompanyDto GetCompanybyLocation(string CompanyLocation)
        {
            var Company = _dbContext.Companies.FirstOrDefault(u => u.CompanyLocation == CompanyLocation);
            if (Company == null)
                return null;

            var CompanyDto = _mapper.Map<CompanyDto>(Company);

            return CompanyDto;
        }

        public List<CompanyDto> GetCompanybyName(string CompanyName)
        {
            var filteredCompanies = _dbContext.Companies.Where(t => t.CompanyName == CompanyName).ToList();
            var CompaniesDto = _mapper.Map<List<CompanyDto>>(filteredCompanies);
            return CompaniesDto;

        }

        public List<CompanyDto> GetCompanybyRate(float CompanyRate)
        {
            var filteredCompanies = _dbContext.Companies.Where(t => t.CompanyRate == CompanyRate).ToList();
            var CompaniesDto = _mapper.Map<List<CompanyDto>>(filteredCompanies);
            return CompaniesDto;
        }

    }
}
