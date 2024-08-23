using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Login;

public class DoLoginUseCase(
    IUserReadOnlyRepository repository,
    IPasswordEncrypter passwordEncrypter,
    IAccessTokenGenerator accessTokenGenerator)
    : IDoLoginUseCase
{
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        Validate(request);
        
        var user = await repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }
        
        var passwordMatch = passwordEncrypter.Verify(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new InvalidLoginException();
        }
        
        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = accessTokenGenerator.Generate(user)
        };
    }

    private void Validate(RequestLoginJson request)
    {
        var result = new DoLoginValidator().Validate(request);
        
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}