using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {

        // private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public GetByIdProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.productRepository.Get(x=>x.Id==request.Id);
            if (product is null)
            {
                throw new Exception("Product is Not Found");
            }
            var response = new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Task.FromResult(response);
        }
    }
}
