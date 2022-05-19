namespace Clean_Architecture_CQRS_Docker.Application.CQRS.Commands.Response;

public class CreateProductCommandResponse
{
    public bool IsSuccess { get; set; }
    public int ProductId { get; set; }
}