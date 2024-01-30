namespace APIs_Task.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly AppDbContext _context;

        public SupplyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supply> Add(Supply supply)
        {
            await _context.AddAsync(supply);
            _context.SaveChanges();

            return supply;
        }

        public Supply Delete(Supply supply)
        {
            _context.Remove(supply);
            _context.SaveChanges();

            return supply;
        }

        public async Task<IEnumerable<Supply>> GetAll()
        {
            return await _context.supplys.ToListAsync();
        }

        public async Task<Supply> GetSuppliesByIDs(int branchId, int productId)
        {
            return await _context.supplys.FindAsync(branchId, productId);
        }

        public Supply Update(Supply supply)
        {
            _context.Update(supply);
            _context.SaveChanges();

            return supply;
        }
    }
}
