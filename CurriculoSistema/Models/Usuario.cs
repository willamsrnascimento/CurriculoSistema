using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCurriculos.Models
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

        public Usuario()
        {
        }

        public Usuario(int id, string email, string senha, ICollection<InformacaoLogin> informacoesLogin, ICollection<Curriculo> curriculos)
        {
            Id = id;
            Email = email;
            Senha = senha;
            InformacoesLogin = informacoesLogin;
            Curriculos = curriculos;
        }
    }
}
