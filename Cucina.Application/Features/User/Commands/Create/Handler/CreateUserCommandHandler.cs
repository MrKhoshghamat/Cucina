using Cucina.Application.Features.Common;
using Cucina.Application.Features.User.Commands.Create.Model.Request;
using Cucina.Application.Features.User.Commands.Create.Model.Response;
using MediatR;

namespace Cucina.Application.Features.User.Commands.Create.Handler;

public class
    CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, HandlerResponse<CreateUserCommandResponse>>
{
    #region Private Members


    #endregion

    #region Constructor

    

    #endregion

    #region Handler

    public async Task<HandlerResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    #endregion
}