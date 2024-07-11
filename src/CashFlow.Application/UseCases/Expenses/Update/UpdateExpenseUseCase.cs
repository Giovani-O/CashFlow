using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update;

// Exemplo de construtor primário
public class UpdateExpenseUseCase(
    IMapper mapper, 
    IUnitOfWork unitOfWork, 
    IExpensesUpdateOnlyRepository repository) : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper = mapper;
    private readonly IExpensesUpdateOnlyRepository _repository = repository;

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);
        
        _repository.Update(expense);

        await unitOfWork.Commit();
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
            
    }
}