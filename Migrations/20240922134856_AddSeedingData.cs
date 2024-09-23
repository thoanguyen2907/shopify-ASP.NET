using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Shopify.src.Entity;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopify.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:role", "admin,customer");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<Role>(type: "role", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    is_oauth = table.Column<bool>(type: "boolean", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    inventory = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_detail_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_detail_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1118eb3e-32b0-4510-b0a0-23f2d884c66f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toys", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1516cdd1-873e-49d0-a738-8319ca9da6fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40bb3fbd-40b1-492f-b7fc-867ee12386d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67f013b5-2bc3-46f9-8d79-a2eca059726c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports & Outdoors", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d9e7704-cc3b-4647-8008-3836c21c7f92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Groceries", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbb6d502-019b-4e32-839f-46f1c2fa5390"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beauty & Personal Care", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c57e98a6-0f06-42b0-8db3-e00c3bbf8a41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Furniture", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6f620c2-5c40-4254-8cd1-4478711d5a65"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "image", "is_oauth", "name", "password", "role", "salt", "updated_at" },
                values: new object[,]
                {
                    { new Guid("41273c5e-37bc-436e-a972-92efa09fa975"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nara.ng@example.com", "https://previews.123rf.com/images/danamayfay/danamayfay1909/danamayfay190900016/131686915-vector-female-character-in-cartoon-style-avatar-girl-in-a-circle-vector-illustration-isolated-on.jpg", false, "Nara", "DE-8D-F9-F0-75-0E-A1-98-0B-05-D1-06-55-17-DF-66-AF-1A-F1-91-77-EF-1C-9B-4D-7A-FA-A7-5B-82-F7-44", Role.Customer, new byte[] { 212, 0, 43, 223, 225, 209, 230, 235, 169, 51, 183, 115, 234, 52, 18, 5, 165, 157, 156, 22, 84, 226, 7, 65, 38, 185, 112, 169, 204, 209, 64, 73, 55, 236, 243, 136, 195, 171, 186, 229, 92, 209, 19, 23, 130, 228, 252, 175, 96, 243, 111, 70, 117, 23, 72, 175, 60, 35, 169, 136, 107, 7, 125, 98 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc5546b0-4c9e-48da-a743-7c67aaaa6317"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.ng@example.com", "https://png.pngtree.com/element_our/20200702/ourlarge/pngtree-girl-cute-cartoon-small-fresh-avatar-character-image_2297872.jpg", false, "Alice", "DE-8D-F9-F0-75-0E-A1-98-0B-05-D1-06-55-17-DF-66-AF-1A-F1-91-77-EF-1C-9B-4D-7A-FA-A7-5B-82-F7-44", Role.Admin, new byte[] { 212, 0, 43, 223, 225, 209, 230, 235, 169, 51, 183, 115, 234, 52, 18, 5, 165, 157, 156, 22, 84, 226, 7, 65, 38, 185, 112, 169, 204, 209, 64, 73, 55, 236, 243, 136, 195, 171, 186, 229, 92, 209, 19, 23, 130, 228, 252, 175, 96, 243, 111, 70, 117, 23, 72, 175, 60, 35, 169, 136, 107, 7, 125, 98 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "created_at", "description", "inventory", "name", "price", "updated_at" },
                values: new object[,]
                {
                    { new Guid("208388f2-236b-4779-8507-e31dc11f00a2"), new Guid("7d9e7704-cc3b-4647-8008-3836c21c7f92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fresh organic apples", 500, "Organic Apples", 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3298d6df-ae1b-494c-8dfd-bbe8759523c0"), new Guid("bbb6d502-019b-4e32-839f-46f1c2fa5390"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hair care shampoo", 400, "Shampoo", 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35da8f29-95d8-43f2-a14b-5e93a06f782b"), new Guid("c6f620c2-5c40-4254-8cd1-4478711d5a65"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cotton t-shirt", 300, "T-shirt", 20.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4dd93cac-7225-4c64-9b73-68e7be296c40"), new Guid("1516cdd1-873e-49d0-a738-8319ca9da6fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latest model smartphone", 100, "Smartphone", 800.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("683145bc-8065-4a64-989d-619729a63e8e"), new Guid("67f013b5-2bc3-46f9-8d79-a2eca059726c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional tennis racket", 70, "Tennis Racket", 120.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69c76a22-c846-4414-879c-00e66b3058e9"), new Guid("1516cdd1-873e-49d0-a738-8319ca9da6fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-performance laptop", 50, "Laptop", 1200.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75917299-84fc-45f9-8cb9-deb51a1183f8"), new Guid("40bb3fbd-40b1-492f-b7fc-867ee12386d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comprehensive guide to C#", 200, "C# Programming", 40.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd1d5cf7-488d-4067-bb3b-475ad9b86d1d"), new Guid("c57e98a6-0f06-42b0-8db3-e00c3bbf8a41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable sofa", 30, "Sofa", 700.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9442d8b-3a8d-406f-98ee-1f680d955ccc"), new Guid("1118eb3e-32b0-4510-b0a0-23f2d884c66f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remote-controlled car", 60, "Toy Car", 45.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f35ce314-4537-4d98-9c01-3bdb4badd95d"), new Guid("40bb3fbd-40b1-492f-b7fc-867ee12386d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn ASP.NET Core", 150, "ASP.NET Core Guide", 50.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_detail_order_id",
                table: "order_detail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_detail_product_id",
                table: "order_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
