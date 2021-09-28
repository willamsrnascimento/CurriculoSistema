using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCurriculos.ViewComponents
{
    public class FormacaoAcademicaViewComponent : ViewComponent
    {
        private readonly FormacaoAcademicaService _formacaoAcademicaService;

        public FormacaoAcademicaViewComponent(FormacaoAcademicaService formacaoAcademicaService)
        {
            _formacaoAcademicaService = formacaoAcademicaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<FormacaoAcademica> formacaoAcademica = await _formacaoAcademicaService.BuscaFormacaoCurriculoId(id);

            if (formacaoAcademica == null)
            {
                formacaoAcademica = new List<FormacaoAcademica>();
            }

            return View(formacaoAcademica);
        }
    }
}
