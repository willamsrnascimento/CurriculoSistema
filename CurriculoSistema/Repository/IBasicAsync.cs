using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Repository
{
    public interface IBasicAsync<T>
    {
        Task CriarAsync(T t);
        Task AtualizarAsync(T t);
        Task ExcluirAsync(long id);
        Task<List<T>> BuscarTodosAsync();
        Task<T> BuscarPorIdAsync(long id);
    }
}
