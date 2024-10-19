﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evently.Modules.Users.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Update_user_with_identityId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "identity_id",
            schema: "users",
            table: "users",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            name: "ix_users_identity_id",
            schema: "users",
            table: "users",
            column: "identity_id",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_users_identity_id",
            schema: "users",
            table: "users");

        migrationBuilder.DropColumn(
            name: "identity_id",
            schema: "users",
            table: "users");
    }
}
