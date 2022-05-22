
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}