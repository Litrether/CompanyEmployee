using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CompanyEmployees.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/companies")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public CompaniesV2Controller(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetCompanies"), Authorize]
        public async Task<IActionResult> GetCompanies(
            [FromBody] CompanyParameters companyParameters)
        {
            var companies = await _repository.Company.GetAllCompaniesAsync(
                companyParameters, trackChanges: false);

            return Ok(companies);
        }
    }
}
