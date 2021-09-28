using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class ExperienciaProfissionalController : Controller
    {
        private readonly ExperienciaProfissionalService _experienciaProfissionalService;

        public ExperienciaProfissionalController(ExperienciaProfissionalService experienciaProfissionalService)
        {
            _experienciaProfissionalService = experienciaProfissionalService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarAsync(int id)
        {

            ExperienciaProfissional experienciaProfissional = new ExperienciaProfissional()
            {
                CurriculoId = id
            };

            return View(experienciaProfissional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([FromForm] ExperienciaProfissional experienciaProfissional)
        {
            if (experienciaProfissional.CurriculoId == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(experienciaProfissional);
            }

            await _experienciaProfissionalService.CriarAsync(experienciaProfissional);

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = experienciaProfissional.CurriculoId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExperienciaProfissional experienciaProfissional = await _experienciaProfissionalService.BuscarPorIdAsync(id.Value);

            if (experienciaProfissional == null)
            {
                return NotFound();
            }

            return View(experienciaProfissional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, ExperienciaProfissional experienciaProfissional)
        {
            if (id != experienciaProfissional.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(experienciaProfissional);
            }

            try
            {
                await _experienciaProfissionalService.AtualizarAsync(experienciaProfissional);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = experienciaProfissional.CurriculoId });
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if (id == null)
            {
                return Json("Experiência Profissional não encontrado");
            }

            try
            {
                await _experienciaProfissionalService.ExcluirAsync(id.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Json("Experiência Profissional excluído com sucesso.");
        }
    }
}
