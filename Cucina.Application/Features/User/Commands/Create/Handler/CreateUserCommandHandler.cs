using AutoMapper;
using Cucina.Application.Features.Common;
using Cucina.Application.Features.User.Commands.Create.Model.Request;
using Cucina.Application.Features.User.Commands.Create.Model.Response;
using Cucina.Application.Features.User.Commands.Create.Validation;
using Cucina.Domain;
using MediatR;

namespace Cucina.Application;

public class
    CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, HandlerResponse<CreateUserCommandResponse>>
{
    #region Private Members

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    #endregion

    #region Constructor

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    #region Handler

    public async Task<HandlerResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var handlerResponse = new HandlerResponse<CreateUserCommandResponse>();

        var validationRules = new CreateUserValidator(_unitOfWork, _mapper);

        var validationResult = await validationRules.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            handlerResponse.IsSucceed = false;
            handlerResponse.Data = _mapper.Map<CreateUserCommandResponse>(request);
            handlerResponse.Message = validationResult.Errors.FirstOrDefault()?.ErrorMessage;

            return handlerResponse;
        }

        var user = _mapper.Map<User>(request);

        var userRepository = _unitOfWork.GetRepository<User, Guid>();
        await userRepository?.CreateAsync(user, cancellationToken)!;
        
        await _unitOfWork.SaveChangesAsync();

        handlerResponse.IsSucceed = true;
        handlerResponse.Message = HandlerConsts.HandlerIsSucceedMessage;
        handlerResponse.Data = _mapper.Map<CreateUserCommandResponse>(request);

        return handlerResponse;

    }

    #endregion
}