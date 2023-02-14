using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProdId = table.Column<int>(name: "Prod_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(name: "Product_Name", type: "nvarchar(max)", nullable: true), 
                    ProdCost = table.Column<double>(name: "Prod_Cost", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProdId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(name: "Order_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(name: "Order_Date", type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(name: "Order_Status", type: "nvarchar(max)", nullable: true),
                    ProdId = table.Column<int>(name: "Prod_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Product_Prod_Id",
                        column: x => x.ProdId,
                        principalTable: "Product",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(name: "Customer_Name", type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(name: "Customer_Email", type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(name: "Customer_City", type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(name: "Order_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Order_Order_Id",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payement",
                columns: table => new
                {
                    PaymentId = table.Column<int>(name: "Payment_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<float>(name: "Payment_Amount", type: "real", nullable: false),
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payement", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payement_Customer_Customer_Id",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Order_Id",
                table: "Customer",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Prod_Id",
                table: "Order",
                column: "Prod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payement_Customer_Id",
                table: "Payement",
                column: "Customer_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payement");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
