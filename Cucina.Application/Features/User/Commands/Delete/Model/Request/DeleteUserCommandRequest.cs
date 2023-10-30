using Cucina.Application.Features.Common;
using MediatR;

namespace Cucina.Application;

public class DeleteUserCommandRequest : IRequest<HandlerResponse<DeleteUserCommandResponse>>
{
    public Guid Id { get; set; }
}