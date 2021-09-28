using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCurriculos.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent
    {
        private readonly IdiomaService _idiomaService;

        public IdiomaViewComponent(IdiomaService idiomaService)
        {
            _idiomaService = idiomaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Idioma> idiomas = await _idiomaService.BuscaIdiomaCurriculoId(id);

            if (idiomas == null)
            {
                idiomas = new List<Idioma>();
            }

            return View(idiomas);
        }
    }
}
