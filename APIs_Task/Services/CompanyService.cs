// using APIs_Task.Models;
// using Microsoft.EntityFrameworkCore;
//
// namespace APIs_Task.Services
// {
//     public class CompanyService : ICompanyService
//     {
//         private readonly AppDbContext _context;
//
//         public CompanyService(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<Company> Add(Company company)
//         {
//             await _context.companies.AddAsync(company);
//             _context.SaveChanges();
//
//             return company;
//         }
//
//         public Company Delete(Company company)
//         {
//             _context.Remove(company);
//             _context.SaveChanges();
//
//             return company;
//         }
//
//         public async Task<IEnumerable<Company>> GetAll()
//         {
//             return await _context.companies.ToListAsync();
//         }
//
//         public async Task<Company> GetById(int id)
//         {
//             return await _context.companies.FindAsync(id);
//         }
//
//         public async Task<Company> GetOneById(int id)
//         {
//             return await _context.companies.Include(m => m.Branches).SingleOrDefaultAsync(m => m.Id == id);
//         }
//
//         public Company Update(Company company)
//         {
//             _context.Update(company);
//             _context.SaveChanges();
//
//             return company;
//         }
//     }
// }
