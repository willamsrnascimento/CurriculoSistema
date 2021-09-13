using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Models
{
    public class ExperienciaProfissional
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1920, 2018, ErrorMessage = "Ano Inválido")]
        public int AnoInicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1920, 2018, ErrorMessage = "Ano Inválido")]
        public int AnoFim { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(500, ErrorMessage = "Use menos caractéres")]
        [DataType(DataType.MultilineText)]
        public string DescricaoAtividades { get; set; }
        public int CurriculoId { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
