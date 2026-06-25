using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healthcare.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("-- InitialCreate migration scaffolded for the Healthcare MVP schema. Run dotnet ef migrations remove/add in a .NET SDK environment to regenerate provider-specific DDL.");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
}
