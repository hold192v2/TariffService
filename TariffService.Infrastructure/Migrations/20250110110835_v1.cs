using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TariffService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicTariffs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Minutes = table.Column<decimal>(type: "numeric", nullable: false),
                    Gigabytes = table.Column<decimal>(type: "numeric", nullable: false),
                    Sms = table.Column<decimal>(type: "numeric", nullable: false),
                    UnlimVideo = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimSocials = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimMusic = table.Column<bool>(type: "boolean", nullable: false),
                    LongDistanceCall = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticTariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Minutes = table.Column<decimal>(type: "numeric", nullable: false),
                    Gigabytes = table.Column<decimal>(type: "numeric", nullable: false),
                    Sms = table.Column<decimal>(type: "numeric", nullable: false),
                    UnlimVideo = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimSocials = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimMusic = table.Column<bool>(type: "boolean", nullable: false),
                    LongDistanceCall = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticTariffs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicTariffs");

            migrationBuilder.DropTable(
                name: "StaticTariffs");
        }
    }
}
