using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialChat.Repository.Migrations
{
    public partial class InitFinancialChatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialChatMessage",
                columns: table => new
                {
                    FinancialChatMessageIDNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MessageSentUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialChatMessage", x => x.FinancialChatMessageIDNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialChatMessage");
        }
    }
}
