using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveysAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "UserFavouriteFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "UserActivityRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "UserFavouriteFoods");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "UserActivityRatings");
        }
    }
}
