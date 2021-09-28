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
    public class ExperienciaProfissionalService : IBasicAsync<ExperienciaProfissional>
    {
        private readonly CurriculoSistemaContext _context;

        public ExperienciaProfissionalService(CurriculoSistemaContext context)
        {
            _context = context;
        }
        public async Task AtualizarAsync(ExperienciaProfissional experienciaProfissional)
        {
            _context.Update(experienciaProfissional);
            await _context.SaveChangesAsync();
        }

        public async Task<ExperienciaProfissional> BuscarPorIdAsync(int id)
        {
            if (!await _context.ExperienciasProfissionais.AsNoTracking().AnyAsync(ep => ep.Id == id))
            {
                return null;
            }

            return await _context.ExperienciasProfissionais.Where(ep => ep.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<ExperienciaProfissional>> BuscarTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CriarAsync(ExperienciaProfissional experienciaProfissional)
        {
            _context.Add(experienciaProfissional);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            ExperienciaProfissional experienciaProfissional = await _context.ExperienciasProfissionais.Where(ep => ep.Id == id).FirstOrDefaultAsync();

            try
            {
                _context.ExperienciasProfissionais.Remove(experienciaProfissional);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ExperienciaProfissional>> BuscaExperienciaCurriculoId(int id)
        {
            if (!await _context.FormacoesAcademicas.AsNoTracking().AnyAsync())
            {
                return null;
            }

            return await _context.ExperienciasProfissionais.Where(ep => ep.CurriculoId == id).ToListAsync();
        }
    }
}
