using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
