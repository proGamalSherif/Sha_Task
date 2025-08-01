﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Cities",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cashier_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeader",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    Invoicedate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CashierID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeader", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Branches",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Cashier",
                        column: x => x.CashierID,
                        principalTable: "Cashier",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHeaderID = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    ItemCount = table.Column<double>(type: "float", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeader",
                        column: x => x.InvoiceHeaderID,
                        principalTable: "InvoiceHeader",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityID",
                table: "Branches",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cashier_BranchID",
                table: "Cashier",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderID",
                table: "InvoiceDetails",
                column: "InvoiceHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_BranchID",
                table: "InvoiceHeader",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_CashierID",
                table: "InvoiceHeader",
                column: "CashierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceHeader");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
