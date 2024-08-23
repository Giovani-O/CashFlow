using System.Text.RegularExpressions;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Login;

public class DoLoginValidator : AbstractValidator<RequestLoginJson>
{
    public DoLoginValidator()
    {
        RuleFor(request => request.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
            .EmailAddress()
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(request => request.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD)
            .MinimumLength(8)
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD)
            .Matches("[A-Z]+")
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD)
            .Matches("[a-z]+")
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD)
            .Matches("[0-9]+")
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD)
            .Matches("[!@#$%&*().]+")
            .WithMessage(ResourceErrorMessages.INVALID_PASSWORD);
    }
}
