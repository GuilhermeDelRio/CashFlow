﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cashflow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseName = table.Column<string>(type: "[NVARCHAR](25)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "[NVARCHAR](25)", nullable: false),
                    Recurrence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "[DATE]", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "[DATE]", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Expenses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Expenses");
        }
    }
}
