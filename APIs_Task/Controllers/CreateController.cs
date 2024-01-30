using APIs_Task.Dtos.Create;
using APIs_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Task.Controllers
{

    [Route("api/[controller]/[action]")]//todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly ICreateService _createService;
        private readonly IBranchService _branchService;
        private readonly IProductService _productService;

        public CreateController(ICreateService createService, IBranchService branchService, IProductService productService)
        {
            _createService = createService;
            _branchService = branchService;
            _productService = productService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var create = await _createService.GetAll();

            return Ok(create);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] AddCreateDto dto)
        {

            var create = new Create
            {
                BranchId = dto.BranchId,
                ProductId = dto.ProductId,
                ProductQuantity = dto.ProductQuantity,
                CreatedDate = dto.CreatedDate
            };

            var product = await _productService.GetById(dto.ProductId);
            create.Product = product;

            var MainBranch = await _branchService.GetById(dto.BranchId);
            if (!MainBranch.IsPrimary == true)
            {
                return BadRequest("This is not Main Branch");
            }

            await _createService.Add(create);

            return Ok(create);
        }



        [HttpPut("{BranchId, ProductId}")]
        public async Task<IActionResult> UpdateAsync(int BranchId, int ProductId, [FromForm] AddCreateDto dto)
        {
            var create = await _createService.GetCreatesByIDs(BranchId, ProductId);

            if (create == null)
                return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

            create.BranchId = dto.BranchId;
            create.ProductId = dto.ProductId;
            create.ProductQuantity = dto.ProductQuantity;
            create.CreatedDate = dto.CreatedDate;

            var MainBranch = await _branchService.GetById(dto.BranchId);
            if (!MainBranch.IsPrimary == true)
            {
                return BadRequest("This is not Main Branch");
            }

            _createService.Update(create);

            return Ok(create);
        }



        [HttpDelete("{BranchId, ProductId}")]
        public async Task<IActionResult> DeleteAsync(int BranchId, int ProductId)
        {
            var create = await _createService.GetCreatesByIDs(BranchId, ProductId);

            if (create == null)
                return NotFound($"No branch was found with ID: {BranchId} or No product was found with ID: {ProductId}");

            var MainBranch = await _branchService.GetById(BranchId);
            if (!MainBranch.IsPrimary == true)
            {
                return BadRequest("This is not Main Branch");
            }

            _createService.Delete(create);

            return Ok(create);

        }
    }
}
