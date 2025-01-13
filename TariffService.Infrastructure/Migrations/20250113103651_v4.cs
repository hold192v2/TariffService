using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TariffService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TariffCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TempUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TariffId = table.Column<string>(type: "text", nullable: false),
                    NewPhone = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MinutePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    GigabytePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    SmsPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UnlimVideoPrice = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimSocialsPrice = table.Column<bool>(type: "boolean", nullable: false),
                    UnlimMusicPrice = table.Column<bool>(type: "boolean", nullable: false),
                    LongDistanceCallPrice = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrice", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicTariffs");

            migrationBuilder.DropTable(
                name: "StaticTariffs");

            migrationBuilder.DropTable(
                name: "TariffCarts");

            migrationBuilder.DropTable(
                name: "UnitPrice");
        }
    }
}
