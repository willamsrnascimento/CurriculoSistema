using System.ComponentModel.DataAnnotations;

namespace SistemaCurriculos.Models
{
    public class Objetivo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(1000, ErrorMessage = "Use menos caractéres")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        public int CurriculoId { get; set; }
        public Curriculo Curriculo { get; set; }

        public Objetivo()
        {
        }

        public Objetivo(int id, string descricao, int curriculoId, Curriculo curriculo)
        {
            Id = id;
            Descricao = descricao;
            CurriculoId = curriculoId;
            Curriculo = curriculo;
        }
    }
}
