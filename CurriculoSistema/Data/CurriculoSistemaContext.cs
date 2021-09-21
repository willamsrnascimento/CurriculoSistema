using Microsoft.EntityFrameworkCore;
using SistemaCurriculos.Models;
using SistemaCurriculos.Data.Configuration;

namespace SistemaCurriculos.Data
{
    public class CurriculoSistemaContext : DbContext
    {
        public DbSet<Curriculo> Curriculos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<TipoCurso> TipoCursos { get; set; }
        public DbSet<FormacaoAcademica> FormacoesAcademicas { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<InformacaoLogin> InformacoesLogins { get; set; }

        public CurriculoSistemaContext(DbContextOptions<CurriculoSistemaContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurriculoConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienciaProfissionalConfiguration());
            modelBuilder.ApplyConfiguration(new FormacaoAcademicaConfiguration());
            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());
            modelBuilder.ApplyConfiguration(new InformacaoLoginConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetivoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoCursoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
