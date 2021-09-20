using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemacurriculos.Controllers
{
    public class CurriculoController : Controller
    {
        private readonly CurriculoService _curriculoService;

        public CurriculoController(CurriculoService curriculoService)
        {
            _curriculoService = curriculoService;
        }

        public async Task<IActionResult> Index()
        {
            List<Curriculo> curriculos = await _curriculoService.BuscarTodosAsync();

            if(curriculos == null)
            {
                curriculos = new List<Curriculo>();
            }

            return View(curriculos);
        }
    }
}
