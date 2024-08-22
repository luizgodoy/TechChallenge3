using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechChallenge.Data.Migrations
{
    /// <inheritdoc />
    public partial class TechChallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TechChallenge");

            migrationBuilder.CreateTable(
                name: "State",
                schema: "TechChallenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "TechChallenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "TechChallenge",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "TechChallenge",
                table: "State",
                columns: new[] { "Id", "DDD", "Name" },
                values: new object[,]
                {
                    { new Guid("10e26e10-331a-43b0-8312-16e85f013820"), 28, "Espírito Santo" },
                    { new Guid("17753136-39e0-4592-aca5-93f2d536f767"), 97, "Amazonas" },
                    { new Guid("18729586-fd1e-4613-b5a5-b27d80171322"), 19, "São Paulo" },
                    { new Guid("1b7193d5-a83a-4ab5-b2cf-7d07c75416b8"), 96, "Amapá" },
                    { new Guid("1d94638e-b1b9-4f32-a052-c0a2f4297c12"), 75, "Bahia" },
                    { new Guid("1f6e436c-04e9-42b6-91e2-aebe8773b4ef"), 33, "Minas Gerais" },
                    { new Guid("206b5235-9768-4268-8fc2-22d804cf5d53"), 65, "Mato Grosso" },
                    { new Guid("246bb6d9-f67e-42a5-ad35-f03f062e12a6"), 95, "Roraima" },
                    { new Guid("24f07ea5-9a36-46e2-ae6c-7f7d273bb7aa"), 14, "Bauru" },
                    { new Guid("26495868-993e-44b8-b7eb-1d636783a61d"), 34, "Minas Gerais" },
                    { new Guid("2a98b12d-e0b5-4e63-9be4-888540a43545"), 24, "Rio de Janeiro" },
                    { new Guid("2b692122-aede-477a-afad-3cf346d5935a"), 77, "Bahia" },
                    { new Guid("2c3bcd63-f6dc-44e3-94e7-fbf7c811fc1c"), 94, "Pará" },
                    { new Guid("2d2c8946-b2b1-4a9d-bdbd-1499f9876d01"), 81, "Pernambuco" },
                    { new Guid("2d591927-758d-4868-be77-9566d3a12728"), 88, "Ceará" },
                    { new Guid("31ab3648-7e72-4fdc-81f0-6b1f71d6c834"), 93, "Pará" },
                    { new Guid("32d395d8-0bd3-4938-bd50-02debc7aa493"), 63, "Tocantins" },
                    { new Guid("3a209058-3fa6-491c-918e-5ea0eb359824"), 37, "Minas Gerais" },
                    { new Guid("3bcb5933-e8b4-47fe-ac09-556386d90df8"), 41, "Paraná" },
                    { new Guid("3bf9db6c-9c38-4eea-9223-2476276ac1b6"), 11, "São Paulo" },
                    { new Guid("3c42154c-abd4-49a1-b4ee-0a29a181b4da"), 44, "Paraná" },
                    { new Guid("41334dfa-e03a-4c82-a8f8-f2a3318da710"), 79, "Sergipe" },
                    { new Guid("424f5729-f346-42ef-a4d3-74534d15beef"), 99, "Maranhão" },
                    { new Guid("4af95538-6ca3-454e-b899-3aea7ad90b47"), 32, "Minas Gerais" },
                    { new Guid("5ca01f72-70b2-4c6a-9c54-140024a17af1"), 98, "Maranhão" },
                    { new Guid("5cfa9857-5e67-460f-a093-b4366cea3398"), 47, "Santa Catarina" },
                    { new Guid("5e9d31b6-ac64-4f70-bda2-f7ef1333a0b5"), 54, "Rio Grande do Sul" },
                    { new Guid("633f319b-ddc3-48ae-ae40-7412c3e9f872"), 61, "Distrito Federal" },
                    { new Guid("7274da2e-9841-46de-b2cd-50b84079727c"), 92, "Amazonas" },
                    { new Guid("748d975f-cf68-4d65-a961-6b8e95e9e096"), 66, "Mato Grosso" },
                    { new Guid("7703675a-aebd-402e-8a73-0377e918825f"), 73, "Bahia" },
                    { new Guid("78b528e2-5f03-436c-b5e8-a5b019c5337e"), 51, "Rio Grande do Sul" },
                    { new Guid("79a7e486-7cf1-4626-9161-5ca80a28763c"), 87, "Pernambuco" },
                    { new Guid("7fdc504e-73fd-4781-99cc-d1bb9169e70e"), 48, "Santa Catarina" },
                    { new Guid("801c43e2-248d-428e-88b0-eb57ae565a9e"), 86, "Piauí" },
                    { new Guid("83970506-ef79-4d3a-b36a-a03471537257"), 17, "São Paulo" },
                    { new Guid("88d05483-e490-4e6e-b62e-bf9c07719933"), 62, "Goiás" },
                    { new Guid("890f1d75-a389-4487-860f-a7e0db004d48"), 55, "Rio Grande do Sul" },
                    { new Guid("8c9b87f6-91a0-4593-896f-0240b25231b1"), 49, "Santa Catarina" },
                    { new Guid("914de0b0-209c-4ad9-8d8a-8723b72a2c79"), 21, "Rio de Janeiro" },
                    { new Guid("9371cedd-97d4-4d4e-b398-82a7b1b337a2"), 84, "Rio Grande do Norte" },
                    { new Guid("93c134a8-51ee-4d40-a39a-8ef437fd1ebd"), 82, "Alagoas" },
                    { new Guid("9979754d-9509-4da9-977e-a131d1ac0eaf"), 43, "Paraná" },
                    { new Guid("9a377066-cb29-4806-8a59-6835d49618a8"), 16, "São Carlos" },
                    { new Guid("9afb4914-428e-4655-bd53-bc2340c958d9"), 91, "Pará" },
                    { new Guid("a423e610-41f2-415d-8443-1aa414c01905"), 42, "Paraná" },
                    { new Guid("b82bb752-0fb4-43f2-ba47-775579312ea8"), 31, "Minas Gerais" },
                    { new Guid("ba26ed12-76f0-4093-96d2-3ff478eef6e4"), 71, "Bahia" },
                    { new Guid("be5ae194-f1df-41e5-a5ed-8b274bddace8"), 15, "São Paulo" },
                    { new Guid("c3a4ffb2-efb5-41d3-838f-10364c3a64cd"), 67, "Mato Grosso do Sul" },
                    { new Guid("c4247d1c-4375-48a2-a639-5adfea74d299"), 35, "Minas Gerais" },
                    { new Guid("c490578b-040c-49f3-8759-fe98e9d94589"), 83, "Paraíba" },
                    { new Guid("c56b895d-0e4b-4955-b167-936df8e35d8c"), 69, "Rondônia" },
                    { new Guid("cb934fbb-d2bd-4860-8546-cc84c960b54d"), 18, "Presidente Prudente" },
                    { new Guid("cdccbf39-6484-4460-b47c-a47b7e97f44d"), 85, "Ceará" },
                    { new Guid("d3521ac6-e2ce-4cfa-b122-fc1a84ae4f34"), 27, "Espírito Santo" },
                    { new Guid("da92e583-4501-4518-b24e-bd2f2d0b09b5"), 45, "Paraná" },
                    { new Guid("dd032727-ecf1-4010-8104-667c965dea11"), 74, "Bahia" },
                    { new Guid("dd5f54b0-9b77-4c2f-9bd2-b6f1169bc6ab"), 13, "Campinas" },
                    { new Guid("e3f40438-de17-4a92-b89d-c14f4caf46c6"), 12, "Santos" },
                    { new Guid("e60e40ac-5c8c-4107-a9c6-28a49102ae0b"), 46, "Paraná" },
                    { new Guid("e7a398bb-06ee-4218-9a68-687d6614babf"), 22, "Rio de Janeiro" },
                    { new Guid("e7f1b8ff-affb-4c95-9447-bf389eb8fdd1"), 68, "Acre" },
                    { new Guid("ef06c558-740a-4e80-8769-ad18b7aa575b"), 53, "Rio Grande do Sul" },
                    { new Guid("f199d964-f43a-4d78-a59a-6364ecfddca1"), 89, "Piauí" },
                    { new Guid("f6fc5b3b-94cc-4519-8d33-5173b07fbe76"), 38, "Minas Gerais" },
                    { new Guid("fa0a3181-090e-4add-b7af-be8cd3819b73"), 64, "Goiás" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_StateId",
                schema: "TechChallenge",
                table: "Contact",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact",
                schema: "TechChallenge");

            migrationBuilder.DropTable(
                name: "State",
                schema: "TechChallenge");
        }
    }
}
