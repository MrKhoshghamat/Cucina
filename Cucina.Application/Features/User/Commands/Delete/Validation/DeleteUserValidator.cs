using AutoMapper;
using Cucina.Domain;
using FluentValidation;

namespace Cucina.Application.Features.User.Commands.Delete.Validation;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserValidator(IUnitOfWork unitOfWork, IMapper mapper)
    {
        RuleFor(user => user.Id)
            .NotNull()
            .NotEmpty();
    }
}