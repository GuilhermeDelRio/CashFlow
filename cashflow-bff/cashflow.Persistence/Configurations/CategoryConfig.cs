using cashflow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cashflow.Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<CategoryModel>
{
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
        builder.ToTable("TB_Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CategoryName)
            .HasColumnName("CategoryName")
            .HasColumnType("[NVARCHAR](25)")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("[NVARCHAR](255)")
            .IsRequired();
    }
}
