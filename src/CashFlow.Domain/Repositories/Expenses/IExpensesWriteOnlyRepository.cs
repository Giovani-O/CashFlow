namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    public Task Add(Expense expense);
    
    /// <summary>
    /// This method return true if the deletion was successful, otherwise returns false
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> Delete(long id);
}
