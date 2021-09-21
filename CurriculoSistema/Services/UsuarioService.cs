using Microsoft.EntityFrameworkCore;
using SistemaCurriculos.Data;
using SistemaCurriculos.Models;
using SistemaCurriculos.Repository;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Usuario> BuscarPorIdAsync(int id)
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

        public Task ExcluirAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Usuario> VerificaDadosLogin(Usuario usuario) 
        {
            if(await _context.Usuarios.AsNoTracking().AnyAsync(u => u.Email == usuario.Email && u.Senha == usuario.Senha))
            {
                return await _context.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).SingleOrDefaultAsync();
            }

            return null;
        }

        public async Task<bool> VerificaUsuarioExiste(string email)
        {
            return await _context.Usuarios.AsNoTracking().AnyAsync(u => u.Email == email);
        }
    }
}