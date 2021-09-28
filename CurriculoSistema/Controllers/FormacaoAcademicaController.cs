using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Models.ViewModels;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class FormacaoAcademicaController : Controller
    {
        private readonly FormacaoAcademicaService _formacaoAcademicaService;
        private readonly TipoCursoService _tipoCursoService;

        public FormacaoAcademicaController(FormacaoAcademicaService formacaoAcademicaService, TipoCursoService tipoCursoService)
        {
            _formacaoAcademicaService = formacaoAcademicaService;
            _tipoCursoService = tipoCursoService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CriarAsync(int id)
        {
            FormacaoAcademicaViewModel formacaoAcademicaViewModel = new FormacaoAcademicaViewModel()
            {
                FormacaoAcademica = new FormacaoAcademica()
                {
                    CurriculoId = id
                },
                TiposCursos = await _tipoCursoService.BuscarTodosAsync()
            };

            if(formacaoAcademicaViewModel.TiposCursos.Count == 0)
            {
                formacaoAcademicaViewModel.TiposCursos = new List<TipoCurso>();
            }

            return View(formacaoAcademicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([FromForm] FormacaoAcademica formacaoAcademica)
        {
            if (formacaoAcademica.CurriculoId == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(formacaoAcademica);
            }

            await _formacaoAcademicaService.CriarAsync(formacaoAcademica);

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = formacaoAcademica.CurriculoId });
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FormacaoAcademica formacaoAcademica = await _formacaoAcademicaService.BuscarPorIdAsync(id.Value);

            FormacaoAcademicaViewModel formacaoAcademicaViewModel = new FormacaoAcademicaViewModel
            {
                FormacaoAcademica = formacaoAcademica,
                TiposCursos = await _tipoCursoService.BuscarTodosAsync()
            };

            if (formacaoAcademica == null)
            {
                return NotFound();
            }

            return View(formacaoAcademicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, FormacaoAcademica formacaoAcademica)
        {
            if (id != formacaoAcademica.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(formacaoAcademica);
            }

            try
            {
                await _formacaoAcademicaService.AtualizarAsync(formacaoAcademica);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Detalhe", "Curriculo", new Curriculo() { Id = formacaoAcademica.CurriculoId });
        }

        public async Task<JsonResult> Excluir(int? id)
        {
            if (id == null)
            {
                return Json("Formação Academica não encontrado");
            }

            try
            {
                await _formacaoAcademicaService.ExcluirAsync(id.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Json("Formação Academica excluído com sucesso.");
        }
    }
}
