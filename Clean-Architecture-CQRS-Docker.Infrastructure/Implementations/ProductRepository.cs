using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Domain.Entities;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private AppDbContext _context { get; }

    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<EntityEntry<Product>> CreateProductAsync(CreateProductCommandRequest request)
    {
        var product = await _context.Set<Product>().AddAsync(new Product
        {
            Name = request.Name,
            Price = request.Price
        });

        return product;

    }

    public async Task DeleteProductAsync(DeleteProductCommandRequest request)
    {
        var deleteProduct = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        if (deleteProduct is null)
        {
            throw new Exception("Product is Not Found");
        }
        _context.Products.Remove(deleteProduct);
    }
}