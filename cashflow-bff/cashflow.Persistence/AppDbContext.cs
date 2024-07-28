using cashflow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cashflow.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Expenses> Expenses { get; set; }
}
