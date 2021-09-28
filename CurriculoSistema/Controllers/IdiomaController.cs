using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly IdiomaService _idiomaService;

        public IdiomaController(IdiomaService idiomaService)
        {
            _idiomaService = idiomaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarAsync(int id)
        {

            Idioma idioma = new Idioma()
            {
                CurriculoId = id
            };

            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([FromForm] Idioma idioma)
        {
            if (idioma.CurriculoId == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(idioma);
            }

            await _idiomaService.CriarAsync(idioma);

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = idioma.CurriculoId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Idioma idioma = await _idiomaService.BuscarPorIdAsync(id.Value);

            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Idioma idioma)
        {
            if (id != idioma.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(idioma);
            }

            try
            {
                await _idiomaService.AtualizarAsync(idioma);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = idioma.CurriculoId });
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if (id == null)
            {
                return Json("Idioma não encontrado");
            }

            try
            {
                await _idiomaService.ExcluirAsync(id.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Json("Idioma excluído com sucesso.");
        }
    }
}
