using Clean_Architecture_CQRS_Docker.Application.CQRS.Commands.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Application.CQRS.Commands.Request;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}