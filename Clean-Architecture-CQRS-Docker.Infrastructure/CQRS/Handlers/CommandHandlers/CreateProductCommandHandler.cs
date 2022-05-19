using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using Clean_Architecture_CQRS_Docker.Domain.Entities;

using MediatR;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly AppDbContext _context;


    public CreateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.AddAsync(new Product
        {
            Name = request.Name,
            Price = request.Price
        });
        await _context.SaveChangesAsync();
        return new CreateProductCommandResponse
        {
            IsSuccess = true,
            ProductId = product.Entity.Id
        };
    }
}