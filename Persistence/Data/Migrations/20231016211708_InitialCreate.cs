using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "laboratory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaboratoryIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicine_laboratory_LaboratoryIdFk",
                        column: x => x.LaboratoryIdFk,
                        principalTable: "laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicine_sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicine_sale_owner_OwnerIdFk",
                        column: x => x.OwnerIdFk,
                        principalTable: "owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinarian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecializationIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinarian_Specialization_SpecializationIdFk",
                        column: x => x.SpecializationIdFk,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeciesIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breed_species_SpeciesIdFk",
                        column: x => x.SpeciesIdFk,
                        principalTable: "species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicine_purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicine_purchase_supplier_SupplierIdFk",
                        column: x => x.SupplierIdFk,
                        principalTable: "supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user-role",
                columns: table => new
                {
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    RoleIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user-role", x => new { x.UserIdFk, x.RoleIdFk });
                    table.ForeignKey(
                        name: "FK_user-role_role_RoleIdFk",
                        column: x => x.RoleIdFk,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user-role_user_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sale_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IdMedicineSaleFk = table.Column<int>(type: "int", nullable: false),
                    MedicineIdFk = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sale_detail_medicine_MedicineIdFk",
                        column: x => x.MedicineIdFk,
                        principalTable: "medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sale_detail_medicine_sale_IdMedicineSaleFk",
                        column: x => x.IdMedicineSaleFk,
                        principalTable: "medicine_sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerIdFk = table.Column<int>(type: "int", nullable: false),
                    BreedIdFk = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pet_breed_BreedIdFk",
                        column: x => x.BreedIdFk,
                        principalTable: "breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_owner_OwnerIdFk",
                        column: x => x.OwnerIdFk,
                        principalTable: "owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "purchase_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IdMedicinePurchaseFk = table.Column<int>(type: "int", nullable: false),
                    MedicineIdFk = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchase_detail_medicine_MedicineIdFk",
                        column: x => x.MedicineIdFk,
                        principalTable: "medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_detail_medicine_purchase_IdMedicinePurchaseFk",
                        column: x => x.IdMedicinePurchaseFk,
                        principalTable: "medicine_purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PetIdFk = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Reason = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VetIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointment_Veterinarian_VetIdFk",
                        column: x => x.VetIdFk,
                        principalTable: "Veterinarian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_pet_PetIdFk",
                        column: x => x.PetIdFk,
                        principalTable: "pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppointmentIdFk = table.Column<int>(type: "int", nullable: false),
                    MedicineIdFk = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdministrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Observation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medical_treatment_appointment_AppointmentIdFk",
                        column: x => x.AppointmentIdFk,
                        principalTable: "appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medical_treatment_medicine_MedicineIdFk",
                        column: x => x.MedicineIdFk,
                        principalTable: "medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cirujia Vascular" },
                    { 2, "Cardiologia" }
                });

            migrationBuilder.InsertData(
                table: "laboratory",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[] { 1, "Calle 23 # 23-34", "Genfar", "31311" });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { 1, "nicolas@google.com", "Nicolas", "12321" });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Canino" },
                    { 2, "Felino" }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Calle 12 # 12 -43", "UNIONAGRO S A", "12323" },
                    { 2, "Calle 12 # 12 -43", "Pet Pharma", "12323" }
                });

            migrationBuilder.InsertData(
                table: "Veterinarian",
                columns: new[] { "Id", "Email", "Name", "Phone", "SpecializationIdFk" },
                values: new object[] { 1, "adas@qw", "Juan", "12332", 1 });

            migrationBuilder.InsertData(
                table: "breed",
                columns: new[] { "Id", "Name", "SpeciesIdFk" },
                values: new object[,]
                {
                    { 1, "Golden Retriever", 1 },
                    { 2, "Cocker Spaniel", 1 }
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "Id", "LaboratoryIdFk", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Amoxicilina", 12000m, 100 },
                    { 2, 1, "Gentamicina", 15000m, 100 }
                });

            migrationBuilder.InsertData(
                table: "medicine_purchase",
                columns: new[] { "Id", "Date", "SupplierIdFk", "Total" },
                values: new object[] { 1, new DateOnly(2023, 12, 22), 1, 12000m });

            migrationBuilder.InsertData(
                table: "medicine_sale",
                columns: new[] { "Id", "Date", "OwnerIdFk", "Total" },
                values: new object[] { 1, new DateOnly(2023, 12, 22), 1, 15000m });

            migrationBuilder.InsertData(
                table: "pet",
                columns: new[] { "Id", "BirthDate", "BreedIdFk", "Name", "OwnerIdFk" },
                values: new object[,]
                {
                    { 1, new DateOnly(2016, 4, 20), 2, "Oliver", 1 },
                    { 2, new DateOnly(2020, 3, 12), 1, "Paco", 1 }
                });

            migrationBuilder.InsertData(
                table: "purchase_detail",
                columns: new[] { "Id", "IdMedicinePurchaseFk", "MedicineIdFk", "Quantity", "Subtotal" },
                values: new object[] { 1, 1, 1, 1, 12000m });

            migrationBuilder.InsertData(
                table: "sale_detail",
                columns: new[] { "Id", "IdMedicineSaleFk", "MedicineIdFk", "Quantity", "Subtotal" },
                values: new object[] { 1, 1, 2, 1, 15000m });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "Id", "Date", "PetIdFk", "Reason", "Time", "VetIdFk" },
                values: new object[] { 1, new DateOnly(2023, 3, 12), 2, "vacunacion", new TimeOnly(10, 30, 0), 1 });

            migrationBuilder.InsertData(
                table: "medical_treatment",
                columns: new[] { "Id", "AdministrationDate", "AppointmentIdFk", "Dose", "MedicineIdFk", "Observation" },
                values: new object[] { 1, new DateOnly(2023, 10, 12), 1, "12 mg", 1, "Todo OK" });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PetIdFk",
                table: "appointment",
                column: "PetIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_VetIdFk",
                table: "appointment",
                column: "VetIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_breed_SpeciesIdFk",
                table: "breed",
                column: "SpeciesIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medical_treatment_AppointmentIdFk",
                table: "medical_treatment",
                column: "AppointmentIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medical_treatment_MedicineIdFk",
                table: "medical_treatment",
                column: "MedicineIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_LaboratoryIdFk",
                table: "medicine",
                column: "LaboratoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_purchase_SupplierIdFk",
                table: "medicine_purchase",
                column: "SupplierIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicine_sale_OwnerIdFk",
                table: "medicine_sale",
                column: "OwnerIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_pet_BreedIdFk",
                table: "pet",
                column: "BreedIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_pet_OwnerIdFk",
                table: "pet",
                column: "OwnerIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_detail_IdMedicinePurchaseFk",
                table: "purchase_detail",
                column: "IdMedicinePurchaseFk");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_detail_MedicineIdFk",
                table: "purchase_detail",
                column: "MedicineIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_detail_IdMedicineSaleFk",
                table: "sale_detail",
                column: "IdMedicineSaleFk");

            migrationBuilder.CreateIndex(
                name: "IX_sale_detail_MedicineIdFk",
                table: "sale_detail",
                column: "MedicineIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_user-role_RoleIdFk",
                table: "user-role",
                column: "RoleIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarian_SpecializationIdFk",
                table: "Veterinarian",
                column: "SpecializationIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medical_treatment");

            migrationBuilder.DropTable(
                name: "purchase_detail");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "sale_detail");

            migrationBuilder.DropTable(
                name: "user-role");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "medicine_purchase");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "medicine_sale");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Veterinarian");

            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "laboratory");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
