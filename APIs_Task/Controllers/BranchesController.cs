using APIs_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Task.Controllers
{
    //TODO very important role don't return the entity as it but you have to return the dto ||OK||
    //TODO in other word every request have two dto (RequestDto) And (ResponseDto) ||OK||
    //TODO in most cases we dont' make the same dto for two routes(Controllers) ||OK||
    //TODO I Will Make the create Branch As an Example ||OK||

    [Route("api/[controller]/[action]")] //todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var branches = await _branchService.GetAll();
            //.Include(m => m.Products)
            //.ThenInclude(m => m.creates)
            //.Include(m => m.Products)
            //.ThenInclude(m => m.supplys)
            //.ToListAsync();

            return Ok(branches);
        }


        [HttpGet("GetPrimaryBranch")]
        public async Task<IActionResult> GetPrimaryBranch()
        {
            var branches = await _branchService.GetPrimary();

            return Ok(branches);
        }


        [HttpGet("GetSecondaryBranch")]
        public async Task<IActionResult> GetSecondaryBranch()
        {
            var branches = await _branchService.GetSecondary();

            return Ok(branches);
        }


        [HttpGet("GetByComapnyId")]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            var branches = await _branchService.GetByCompanyId(companyId);
            return Ok(branches);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBranchDto dto)
            => new JsonResult(await _branchService.Add(dto));//Todo this a good example how you should work ||OK||


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddBranchDto dto)
        {
            var branch = await _branchService.GetById(id);

            if (branch == null)
                return NotFound($"No branch was found with ID: {id}");

            branch.IsPrimary = dto.IsPrimary;
            branch.Name = dto.BranchName;
            branch.Location = dto.BranchLocation;
            branch.CompanyId = dto.CompanyId;

            _branchService.Update(branch);

            return Ok(branch);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var branch = await _branchService.GetById(id);

            if (branch == null)
                return NotFound($"No branch was found with ID: {id}");

            _branchService.Delete(branch);

            return Ok(branch);
        }
    }
}