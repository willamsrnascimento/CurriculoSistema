using System.Collections.Generic;

namespace SistemaCurriculos.Models.ViewModels
{
    public class FormacaoAcademicaViewModel
    {
        public FormacaoAcademica FormacaoAcademica { get; set; }
        public List<TipoCurso> TiposCursos { get; set; }
    }
}
