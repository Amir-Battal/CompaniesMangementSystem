// using APIs_Task.Models;
// using Microsoft.EntityFrameworkCore;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//
// namespace APIs_Task.Services
// {
//     //todo you have to use the SaveChangeAsync(); not SaveChange();
//     //todo don
//     public class BranchService : IBranchService
//     {
//         private readonly AppDbContext _context;
//
//         public BranchService(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<GetBranchDto> Add(AddBranchDto dto)
//         {
//             var branch = new Branch
//             {
//                 CompanyId = dto.CompanyId,
//                 IsPrimary = dto.IsPrimary,
//                 Name = dto.BranchName,
//                 Location = dto.BranchLocation,
//             };
//             _context.Add(branch);
//             await _context.SaveChangesAsync();
//             return await _context.branches.Where(b => b.Id == branch.Id).Select(b => new GetBranchDto()
//             {
//                 Id = b.Id,
//                 Location = b.Location,
//                 Name = b.Name
//             }).FirstAsync();
//         }
//
//         public Branch Delete(Branch branch)
//         {
//             _context.Remove(branch);
//             _context.SaveChanges(); //todo use the async version
//
//             return branch;
//         }
//
//         public async Task<IEnumerable<Branch>> GetAll()
//         {
//             return await _context.branches.ToListAsync();
//         }
//
//         public async Task<IEnumerable<Branch>> GetByCompanyId(int companyId)
//         {
//             return await _context.branches.Where(m => m.CompanyId == companyId).ToListAsync();
//         }
//
//         public async Task<Branch> GetById(int id)
//         {
//             return await _context.branches.FindAsync(id); //todo FirstAsync()
//         }
//
//         public async Task<IEnumerable<Branch>> GetPrimary()
//         {
//             return
//                 await _context.branches.Where(m => m.IsPrimary == true)
//                     .ToListAsync(); //todo it's not really wrong but you can Just the condition be Where(m => m.IsPrime()) it's better 
//         }
//
//         public async Task<IEnumerable<Branch>> GetSecondary()
//         {
//             return await _context.branches.Where(m => m.IsPrimary != true).ToListAsync(); //todo the same above
//         }
//
//         public Branch Update(Branch branch)
//         {
//             _context.Update(branch);
//             _context.SaveChanges(); //todo use the asyncVersion
//
//             return branch;
//         }
//     }
// }