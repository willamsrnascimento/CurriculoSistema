using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCurriculos.Models;
using SistemaCurriculos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCurriculos.Controllers
{
    public class InformacaoLoginController : Controller
    {
        private readonly InformacaoLoginService _informacaoLoginService;

        public InformacaoLoginController(InformacaoLoginService informacaoLoginService)
        {
            _informacaoLoginService = informacaoLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId").Value;

            List<InformacaoLogin> informacaoLogins = await _informacaoLoginService.BuscaInformacaoUsuarioId(usuarioId);

            if(informacaoLogins == null)
            {
                informacaoLogins = new List<InformacaoLogin>();
            }

            return View(informacaoLogins);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCSV(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            List<InformacaoLogin> informacaoLogins = await _informacaoLoginService.BuscaInformacaoUsuarioId(id.Value);

            if (informacaoLogins == null)
            {
                return NotFound();
            }

            StringBuilder dadosArquivo = new StringBuilder();

            dadosArquivo.AppendLine("EnderecoIp;Data;Hora");

            foreach(InformacaoLogin informacaoLogin in informacaoLogins)
            {
                dadosArquivo.AppendLine($"{informacaoLogin.EnderecoIp};{informacaoLogin.Data};{informacaoLogin.Horario}");
            }

            return File(Encoding.ASCII.GetBytes(dadosArquivo.ToString()), "text/csv", "DadosLogin.csv");
        }
    }
}
