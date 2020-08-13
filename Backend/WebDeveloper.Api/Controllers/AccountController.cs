using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDeveloper.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        // POST /account/token
        [HttpPost("token")]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            // TODO: obtener el usuario de la BD
            // Crear la identidad del usuario (claims)
            var identidad = new[]
            {
                new Claim(ClaimTypes.Name, "Test"),
                new Claim(ClaimTypes.Email, "corre1@mail.com"),
                new Claim("DNI", "12345678")
            };

            // Crear los objetos que nos van a servir para crear el JWT
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("cibertec12345678"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            // Generar el JWT
            // Setear una fecha de expiracion al token
            var expirationSeconds = 120;
            var jwtExpirationDate = DateTime.Now.AddSeconds(expirationSeconds);

            var token = new JwtSecurityToken(
                issuer: "Cibertec",
                audience: "app-js",
                claims: identidad,
                expires: jwtExpirationDate,
                signingCredentials: credenciales
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = jwtToken });
        }
    }
}
