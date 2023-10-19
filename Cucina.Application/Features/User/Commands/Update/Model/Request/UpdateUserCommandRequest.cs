using Cucina.Application.Features.Common;
using MediatR;

namespace Cucina.Application;

public class UpdateUserCommandRequest : IRequest<HandlerResponse<UpdateUserCommandResponse>>
{
    public Guid Id { get; set; }
}