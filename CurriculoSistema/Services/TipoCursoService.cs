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
    public class TipoCursoService : IBasicAsync<TipoCurso>
    {
        private readonly CurriculoSistemaContext _context;

        public TipoCursoService(CurriculoSistemaContext curriculoSistemaContext)
        {
            _context = curriculoSistemaContext;
        }

        public async Task AtualizarAsync(TipoCurso tipoCurso)
        {
            _context.Update(tipoCurso);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoCurso> BuscarPorIdAsync(int id)
        {
            return await _context.TipoCursos.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TipoCurso>> BuscarTodosAsync()
        {
            if(await _context.TipoCursos.AsNoTracking().AnyAsync())
            {
                return await _context.TipoCursos.ToListAsync();
            }

            return null;
        }

        public async Task CriarAsync(TipoCurso tipoCurso)
        {
            _context.Add(tipoCurso);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            TipoCurso tipoCurso = await _context.TipoCursos.FirstOrDefaultAsync(tc => tc.Id == id);
            try
            {
                _context.Remove(tipoCurso);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
