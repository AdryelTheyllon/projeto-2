using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_WebAPI.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escritorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Regiao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escritorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Rg = table.Column<string>(type: "TEXT", nullable: false),
                    SiglaDepartamento = table.Column<string>(type: "TEXT", nullable: false),
                    IdDepartamento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    EscritorioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Escritorios_EscritorioId",
                        column: x => x.EscritorioId,
                        principalTable: "Escritorios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartamentosFuncionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentosFuncionarios", x => new { x.FuncionarioId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_DepartamentosFuncionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentosFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "EscritorioId", "Nome", "Sigla" },
                values: new object[] { 1, null, "Tecnologia da Informação", "TI" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "EscritorioId", "Nome", "Sigla" },
                values: new object[] { 2, null, "Administração", "ADM" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "EscritorioId", "Nome", "Sigla" },
                values: new object[] { 3, null, "Recursos Humanos", "RH" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "EscritorioId", "Nome", "Sigla" },
                values: new object[] { 4, null, "Financeiro", "FN" });

            migrationBuilder.InsertData(
                table: "Escritorios",
                columns: new[] { "Id", "Regiao" },
                values: new object[] { 1, "Oeste" });

            migrationBuilder.InsertData(
                table: "Escritorios",
                columns: new[] { "Id", "Regiao" },
                values: new object[] { 2, "Norte" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 1, 1, "Adryel", "12346", "TI" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 2, 2, "Isabel", "56783", "ADM" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 3, 3, "Dhara", "91023", "RH" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 4, 4, "Taina", "17109", "FN" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 5, 1, "Lucas", "12876", "TI" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 6, 3, "Pedro", "780674", "RH" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "IdDepartamento", "Nome", "Rg", "SiglaDepartamento" },
                values: new object[] { 7, 2, "Paulo", "456743", "ADM" });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "DepartamentosFuncionarios",
                columns: new[] { "DepartamentoId", "FuncionarioId" },
                values: new object[] { 2, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_EscritorioId",
                table: "Departamentos",
                column: "EscritorioId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentosFuncionarios_DepartamentoId",
                table: "DepartamentosFuncionarios",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentosFuncionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Escritorios");
        }
    }
}
