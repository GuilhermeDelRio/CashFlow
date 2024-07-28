using cashflow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cashflow.Persistence.Configurations;

public class ExpensesConfig : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("TB_Expenses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExpenseName)
            .HasColumnName("ExpenseName")
            .HasColumnType("[NVARCHAR](25)")
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnName("Value")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Category)
            .HasColumnName("Category")
            .HasColumnType("[NVARCHAR](25)")
            .IsRequired();

        builder.Property(x => x.Recurrence)
            .HasColumnName("Recurrence")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.InitialDate)
         .HasColumnName("InitialDate")
         .HasColumnType("[DATE]")
         .IsRequired();

        builder.Property(x => x.FinalDate)
         .HasColumnName("FinalDate")
         .HasColumnType("[DATE]")
         .IsRequired();
    }
}
