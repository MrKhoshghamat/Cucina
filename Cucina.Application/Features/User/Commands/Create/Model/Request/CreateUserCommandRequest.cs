using Cucina.Application.Features.Common;
using Cucina.Application.Features.User.Commands.Create.Model.Response;
using MediatR;

namespace Cucina.Application.Features.User.Commands.Create.Model.Request;

public class CreateUserCommandRequest : IRequest<HandlerResponse<CreateUserCommandResponse>>
{
    public string PhoneNumber { get; set; }
    public string NationalNo { get; set; }
}