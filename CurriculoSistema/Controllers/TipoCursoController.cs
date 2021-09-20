using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class TipoCursoController : Controller
    {
        private readonly TipoCursoService _tipoCursoService;

        public TipoCursoController(TipoCursoService tipoCursoService)
        {
            _tipoCursoService = tipoCursoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TipoCurso> tipoCursos = await _tipoCursoService.BuscarTodosAsync();

            if(tipoCursos == null)
            {
                tipoCursos = new List<TipoCurso>();
            }

            return View(tipoCursos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(TipoCurso tipoCurso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _tipoCursoService.CriarAsync(tipoCurso);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            TipoCurso tipoCurso;

            try
            {
                tipoCurso = await _tipoCursoService.BuscarPorIdAsync(id.Value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if(tipoCurso == null)
            {
                NotFound();
            }

            return View(tipoCurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, TipoCurso tipoCurso)
        {
            if (ModelState.IsValid)
            {
                if (id != tipoCurso.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await _tipoCursoService.AtualizarAsync(tipoCurso);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
            }
            else
            {
                return View(tipoCurso);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if(id == null)
            {
                return Json("Usuário não cadastrado");
            }

            TipoCurso tipoCurso = await _tipoCursoService.BuscarPorIdAsync(id.Value);

            if(tipoCurso == null)
            {
                return Json("Usuário não cadastrado");
            }

            try
            {
               await _tipoCursoService.ExcluirAsync(id.Value);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Json("Usuário excluido com sucesso.");
        }
       
    }
}
