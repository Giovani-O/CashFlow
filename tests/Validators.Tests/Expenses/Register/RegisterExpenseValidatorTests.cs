using CashFlow.Application;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Request;

namespace Validators.Tests;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
