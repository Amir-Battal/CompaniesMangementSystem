using APIs_Task.Dtos.Supplies;
using APIs_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Task.Controllers
{
    [Route("api/[controller]/[action]")]//todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly ISupplyService _supplyService;
        private readonly ICreateService _createService;
        private readonly IBranchService _branchService;

        public SupplyController(ISupplyService supplyService, ICreateService createService, IBranchService branchService)
        {
            _supplyService = supplyService;
            _createService = createService;
            _branchService = branchService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var supply = await _supplyService.GetAll();

            return Ok(supply);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] AddSupplyDto dto)
        {
            var supply = new Supply
            {
                BranchId = dto.BranchId,
                ProductId = dto.ProductId,
                SProductQuantity = dto.SProductQuantity,
                SuppliedDate = dto.SuppliedDate,
            };


            var creates = await _createService.GetAll();

            foreach (var create in creates)
            {
                if (create.ProductId == dto.ProductId)
                {
                    supply.fromBranch = create.BranchId;
                }
            }


            var MainBranch = await _branchService.GetById(dto.BranchId);
            if (MainBranch.IsPrimary == true)
            {
                return BadRequest("This is Main Branch");
            }


            await _supplyService.Add(supply);

            return Ok(supply);
        }



        [HttpPut("{BranchId, ProductId}")]
        public async Task<IActionResult> UpdateAsync(int BranchId, int ProductId, [FromForm] AddSupplyDto dto)
        {
            var supply = await _supplyService.GetSuppliesByIDs(BranchId, ProductId);

            if (supply == null)
                return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

            supply.BranchId = dto.BranchId;
            supply.ProductId = dto.ProductId;
            supply.SProductQuantity = dto.SProductQuantity;
            supply.SuppliedDate = dto.SuppliedDate;

            var MainBranch = await _branchService.GetById(supply.BranchId);
            if (MainBranch.IsPrimary == true)
            {
                return BadRequest("This is Main Branch");
            }

            _supplyService.Update(supply);

            return Ok(supply);
        }



        [HttpDelete("{BranchId, ProductId}")]
        public async Task<IActionResult> DeleteAsync(int BranchId, int ProductId)
        {
            var supply = await _supplyService.GetSuppliesByIDs(BranchId, ProductId);

            if (supply == null)
                return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

            var MainBranch = await _branchService.GetById(supply.BranchId);
            if (MainBranch.IsPrimary == true)
            {
                return BadRequest("This is Main Branch");
            }

            _supplyService.Delete(supply);

            return Ok(supply);

        }
    }
}
