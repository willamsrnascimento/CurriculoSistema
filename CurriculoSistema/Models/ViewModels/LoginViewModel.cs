using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Use menos caractéres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
