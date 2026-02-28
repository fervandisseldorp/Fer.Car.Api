using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fer.Car.Repository.Migrations;

/// <inheritdoc />
public partial class AddPgcryptoExtension : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            "CREATE EXTENSION IF NOT EXISTS \"pgcrypto\";");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Cars",
            type: "uuid",
            nullable: false,
            defaultValueSql: "gen_random_uuid()",
            oldClrType: typeof(Guid),
            oldType: "uuid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            "DROP EXTENSION IF EXISTS \"pgcrypto\";");

        migrationBuilder.AlterColumn<Guid>(
            name: "Id",
            table: "Cars",
            type: "uuid",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldDefaultValueSql: "gen_random_uuid()");
    }
}
