using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public ICollection<InformacaoLogin> InformacoesLogin { get; set; }
        public ICollection<Curriculo> Curriculos { get; set; }
    }
}
