using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Data;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioSesionController : ControllerBase
    {
        private readonly ApiNoticiasContext context;
        private readonly ITokenProvider tokenProvider;

        public InicioSesionController(ApiNoticiasContext context, ITokenProvider tokenProvider)
        {
            this.context = context;
            this.tokenProvider = tokenProvider;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromForm]string nombreUsuario, [FromForm]string contrasena)
        {
            var connection = context.Database.GetDbConnection();

            var result = connection.QuerySingleOrDefault<Usuario>("ValidacionUsuarios", new { nombreUsuario, contrasena }, commandType: System.Data.CommandType.StoredProcedure);

            if (result == null)
            {
                return BadRequest("Credenciales inválidas.");
            }

            int expirationInHour = 24;

            DateTime expiration = DateTime.UtcNow.AddHours(expirationInHour);

            var token = tokenProvider.CreateToken(result, expiration);

            return Ok(new
            {
                token = token,
                expires_in = expirationInHour * 60 * 60
            });
        }
    }
}
