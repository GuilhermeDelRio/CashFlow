using AutoMapper;
using cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;
using cashflow.Application.UseCases.Expenses.Commands.UpdateExpenses;
using cashflow.Application.UseCases.Expenses.Reponses;
using cashflow.Domain.Entities;

namespace cashflow.Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Expenses
        CreateMap<CreateExpenseRequest, Expense>();
        CreateMap<Expense, ExpenseResponse>().ReverseMap();
        CreateMap<Expense, UpdateExpenseCommand>().ReverseMap();
    }
}
