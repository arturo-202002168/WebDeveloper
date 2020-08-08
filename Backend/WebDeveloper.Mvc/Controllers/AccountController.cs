using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebDeveloper.Core.Interfaces;

namespace WebDeveloper.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IChinookContext _context;
        public AccountController(IChinookContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            
            return View();
            //return RedirectToAction("AlbumesPorArtista", "Reportes");
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string returnUrl)
        {
            // Validar que el usuario exista en la BD
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(user == null)
            {
                // No lo encontro retornar la misma vista
                return View();
            }

            //Crear la cookie de inicio de sesion
            //Crear el listado de claims del usuario
            var userClaims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("DNI", user.Dni)
                // Colocar todos los claims
            };

            // Crear la identidad del usuario
            var identity = new ClaimsIdentity(userClaims, "ClaimsIdentity");

            // Para iniciar sesion, crear un usuario principal
            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            // Iniciar la sesion
            HttpContext.SignInAsync(userPrincipal);
            //var returnUrl = Request.Query["ReturnUrl"];

            return View();
        }
    }
}
