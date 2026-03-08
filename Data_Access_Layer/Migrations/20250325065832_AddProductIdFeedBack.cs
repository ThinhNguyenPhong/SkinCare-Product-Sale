using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddProductIdFeedBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "Feedback",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ProductId1",
                table: "Feedback",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Product_ProductId1",
                table: "Feedback",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Product_ProductId1",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ProductId1",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Feedback");
        }
    }
}
