using System.Collections.Generic;

namespace SistemaCurriculos.Models
{
    public class TipoCurso
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public ICollection<FormacaoAcademica> FormacoesAcademicas { get; set; }
    }
}
