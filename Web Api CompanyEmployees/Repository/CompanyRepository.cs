using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Entities.RequestFeatures;
using System.Threading.Tasks;
using Repository.Extensions;
using Entities.Models;
using System.Linq;
using Contracts;
using Entities;
using System;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            :base (repositoryContext)
        {
        }

        public async Task<PagedList<Company>> GetAllCompaniesAsync(
            CompanyParameters companyParameters, bool trackChanges)
        {
            var companies = await FindAll(trackChanges)
                    .Search(companyParameters.SearchTerm)
                    .Sort(companyParameters.OrderBy)
                    .ToListAsync();

            return PagedList<Company>
                .ToPagedList(companies, companyParameters.PageNumber,
            companyParameters.PageSize);
        }

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCompany(Company company) => Create(company);

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, 
            bool trackChange) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChange)
            .ToListAsync();

        public void DeleteCompany(Company company) =>
            Delete(company);

    }
}
