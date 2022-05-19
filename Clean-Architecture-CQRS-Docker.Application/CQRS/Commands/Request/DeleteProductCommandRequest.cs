using Clean_Architecture_CQRS_Docker.Application.CQRS.Commands.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Application.CQRS.Commands.Request;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public int Id { get; set; }
}