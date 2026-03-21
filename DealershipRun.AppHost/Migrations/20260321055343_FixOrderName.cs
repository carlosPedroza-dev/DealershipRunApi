using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealershipRun.AppHost.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordersL_cars_car_id",
                table: "ordersL");

            migrationBuilder.DropForeignKey(
                name: "FK_ordersL_users_user_id",
                table: "ordersL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ordersL",
                table: "ordersL");

            migrationBuilder.RenameTable(
                name: "ordersL",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_ordersL_user_id",
                table: "orders",
                newName: "IX_orders_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ordersL_car_id",
                table: "orders",
                newName: "IX_orders_car_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_cars_car_id",
                table: "orders",
                column: "car_id",
                principalTable: "cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_cars_car_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "ordersL");

            migrationBuilder.RenameIndex(
                name: "IX_orders_user_id",
                table: "ordersL",
                newName: "IX_ordersL_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_car_id",
                table: "ordersL",
                newName: "IX_ordersL_car_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ordersL",
                table: "ordersL",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ordersL_cars_car_id",
                table: "ordersL",
                column: "car_id",
                principalTable: "cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ordersL_users_user_id",
                table: "ordersL",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
