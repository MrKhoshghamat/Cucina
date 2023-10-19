namespace Cucina.Application.Features.User.Commands.Create.Model.Response;

public class CreateUserCommandResponse
{
    public Guid Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NationalNo { get; set; }
}