using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationRepro.Migrations
{
    /// <inheritdoc />
    public partial class Additional : Migration
    {
        private const string sql = """
                                   DECLARE @ToDeletePredecessor AS TVP_BIGINT;
                                   """;
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
