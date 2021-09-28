using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCurriculos.ViewComponents
{
    public class ExperienciaProfissionalViewComponent : ViewComponent
    {
        private readonly ExperienciaProfissionalService _experienciaProfissionalService;

        public ExperienciaProfissionalViewComponent(ExperienciaProfissionalService experienciaProfissionalService)
        {
            _experienciaProfissionalService = experienciaProfissionalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<ExperienciaProfissional> experienciaProfissionals = await _experienciaProfissionalService.BuscaExperienciaCurriculoId(id);

            if (experienciaProfissionals == null)
            {
                experienciaProfissionals = new List<ExperienciaProfissional>();
            }

            return View(experienciaProfissionals);
        }
    }
}
