using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationRepro.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        private const string sql = """
                                   IF TYPE_ID(N'TVP_BigInt') IS NULL
                                   CREATE TYPE TVP_BigInt AS TABLE  (
                                       [Value] BIGINT,
                                       PRIMARY KEY ([Value])
                                   )
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
