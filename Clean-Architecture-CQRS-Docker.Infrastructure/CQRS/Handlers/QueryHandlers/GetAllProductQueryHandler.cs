using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Response;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly AppDbContext _context;


        public GetAllProductQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
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
