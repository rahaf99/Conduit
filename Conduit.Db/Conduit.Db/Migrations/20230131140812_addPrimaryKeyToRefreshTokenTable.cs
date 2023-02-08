using Conduit.Db.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conduit.Db.Migrations
{
    /// <inheritdoc />
    public partial class addPrimaryKeyToRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey("PK_RefreshTokens", "RefreshTokens", "UserId", null);
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                table: "RefreshTokens",
                name: "UserId"
                );

        }
    }
}
