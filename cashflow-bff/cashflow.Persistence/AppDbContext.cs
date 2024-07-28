using cashflow.Domain.Entities;
using cashflow.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace cashflow.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ExpensesConfig());
    }

    public DbSet<Expense> Expenses { get; set; }
}
