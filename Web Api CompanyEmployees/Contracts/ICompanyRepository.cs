using System;
using System.Collections.Generic;
using Entities.RequestFeatures;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
   public interface ICompanyRepository
    {
        Task<PagedList<Company>> GetAllCompaniesAsync(
            CompanyParameters companyParameters, bool trackChanges);

        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);

        void CreateCompany(Company company);

        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids,
            bool trackChanges);

        void DeleteCompany(Company company);
    }
}
