using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Cucina.Application.Features.Common;
using Cucina.Application.Features.User.Commands.Delete.Validation;
using Cucina.Domain;
using MediatR;

namespace Cucina.Application;

public class
    DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, HandlerResponse<DeleteUserCommandResponse>>
{
    #region PrivateMembers

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    #endregion

    #region Constructor

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    #region Handler

    public async Task<HandlerResponse<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var handlerResponse = new HandlerResponse<DeleteUserCommandResponse>();
        var validationRules = new DeleteUserValidator(_unitOfWork, _mapper);
        var validationResult = await validationRules.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            handlerResponse.IsSucceed = false;
            handlerResponse.Data = _mapper.Map<DeleteUserCommandResponse>(request);
            handlerResponse.Message = validationResult.Errors.FirstOrDefault()?.ErrorMessage;
            return handlerResponse;
        }

        var user = _mapper.Map<User>(request);
        var userRepository = _unitOfWork.GetRepository<User, Guid>();
        await userRepository?.DeleteAsync(user, cancellationToken)!;
        await _unitOfWork.SaveChangesAsync();

        handlerResponse.IsSucceed = true;
        handlerResponse.Data = _mapper.Map<DeleteUserCommandResponse>(request);
        handlerResponse.Message = Features.User.Commands.Delete.Handler.HandlerConsts.HandlerIsSucceedMessage;
        return handlerResponse;
    }

    #endregion
}