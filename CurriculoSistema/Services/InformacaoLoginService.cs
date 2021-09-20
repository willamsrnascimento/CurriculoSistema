using SistemaCurriculos.Data;
using SistemaCurriculos.Models;
using SistemaCurriculos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Services
{
    public class InformacaoLoginService : IBasicAsync<InformacaoLogin>
    {
        private readonly CurriculoSistemaContext _context;

        public InformacaoLoginService(CurriculoSistemaContext context)
        {
            _context = context;
        }

        public Task AtualizarAsync(InformacaoLogin t)
        {
            throw new NotImplementedException();
        }

        public Task<InformacaoLogin> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InformacaoLogin>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CriarAsync(InformacaoLogin informacaoLogin)
        {
            _context.Add(informacaoLogin);
            await _context.SaveChangesAsync();
        }

        public Task ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
