﻿using Microsoft.AspNetCore.Mvc;

namespace Api_Usuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public async Task<ObjectResult> ObtemUsuarios()
        {

            return Ok("teste");
        }
    }
}