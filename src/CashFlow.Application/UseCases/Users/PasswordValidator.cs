using System.Text.RegularExpressions;
using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;
using Irony;

namespace CashFlow.Application.UseCases.Users;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ErrorMessageKey = "ErrorMessage";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ErrorMessageKey}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (UpperCaseRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (LowerCaseRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (NumberRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (SpecialCharacterRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseRegex();
    
    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseRegex();
    
    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex NumberRegex();
    
    [GeneratedRegex(@"[\!\@\#\$\%\&\*\(\)\.]+")]
    private static partial Regex SpecialCharacterRegex();
}