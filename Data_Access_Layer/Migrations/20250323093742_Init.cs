using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__23CAF1D80D045828", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    promotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__99EB696E792C7FF3", x => x.promotionId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__CD98462A4B269C18", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__2D10D16A8537E9D8", x => x.productId);
                    table.ForeignKey(
                        name: "FK__Product__categor__5BE2A6F2",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "categoryId");
                });

            migrationBuilder.CreateTable(
                name: "Promotion_Detail",
                columns: table => new
                {
                    promotionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promotionId = table.Column<int>(type: "int", nullable: true),
                    detailDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__74CA3CF1D2EEDDBF", x => x.promotionDetailId);
                    table.ForeignKey(
                        name: "FK__Promotion__promo__74AE54BC",
                        column: x => x.promotionId,
                        principalTable: "Promotion",
                        principalColumn: "promotionId");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__F267251E4DAEF09E", x => x.accountId);
                    table.ForeignKey(
                        name: "FK__Account__roleId__4BAC3F29",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Image__336E9B559269C996", x => x.imageId);
                    table.ForeignKey(
                        name: "FK__Image__productId__5EBF139D",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "Product_Promotion",
                columns: table => new
                {
                    productPromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    promotionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___3F1B3D11EDCBEC9A", x => x.productPromotionId);
                    table.ForeignKey(
                        name: "FK__Product_P__produ__778AC167",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId");
                    table.ForeignKey(
                        name: "FK__Product_P__promo__787EE5A0",
                        column: x => x.promotionId,
                        principalTable: "Promotion",
                        principalColumn: "promotionId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__415B03B8F725E603", x => x.cartId);
                    table.ForeignKey(
                        name: "FK__Cart__accountId__619B8048",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__B611CB7DA35A0B5D", x => x.customerId);
                    table.ForeignKey(
                        name: "FK__Customer__accoun__4E88ABD4",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C134C9C1F2DDE5B8", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK__Employee__accoun__5165187F",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__2613FD24B05CC7C6", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK__Feedback__accoun__6EF57B66",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__0809335D65E1E68A", x => x.orderId);
                    table.ForeignKey(
                        name: "FK__Order__accountId__68487DD7",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    pointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Point__4CB435AEA4B2E229", x => x.pointId);
                    table.ForeignKey(
                        name: "FK__Point__accountId__571DF1D5",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Item",
                columns: table => new
                {
                    cartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_Ite__283983B6220EF485", x => x.cartItemId);
                    table.ForeignKey(
                        name: "FK__Cart_Item__cartI__6477ECF3",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "cartId");
                    table.ForeignKey(
                        name: "FK__Cart_Item__produ__656C112C",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    newsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__5218041E4AAEFF92", x => x.newsId);
                    table.ForeignKey(
                        name: "FK__News__employeeId__5441852A",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "employeeId");
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    orderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_De__E4FEDE4A234C9FC4", x => x.orderDetailId);
                    table.ForeignKey(
                        name: "FK__Order_Det__order__6B24EA82",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId");
                    table.ForeignKey(
                        name: "FK__Order_Det__produ__6C190EBB",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "Order_Promotion",
                columns: table => new
                {
                    orderPromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    promotionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_Pr__69F6C47326D5E729", x => x.orderPromotionId);
                    table.ForeignKey(
                        name: "FK__Order_Pro__order__7B5B524B",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId");
                    table.ForeignKey(
                        name: "FK__Order_Pro__promo__7C4F7684",
                        column: x => x.promotionId,
                        principalTable: "Promotion",
                        principalColumn: "promotionId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    paymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__A0D9EFC67F613395", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK__Payment__orderId__7F2BE32F",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_roleId",
                table: "Account",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_accountId",
                table: "Cart",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_cartId",
                table: "Cart_Item",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_productId",
                table: "Cart_Item",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_accountId",
                table: "Customer",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_accountId",
                table: "Employee",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_accountId",
                table: "Feedback",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_productId",
                table: "Image",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_News_employeeId",
                table: "News",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_accountId",
                table: "Order",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_orderId",
                table: "Order_Detail",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_productId",
                table: "Order_Detail",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Promotion_orderId",
                table: "Order_Promotion",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Promotion_promotionId",
                table: "Order_Promotion",
                column: "promotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_orderId",
                table: "Payment",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_accountId",
                table: "Point",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Promotion_productId",
                table: "Product_Promotion",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Promotion_promotionId",
                table: "Product_Promotion",
                column: "promotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_Detail_promotionId",
                table: "Promotion_Detail",
                column: "promotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Item");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "Order_Promotion");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Product_Promotion");

            migrationBuilder.DropTable(
                name: "Promotion_Detail");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
