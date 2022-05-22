using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.CommandHandlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    //private readonly AppDbContext _context;


    //public DeleteProductCommandHandler(AppDbContext context)
    //{
    //    _context = context;
    //}

    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        //var deleteProduct = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        //if(deleteProduct is null)
        //{
        //    throw new Exception("Product is Not Found");
        //}
        //_context.Products.Remove(deleteProduct);
        //await _context.SaveChangesAsync();

        await _unitOfWork.productRepository.DeleteProductAsync(request);
        await _unitOfWork.SaveAsync();
        return new DeleteProductCommandResponse
        {
            IsSuccess = true
        };
    }
}