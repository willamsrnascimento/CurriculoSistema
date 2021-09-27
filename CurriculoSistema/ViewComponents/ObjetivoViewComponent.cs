using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCurriculos.ViewComponents
{
    public class ObjetivoViewComponent : ViewComponent
    {
        private readonly ObjetivoService _objetivoService;

        public ObjetivoViewComponent(ObjetivoService objetivoService)
        {
            _objetivoService = objetivoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Objetivo> objetivos = await _objetivoService.BuscaObjetivoCurriculoId(id);

            if(objetivos == null)
            {
                objetivos = new List<Objetivo>();
            }

            return View(objetivos);
        }

    }
}
