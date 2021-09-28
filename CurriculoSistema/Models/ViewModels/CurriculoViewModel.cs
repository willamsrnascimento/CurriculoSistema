using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Models.ViewModels
{
    public class CurriculoViewModel
    {
        public Curriculo Curriculo { get; set; }
        public IEnumerable<Objetivo> Objetivos { get; set; }
        public IEnumerable<FormacaoAcademica> FormacoesAcademicas { get; set; }
        public IEnumerable<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public IEnumerable<Idioma> Idiomas { get; set; }
    }
}
