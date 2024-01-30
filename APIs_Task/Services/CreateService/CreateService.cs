namespace APIs_Task.Services
{
    public class CreateService : ICreateService
    {
        private readonly AppDbContext _context;

        public CreateService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Create> Add(Create create)
        {
            await _context.AddAsync(create);
            _context.SaveChanges();

            return create;
        }

        public Create Delete(Create create)
        {
            _context.Remove(create);
            _context.SaveChanges();

            return create;
        }

        public async Task<IEnumerable<Create>> GetAll()
        {
            return await _context.creates.Include(m => m.Branch).Include(m => m.Product).ToListAsync();
        }

        public async Task<Create> GetCreatesByIDs(int branchId, int productId)
        {
            return await _context.creates.FindAsync(branchId, productId);
        }

        public Create Update(Create create)
        {
            _context.Update(create);
            _context.SaveChanges();

            return create;
        }
    }
}
