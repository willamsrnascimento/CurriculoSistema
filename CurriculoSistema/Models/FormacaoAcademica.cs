using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaCurriculos.Models
{
    public class FormacaoAcademica
    {
        public int Id { get; set; }
        public int TipoCursoId { get; set; }
        public TipoCurso TipoCurso { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1920, 2018, ErrorMessage = "Ano Inválido")]
        public int AnoInicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1920, 2018, ErrorMessage = "Ano Inválido")]
        public int AnoFim { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        public string NomeCurso { get; set; }
        public int CurriculoId { get; set; }
        public Curriculo Curriculo { get; set; }


    }
}
