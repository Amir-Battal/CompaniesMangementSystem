namespace APIs_Task.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);
            _context.SaveChanges();

            return product;
        }

        public Product Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public Product Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return product;
        }
    }
}
