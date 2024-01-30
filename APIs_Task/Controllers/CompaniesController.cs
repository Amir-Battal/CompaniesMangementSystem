using APIs_Task.Dtos.Company;
using APIs_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIs_Task.Controllers
{

    [Route("api/[controller]/[action]/")]//todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

        {
            var companies = await _companyService.GetAll();
                //.Include(m => m.Branches)
                //.ThenInclude(m => m.Products)
                //.ThenInclude(m => m.creates)
                //.Include(m => m.Branches)
                //.ThenInclude(m => m.Products)
                //.ThenInclude(m => m.supplys)
                //.ToListAsync();

            return Ok(companies);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetOneById(id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }
        



        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromForm] AddCompanyDto dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                Location = dto.Location,
                EstDate = dto.EstDate,
                IsActive = dto.IsActive,
            };

            await _companyService.Add(company);

            return Ok(company);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddCompanyDto dto)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound($"No comapny was found with ID: {id}");

            company.Name = dto.Name;
            company.Location = dto.Location;   
            company.EstDate = dto.EstDate;
            company.IsActive = dto.IsActive;

            _companyService.Update(company);

            return Ok(company);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound($"No comapny was found with ID: {id}");

            _companyService.Delete(company);

            return Ok(company);

        }

    }
}
