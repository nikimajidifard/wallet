using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface ISearchCompany
    {
        CompanyDto GetCompanybyId(int CompanyID);
        List<CompanyDto> GetCompanybyName(string CompanyName);
        CompanyDto GetCompanybyLocation(string CompanyLocation);
        List<CompanyDto> GetCompanybyRate(float CompanyRate);
        List<CompanyDto> GetCompanybyCompanyNo(string CompanyNo);
    }
}
