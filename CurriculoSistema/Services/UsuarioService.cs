using SistemaCurriculos.Data;
using SistemaCurriculos.Models;
using SistemaCurriculos.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCurriculos.Services
{
    public class UsuarioService : IBasicAsync<Usuario>
    {
        private readonly CurriculoSistemaContext _context;

        public UsuarioService(CurriculoSistemaContext context)
        {
            _context = context;
        }

        public Task AtualizarAsync(Usuario t)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> BuscarPorIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Usuario>> BuscarTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CriarAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public Task ExcluirAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}