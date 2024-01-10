using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeBooking.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeBookingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBookingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBookingDay_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeBookingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeBookingDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBookingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBookingDetail_TimeBookingDay_TimeBookingDayId",
                        column: x => x.TimeBookingDayId,
                        principalTable: "TimeBookingDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBookingDay_UserId",
                table: "TimeBookingDay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeBookingDetail_TimeBookingDayId",
                table: "TimeBookingDetail",
                column: "TimeBookingDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeBookingDetail");

            migrationBuilder.DropTable(
                name: "TimeBookingDay");
        }
    }
}
