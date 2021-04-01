using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyLearningLTD.Data.Migrations
{
    public partial class ratingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorRatingTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TutorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Helpfulness = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    Professionalism = table.Column<int>(type: "int", nullable: false),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    OverAllRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorRatingTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorRatingTable");
        }
    }
}
