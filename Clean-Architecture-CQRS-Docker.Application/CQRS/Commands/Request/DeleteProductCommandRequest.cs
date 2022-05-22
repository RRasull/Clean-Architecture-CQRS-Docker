using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using MediatR;

namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public int Id { get; set; }
}