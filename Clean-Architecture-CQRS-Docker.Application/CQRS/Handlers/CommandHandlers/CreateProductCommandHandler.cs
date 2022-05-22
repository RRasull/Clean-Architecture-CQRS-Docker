using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using Clean_Architecture_CQRS_Docker.Domain.Entities;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        //var product = await _context.Products.AddAsync(new Product
        //{
        //    Name = request.Name,
        //    Price = request.Price
        //});

        //await _context.SaveChangesAsync();

        var product = await _unitOfWork.productRepository.CreateProductAsync(request);
        await _unitOfWork.SaveAsync();

        return new CreateProductCommandResponse
        {
            IsSuccess = true,
            ProductId = product.Entity.Id
        };
    }
}