using AutoMapper;
using Cucina.Application.Features.Common;
using Cucina.Application.Features.User.Commands.Update.Validation;
using Cucina.Domain;
using MediatR;

namespace Cucina.Application;

public class
    UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, HandlerResponse<UpdateUserCommandResponse>>
{
    #region privateMember

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    #endregion

    #region Consructor

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    #region Handler

    public async Task<HandlerResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var handlerResponse = new HandlerResponse<UpdateUserCommandResponse>();
        var validationRules = new UpdateUserValidator(_unitOfWork, _mapper);
        var validationResult = await validationRules.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            handlerResponse.IsSucceed = false;
            handlerResponse.Data = _mapper.Map<UpdateUserCommandResponse>(request);
            handlerResponse.Message = validationResult.Errors.FirstOrDefault()?.ErrorMessage;
            return handlerResponse;
        }

        var user = _mapper.Map<User>(request);
        var userRepository = _unitOfWork.GetRepository<User, Guid>();
        await userRepository?.UpdateAsync(user, cancellationToken)!;

        handlerResponse.IsSucceed = true;
        handlerResponse.Data = _mapper.Map<UpdateUserCommandResponse>(request);
        handlerResponse.Message = Features.User.Commands.Update.Handler.HandlerConsts.HandlerIsSucceedMessage;

        return handlerResponse;
    }

    #endregion
}