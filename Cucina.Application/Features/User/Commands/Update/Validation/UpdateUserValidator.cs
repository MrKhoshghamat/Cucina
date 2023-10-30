using AutoMapper;
using Cucina.Domain;
using FluentValidation;

namespace Cucina.Application.Features.User.Commands.Update.Validation;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserValidator(IUnitOfWork unitOfWork, IMapper mapper)
    {
        RuleFor(user => user.Id)
            .NotNull()
            .NotEmpty();
    }
}