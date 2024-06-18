using CashFlow.Application;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace Validators.Tests;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Description",
            Title = "Apple",
            PaymentType = PaymentType.CreditCard
        };

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
