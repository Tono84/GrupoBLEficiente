using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBLEficienteAPI.Helpers;
using GrupoBLEficienteAPI.Services.Contract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using GrupoBLEficienteAPI.Models;

namespace GrupoBLEficienteAPI.Controllers
{
    [Route("api/Authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        // POST: api/Authorization
        [HttpPost]
        public async Task<IActionResult> Register(Users Model)
        {
            if (ModelState.IsValid)
            {
                Model.Password = Utilities.GetSHA256(Model.Password);
                await _userService.SaveUser(Model);

                if (Model.IdUser > 0)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el usuario");
                    return BadRequest();
                }

            }
            ModelState.AddModelError("", "Error al registrar el usuario");
            return BadRequest(ModelState);
        }

        // POST: api/Authorization
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(string username, string password)
        {
            Users user_found = await _userService.GetUser(username, Utilities.GetSHA256(password));

            if (user_found == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return Ok();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user_found.UserName),
                new Claim(ClaimTypes.Role, user_found.Roles.Name),
                new Claim(ClaimTypes.NameIdentifier, user_found.IdUser.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok();
        }
    }
}
    
