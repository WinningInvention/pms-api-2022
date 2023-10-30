using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class outlierQueueInComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "OutlierQueueInComment",
                columns: table => new
                {
                    OutlierQueueInCommentId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutlierQueueInId = table.Column<int>(type: "INT", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_OutlierQueueInCommentId", x => x.OutlierQueueInCommentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "OutlierQueueInComment");
        }
    }
}
