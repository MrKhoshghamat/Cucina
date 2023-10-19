using AutoMapper;
using Cucina.Application.Features.User.Commands.Create.Model.Request;
using Cucina.Domain;
using FluentValidation;
using PhoneNumbers;

namespace Cucina.Application.Features.User.Commands.Create.Validation;

public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
{
    #region Private Members

    

    #endregion

    #region Constructor and Rules

    public CreateUserValidator(IUnitOfWork unitOfWork, IMapper mapper)
    {
        RuleFor(user => user.PhoneNumber)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsValidPhoneNumber)
            .WithMessage(CreateUserValidationConst.IsPhoneNumberValidationMessage);
    }

    #endregion

    #region Private Methods

    private static Task<bool> IsValidPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
    {
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var number = phoneNumberUtil.Parse(phoneNumber, null);
        return Task.FromResult(phoneNumberUtil.IsValidNumber(number) &&
                               phoneNumberUtil.GetNumberType(number) == PhoneNumberType.MOBILE);
    }

    #endregion
}