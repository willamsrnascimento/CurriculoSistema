using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Models
{
    public class InformacaoLogin
    {
        public int Id { get; set; }
        public string EnderecoIp { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
