using APIs_Task.Models;
using APIs_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Task.Controllers
{
    [Route("api/[controller]/[action]")]//todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ICreateService _createService;

        public ReportController(IReportService reportService, ICreateService createService)
        {
            _reportService = reportService;
            _createService = createService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var report = await _reportService.GetAll();

            return Ok(report);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ReportDto dto)
        {

            var report = new Report()
            {
                from = dto.from,
                to = dto.to,
                companyId = dto.companyId,
                branchId = dto.branchId,
            };

            report.creates = new List<Create>();


            var creates = await _createService.GetAll();

            var filteredCreates =creates.Where(c => c.CreatedDate >= dto.from && c.CreatedDate <= dto.to).ToList();

            report.creates.AddRange(filteredCreates);



            _reportService.Add(report);

            return Ok(report);
        }
    }
}
