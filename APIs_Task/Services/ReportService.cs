// using Microsoft.EntityFrameworkCore;
//
// namespace APIs_Task.Services
// {
//     public class ReportService : IReportService
//     {
//         private readonly AppDbContext _context;
//
//         public ReportService(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<Report> Add(Report report)
//         {
//             await _context.AddAsync(report);
//             _context.SaveChanges();
//
//             return report;
//         }
//
//         public async Task<IEnumerable<Report>> GetAll()
//         {
//             return await _context.reports.Include(m => m.creates).ToListAsync();
//         }
//     }
// }
