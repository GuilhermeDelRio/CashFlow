﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cashflow.Persistence;

#nullable disable

namespace cashflow.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cashflow.Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("[NVARCHAR](25)")
                        .HasColumnName("Category");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("[NVARCHAR](25)")
                        .HasColumnName("ExpenseName");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("[DATE]")
                        .HasColumnName("FinalDate");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("[DATE]")
                        .HasColumnName("InitialDate");

                    b.Property<string>("Recurrence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Recurrence");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("TB_Expenses", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
