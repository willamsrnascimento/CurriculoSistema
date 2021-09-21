using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Curriculo> curriculos = await _curriculoService.BuscarTodosAsync();

            if(curriculos == null)
            {
                curriculos = new List<Curriculo>();
            }

            return View(curriculos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                curriculo.UsuarioId = HttpContext.Session.GetInt32("UsuarioId").Value;

                await _curriculoService.CriarAsync(curriculo);

                return RedirectToAction(nameof(Index));
            }

            return View(curriculo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            Curriculo curriculo = await _curriculoService.BuscarPorIdAsync(id.Value);

            if(curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                if(id != curriculo.Id)
                {
                    return BadRequest();
                }

                try
                {
                    curriculo.UsuarioId = HttpContext.Session.GetInt32("UsuarioId").Value;

                    await _curriculoService.AtualizarAsync(curriculo);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(curriculo);
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if (id == null)
            {
                return Json("Curriculo não cadastrado");
            }

            Curriculo curriculo = await _curriculoService.BuscarPorIdAsync(id.Value);

            if (curriculo == null)
            {
                return Json("Currículo não cadastrado");
            }

            try
            {
                await _curriculoService.ExcluirAsync(id.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Json("Currículo excluído com sucesso.");
        }

    }
}
