using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request) {
        Validate(request);
        
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request) {
        var isTitleEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (isTitleEmpty)
            throw new ArgumentException("The title is required,");

        if (request.Amount <= 0)
            throw new ArgumentException("The amount must be greater than zero");
        
        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0)
            throw new ArgumentException("Expenses cannot be in the future.");

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymenType);
        if (!paymentTypeIsValid)
            throw new ArgumentException("The informed payment type is invalid.");
    }
}