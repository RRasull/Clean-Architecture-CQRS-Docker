using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;
using Clean_Architecture_CQRS_Docker.Infrastructure.Implementations;

namespace Clean_Architecture_CQRS_Docker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context { get; }
        private IProductRepository _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository productRepository =>
            _productRepository = _productRepository ?? new ProductRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
