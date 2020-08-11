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

        public IActionResult Login(string returnUrl = null)
        {
            // Guardar el returnUrl en el ViewData
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string returnUrl = null)
        {
            // Validar que el usuario exista en la BD
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                // No lo encontro retornar la misma vista
                ViewData["ReturnUrl"] = returnUrl;
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

            // Intentar la redireccion
            return RedirectToLocal(returnUrl);
        }

        public IActionResult RedirectToLocal(string returnUrl)
        {
            // Esta funcion va a tener la logica de redireccionar a otra URL
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
