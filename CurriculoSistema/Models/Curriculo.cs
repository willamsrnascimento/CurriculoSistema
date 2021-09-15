using System.Collections.Generic;

namespace SistemaCurriculos.Models
{
    public class Curriculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Objetivo> Objetivos { get; set; }
        public ICollection<FormacaoAcademica> FomacoesAcademicas { get; set; }
        public ICollection<ExperienciaProfissional> ExperienciasProficionais { get; set; }
        public ICollection<Idioma> Idiomas { get; set; }
    }
}
