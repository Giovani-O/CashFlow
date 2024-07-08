using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        ResponseMapper();
        RequestMapper();
        // ResponseToEntity();
        // EntityToResponse();
    }

    private void ResponseMapper()
    {
        CreateMap<ResponseRegisteredExpenseJson, Expense>().ReverseMap();
        CreateMap<Expense, ResponseShortExpenseJson>().ReverseMap();
        CreateMap<Expense, ResponseExpenseJson>().ReverseMap();
    }

    private void RequestMapper()
    {
        CreateMap<RequestExpenseJson, Expense>().ReverseMap();
    }

    // private void ResponseToEntity()
    // {
    //     CreateMap<ResponseRegisteredExpenseJson, Expense>();
    // }

    // private void EntityToResponse()
    // {
    //     CreateMap<Expense, ResponseRegisteredExpenseJson>();
    // }
}
