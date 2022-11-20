using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vditechnicaltest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    MemberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberPoint = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistories", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistories");
        }
    }
}
