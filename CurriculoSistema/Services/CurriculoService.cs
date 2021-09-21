using Microsoft.EntityFrameworkCore;
using SistemaCurriculos.Data;
using SistemaCurriculos.Models;
using SistemaCurriculos.Repository;
using System;
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

        public async Task AtualizarAsync(Curriculo curriculo)
        {
            _context.Update(curriculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Curriculo> BuscarPorIdAsync(int id)
        {
            return await _context.Curriculos.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Curriculo>> BuscarTodosAsync()
        {
            if (!await _context.Curriculos.AsNoTracking().AnyAsync())
            {
                return null;
            }

            return await _context.Curriculos.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task CriarAsync(Curriculo curriculo)
        {
            _context.Add(curriculo);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            Curriculo curriculo = await _context.Curriculos.FirstOrDefaultAsync(tc => tc.Id == id);
            try
            {
                _context.Remove(curriculo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
