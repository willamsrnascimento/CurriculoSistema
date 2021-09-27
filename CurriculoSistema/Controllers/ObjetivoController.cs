using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly ObjetivoService _objetivoService;

        public ObjetivoController(ObjetivoService objetivoService)
        {
            _objetivoService = objetivoService;
        }

        public IActionResult Criar(int id)
        {

            Objetivo objetivo = new Objetivo
            {
                CurriculoId = id,

            };

            return View(objetivo); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([FromForm] Objetivo objetivo)
        {
            if(objetivo.CurriculoId == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(objetivo);
            }

            await _objetivoService.CriarAsync(objetivo);

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = objetivo.CurriculoId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Objetivo objetivo = await _objetivoService.BuscarPorIdAsync(id.Value);

            if(objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, Objetivo objetivo)
        {
            if(id != objetivo.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(objetivo);               
            }

            try
            {
                await _objetivoService.AtualizarAsync(objetivo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = objetivo.CurriculoId });
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if(id == null)
            {
                return Json("Objetivo não encontrado");
            }

            try
            {
                await _objetivoService.ExcluirAsync(id.Value);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return Json("Objetivo excluído com sucesso.");
        }
    }
}
