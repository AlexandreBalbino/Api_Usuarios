﻿using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(ILogger<UsuariosController> logger, IUsuariosService usuariosService)
        {
            _logger = logger;
            _usuariosService = usuariosService;
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Usuario>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> ObtemUsuarios()
        {
            try
            {
                var usuarios = await _usuariosService.ObtemUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao obter usuarios");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> InserirUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var resultado = await _usuariosService.InserirUsuario(usuario);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir usuario");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                await _usuariosService.AtualizarUsuario(usuario);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar usuario");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> DeletarUsuario([FromRoute] int id)
        {
            try
            {
                await _usuariosService.DeletarUsuario(id);
                return Ok("Usuario deletado!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao deletar usuario");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
