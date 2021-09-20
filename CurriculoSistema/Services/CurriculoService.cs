using Microsoft.EntityFrameworkCore;
using SistemaCurriculos.Data;
using SistemaCurriculos.Models;
using SistemaCurriculos.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Services
{
    public class CurriculoService : IBasicAsync<Curriculo>
    {
        private readonly CurriculoSistemaContext _context;

        public CurriculoService(CurriculoSistemaContext context)
        {
            _context = context;
        }

        public Task AtualizarAsync(Curriculo t)
        {
            throw new System.NotImplementedException();
        }

        public Task<Curriculo> BuscarPorIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Curriculo>> BuscarTodosAsync()
        {
            if (!await _context.Curriculos.AsNoTracking().AnyAsync())
            {
                return null;
            }

            return await _context.Curriculos.OrderBy(c => c.Nome).ToListAsync();
        }

        public Task CriarAsync(Curriculo t)
        {
            throw new System.NotImplementedException();
        }

        public Task ExcluirAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
