using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
