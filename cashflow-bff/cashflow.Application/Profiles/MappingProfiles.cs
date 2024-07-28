using AutoMapper;
using cashflow.Application.UseCases.Expenses.Commands.CreateExpenses;
using cashflow.Domain.Entities;

namespace cashflow.Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Expenses
        CreateMap<CreateExpenseRequest, Expense>();
        CreateMap<Expense, CreateExpenseResponse>();
    }
}
