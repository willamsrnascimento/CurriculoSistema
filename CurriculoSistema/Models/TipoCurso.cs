using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Models
{
    public class TipoCurso
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public ICollection<FormacaoAcademica> FormacoesAcademicas { get; set; }
    }
}
