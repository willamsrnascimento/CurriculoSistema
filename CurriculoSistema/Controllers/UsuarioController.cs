using SistemaCurriculos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaCurriculos.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using SistemaCurriculos.Models.ViewModels;

namespace SistemaCurriculos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly InformacaoLoginService _informacaoLoginService;

        public UsuarioController(UsuarioService usuarioService, InformacaoLoginService informacaoLoginService)
        {
            _usuarioService = usuarioService;
            _informacaoLoginService = informacaoLoginService;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                InformacaoLogin informacaoLogin = new InformacaoLogin
                {
                    EnderecoIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Data = DateTime.Now.ToShortDateString(),
                    Horario = DateTime.Now.ToShortTimeString()
                };

                usuario.InformacoesLogin = new List<InformacaoLogin>
                {
                    informacaoLogin
                };

                await _usuarioService.CriarAsync(usuario);

                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Curriculo");
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.Clear();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioService.VerificaDadosLogin(new Usuario() { Email = loginViewModel.Email, Senha = loginViewModel.Senha });

                if(usuario == null)
                {
                    return BadRequest();
                }

                InformacaoLogin informacaoLogin = new InformacaoLogin
                {
                    UsuarioId = usuario.Id,
                    EnderecoIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Data = DateTime.Now.ToShortDateString(),
                    Horario = DateTime.Now.ToShortTimeString()
                };

                await _informacaoLoginService.CriarAsync(informacaoLogin);

                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Curriculo");
            }

            return View(loginViewModel);
        }

        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Registrar", "Usuario");
        }
    }
}
