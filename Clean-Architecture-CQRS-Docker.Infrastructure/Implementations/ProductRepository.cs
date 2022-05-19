using Clean_Architecture_CQRS_Docker.Domain.Entities;
using Clean_Architecture_CQRS_Docker.Domain.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private AppDbContext _context { get; }
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}