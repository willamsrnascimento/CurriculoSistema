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
    public class IdiomaService : IBasicAsync<Idioma>
    {
        private readonly CurriculoSistemaContext _context;

        public IdiomaService(CurriculoSistemaContext context)
        {
            _context = context;
        }
        public async Task AtualizarAsync(Idioma idioma)
        {
            _context.Update(idioma);
            await _context.SaveChangesAsync();
        }

        public async Task<Idioma> BuscarPorIdAsync(int id)
        {
            if (!await _context.Idiomas.AsNoTracking().AnyAsync(i => i.Id == id))
            {
                return null;
            }

            return await _context.Idiomas.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Idioma>> BuscarTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CriarAsync(Idioma idioma)
        {
            _context.Add(idioma);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            Idioma idioma = await _context.Idiomas.Where(i => i.Id == id).FirstOrDefaultAsync();

            try
            {
                _context.Idiomas.Remove(idioma);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Idioma>> BuscaIdiomaCurriculoId(int id)
        {
            if (!await _context.Idiomas.AsNoTracking().AnyAsync())
            {
                return null;
            }

            return await _context.Idiomas.Where(i => i.CurriculoId == id).ToListAsync();
        }
    }
}
