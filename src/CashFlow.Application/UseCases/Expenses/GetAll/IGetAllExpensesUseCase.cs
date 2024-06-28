using CashFlow.Communication.Responses;

namespace CashFlow.Application;

public interface IGetAllExpensesUseCase
{
    public Task<ResponseExpensesJson> Execute();
}
