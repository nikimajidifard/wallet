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
        string CreateCompany(CompanyDto company);
        string DeleteCompany(CompanyDto company);
        string UpdateCompany(CompanyDto company);
        List<CompanyDto> GetALLCompanies();
        CompanyDto GetCompany(int companyId);
    }
}
