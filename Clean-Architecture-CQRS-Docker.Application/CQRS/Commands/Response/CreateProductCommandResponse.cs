namespace Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;

public class CreateProductCommandResponse
{
    public bool IsSuccess { get; set; }
    public int ProductId { get; set; }
}