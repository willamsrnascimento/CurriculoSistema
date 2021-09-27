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
    public class ObjetivoService : IBasicAsync<Objetivo>
    {
        private readonly CurriculoSistemaContext _context;

        public ObjetivoService(CurriculoSistemaContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(Objetivo objetivo)
        {
            _context.Update(objetivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Objetivo> BuscarPorIdAsync(int id)
        {
            if(await _context.Objetivos.AsNoTracking().AnyAsync(o => o.Id == id))
            {
               return await _context.Objetivos.Where(o => o.Id == id).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Objetivo>> BuscarTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CriarAsync(Objetivo objetivo)
        {
            _context.Add(objetivo);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            Objetivo objetivo = await _context.Objetivos.FirstOrDefaultAsync(o => o.Id == id);
            try
            {
                _context.Remove(objetivo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Objetivo>> BuscaObjetivoCurriculoId(int id)
        {
            if(await _context.Objetivos.AsNoTracking().AnyAsync())
            {
                return await _context.Objetivos.Where(o => o.CurriculoId == id).ToListAsync();
            }

            return null;
        }
    }
}
