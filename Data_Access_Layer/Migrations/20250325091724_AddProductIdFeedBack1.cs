using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddProductIdFeedBack1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Product_ProductId1",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ProductId1",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Feedback");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Feedback",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ProductId",
                table: "Feedback",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Product",
                table: "Feedback",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Product",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ProductId",
                table: "Feedback");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Feedback",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

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
    }
}
