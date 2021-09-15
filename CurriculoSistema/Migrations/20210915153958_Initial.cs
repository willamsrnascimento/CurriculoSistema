using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCurriculos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curriculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curriculo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacaoLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoIp = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Horario = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacaoLogin_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaProfissional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    AnoInicio = table.Column<int>(nullable: false),
                    AnoFim = table.Column<int>(nullable: false),
                    DescricaoAtividades = table.Column<string>(maxLength: 500, nullable: false),
                    CurriculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienciaProfissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienciaProfissional_Curriculo_CurriculoId",
                        column: x => x.CurriculoId,
                        principalTable: "Curriculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormacaoAcademica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCursoId = table.Column<int>(nullable: false),
                    Instituicao = table.Column<string>(maxLength: 50, nullable: false),
                    AnoInicio = table.Column<int>(nullable: false),
                    AnoFim = table.Column<int>(nullable: false),
                    NomeCurso = table.Column<string>(maxLength: 50, nullable: false),
                    CurriculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacaoAcademica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormacaoAcademica_Curriculo_CurriculoId",
                        column: x => x.CurriculoId,
                        principalTable: "Curriculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormacaoAcademica_TipoCursos_TipoCursoId",
                        column: x => x.TipoCursoId,
                        principalTable: "TipoCursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Nivel = table.Column<string>(maxLength: 50, nullable: false),
                    CurriculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idioma_Curriculo_CurriculoId",
                        column: x => x.CurriculoId,
                        principalTable: "Curriculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    CurriculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objetivo_Curriculo_CurriculoId",
                        column: x => x.CurriculoId,
                        principalTable: "Curriculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curriculo_Nome",
                table: "Curriculo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculo_UsuarioId",
                table: "Curriculo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaProfissional_CurriculoId",
                table: "ExperienciaProfissional",
                column: "CurriculoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoAcademica_CurriculoId",
                table: "FormacaoAcademica",
                column: "CurriculoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoAcademica_TipoCursoId",
                table: "FormacaoAcademica",
                column: "TipoCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Idioma_CurriculoId",
                table: "Idioma",
                column: "CurriculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Idioma_Nome",
                table: "Idioma",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformacaoLogin_UsuarioId",
                table: "InformacaoLogin",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_CurriculoId",
                table: "Objetivo",
                column: "CurriculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCursos_Tipo",
                table: "TipoCursos",
                column: "Tipo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienciaProfissional");

            migrationBuilder.DropTable(
                name: "FormacaoAcademica");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "InformacaoLogin");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "TipoCursos");

            migrationBuilder.DropTable(
                name: "Curriculo");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
