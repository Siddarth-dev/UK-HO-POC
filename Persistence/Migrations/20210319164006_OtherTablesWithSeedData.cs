using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class OtherTablesWithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchAttributeId",
                table: "Batches");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Batches",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "BatchPublishedDate",
                table: "Batches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BatchStatusId",
                table: "Batches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Batches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Batches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Acls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    BatchId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acls_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    BatchId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchAttributes_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BatchStatusId",
                table: "Batches",
                column: "BatchStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BusinessUnitId",
                table: "Batches",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Acls_BatchId",
                table: "Acls",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchAttributes_BatchId",
                table: "BatchAttributes",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_BatchStatus_BatchStatusId",
                table: "Batches",
                column: "BatchStatusId",
                principalTable: "BatchStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_BusinessUnities_BusinessUnitId",
                table: "Batches",
                column: "BusinessUnitId",
                principalTable: "BusinessUnities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_BatchStatus_BatchStatusId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_BusinessUnities_BusinessUnitId",
                table: "Batches");

            migrationBuilder.DropTable(
                name: "Acls");

            migrationBuilder.DropTable(
                name: "BatchAttributes");

            migrationBuilder.DropTable(
                name: "BatchStatus");

            migrationBuilder.DropTable(
                name: "BusinessUnities");

            migrationBuilder.DropIndex(
                name: "IX_Batches_BatchStatusId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_BusinessUnitId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "BatchPublishedDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "BatchStatusId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Batches");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessUnitId",
                table: "Batches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatchAttributeId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
