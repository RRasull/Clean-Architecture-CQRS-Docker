using Clean_Architecture_CQRS_Docker.Application.Interfaces;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        // private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            // var products = await _context.Products.ToListAsync();
            var products = await _unitOfWork.productRepository.GetAllAsync();
            List<GetAllProductQueryResponse> productsResponse = new List<GetAllProductQueryResponse>();

            foreach (var item in products)
            {
                var model = new GetAllProductQueryResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                };
                productsResponse.Add(model);
            }

            return productsResponse;
        }
    }
}
