using SistemaCurriculos.Data;


namespace SistemaCurriculos.Services
{
    public class CurriculoService 
    {
        private readonly CurriculoSistemaContext _context;

        public CurriculoService(CurriculoSistemaContext context)
        {
            context = _context;
        }
    }
}
