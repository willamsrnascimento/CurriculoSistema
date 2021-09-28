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
    public class FormacaoAcademicaService : IBasicAsync<FormacaoAcademica>
    {
        private readonly CurriculoSistemaContext _context;

        public FormacaoAcademicaService(CurriculoSistemaContext context)
        {
            _context = context;
        }
        public async Task AtualizarAsync(FormacaoAcademica formacaoAcademica)
        {
            _context.Update(formacaoAcademica);
            await _context.SaveChangesAsync();
        }

        public async Task<FormacaoAcademica> BuscarPorIdAsync(int id)
        {
            if(!await _context.FormacoesAcademicas.AsNoTracking().AnyAsync(fa => fa.Id == id))
            {
                return null;
            }

            return await _context.FormacoesAcademicas.Where(fa => fa.Id == id).Include(fa => fa.TipoCurso).FirstOrDefaultAsync();
        }

        public Task<List<FormacaoAcademica>> BuscarTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task CriarAsync(FormacaoAcademica formacaoAcademica)
        {
            _context.Add(formacaoAcademica);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            FormacaoAcademica formacaoAcademica = await _context.FormacoesAcademicas.Where(fa => fa.Id == id).FirstOrDefaultAsync();

            try
            {
                _context.FormacoesAcademicas.Remove(formacaoAcademica);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<FormacaoAcademica>> BuscaFormacaoCurriculoId(int id)
        {
            if (!await _context.FormacoesAcademicas.AsNoTracking().AnyAsync())
            {
                return null;
            }

            return await _context.FormacoesAcademicas.Where(fa => fa.CurriculoId == id).Include(fa => fa.TipoCurso).ToListAsync();
        }
    }
}
