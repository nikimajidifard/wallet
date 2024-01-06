using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface ICompany
    {
        string CreateCompany(CompanyDto Company);
        string DeleteCompany(CompanyDto Company);
        string UpdateCompany(CompanyDto Company);
        List<CompanyDto> GetALLCompanies();
        CompanyDto GetCompany(int CompanyId);
    }
}
