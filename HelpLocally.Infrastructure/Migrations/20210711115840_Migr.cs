using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpLocally.Infrastructure.Migrations
{
    public partial class Migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OfferTypes",
                keyColumn: "Id",
                keyValue: new Guid("113e15ab-2eed-4f5d-86c3-1488a7ecdb2f"));

            migrationBuilder.DeleteData(
                table: "OfferTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d20639e-454d-4c9b-8738-e4e963d5202c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("25b42de0-d713-4a84-bb43-40da9c864398"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("780a059a-8191-470a-a3de-d37efe78dce8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d70f8fe0-7969-4e1d-a1aa-fafde83f2686"));

            migrationBuilder.InsertData(
                table: "OfferTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("edffbc4f-84af-4303-bf15-ec7e56c4fc19"), "Voucher type of offer", "Voucher" },
                    { new Guid("cd51444a-efcd-4933-9b38-473f9962394f"), "Standard product", "Product" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("84646cbc-096b-4d62-87b4-a5f5e550d9e1"), "Admin" },
                    { new Guid("bedc6651-217f-42f4-9ec5-03cdda53565a"), "Company" },
                    { new Guid("8553055f-86c2-488e-afb7-80862489a211"), "Customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OfferTypes",
                keyColumn: "Id",
                keyValue: new Guid("cd51444a-efcd-4933-9b38-473f9962394f"));

            migrationBuilder.DeleteData(
                table: "OfferTypes",
                keyColumn: "Id",
                keyValue: new Guid("edffbc4f-84af-4303-bf15-ec7e56c4fc19"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("84646cbc-096b-4d62-87b4-a5f5e550d9e1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8553055f-86c2-488e-afb7-80862489a211"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bedc6651-217f-42f4-9ec5-03cdda53565a"));

            migrationBuilder.InsertData(
                table: "OfferTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("113e15ab-2eed-4f5d-86c3-1488a7ecdb2f"), "Voucher type of offer", "Voucher" },
                    { new Guid("6d20639e-454d-4c9b-8738-e4e963d5202c"), "Standard product", "Product" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d70f8fe0-7969-4e1d-a1aa-fafde83f2686"), "Admin" },
                    { new Guid("25b42de0-d713-4a84-bb43-40da9c864398"), "Company" },
                    { new Guid("780a059a-8191-470a-a3de-d37efe78dce8"), "Customer" }
                });
        }
    }
}
