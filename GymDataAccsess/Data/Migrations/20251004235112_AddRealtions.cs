using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymDataAccsess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRealtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HealthRecordUpdate",
                table: "Members",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<decimal>(
                name: "HealthRecord_Height",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HealthRecord_Notes",
                table: "Members",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HealthRecord_Weight",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "membersBookingSessions",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    IsAttended = table.Column<bool>(type: "bit", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membersBookingSessions", x => new { x.SessionId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_membersBookingSessions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membersBookingSessions_sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberShips",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShips", x => new { x.PlanId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_MemberShips_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberShips_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessions_CategoryId",
                table: "sessions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_TrainerId",
                table: "sessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_membersBookingSessions_MemberId",
                table: "membersBookingSessions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_MemberId",
                table: "MemberShips",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_categories_CategoryId",
                table: "sessions",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_trainers_TrainerId",
                table: "sessions",
                column: "TrainerId",
                principalTable: "trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessions_categories_CategoryId",
                table: "sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_trainers_TrainerId",
                table: "sessions");

            migrationBuilder.DropTable(
                name: "membersBookingSessions");

            migrationBuilder.DropTable(
                name: "MemberShips");

            migrationBuilder.DropIndex(
                name: "IX_sessions_CategoryId",
                table: "sessions");

            migrationBuilder.DropIndex(
                name: "IX_sessions_TrainerId",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "HealthRecordUpdate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Height",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Notes",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HealthRecord_Weight",
                table: "Members");
        }
    }
}
