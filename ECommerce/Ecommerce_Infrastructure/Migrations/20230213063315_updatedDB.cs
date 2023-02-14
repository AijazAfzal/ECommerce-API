using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Order_Order_Id",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Payement_Customer_Customer_Id",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Order_Id",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Payement",
                newName: "Order_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payement_Customer_Id",
                table: "Payement",
                newName: "IX_Payement_Order_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Payment_Date",
                table: "Payement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_Id",
                table: "Order",
                column: "Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_Customer_Id",
                table: "Order",
                column: "Customer_Id",
                principalTable: "Customer",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payement_Order_Order_Id",
                table: "Payement",
                column: "Order_Id",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_Customer_Id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Payement_Order_Order_Id",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Order_Customer_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Payment_Date",
                table: "Payement");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "Payement",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payement_Order_Id",
                table: "Payement",
                newName: "IX_Payement_Customer_Id");

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Order_Id",
                table: "Customer",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Order_Order_Id",
                table: "Customer",
                column: "Order_Id",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payement_Customer_Customer_Id",
                table: "Payement",
                column: "Customer_Id",
                principalTable: "Customer",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
