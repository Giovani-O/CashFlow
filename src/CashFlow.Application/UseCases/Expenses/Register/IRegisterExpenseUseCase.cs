using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application;

public interface IRegisterExpenseUseCase
{
    ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request);
}
