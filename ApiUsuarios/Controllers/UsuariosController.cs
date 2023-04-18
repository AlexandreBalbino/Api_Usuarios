using Application.IServices;
using Domain.Models;
using Domain.Resposta;
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
                return BadRequest("Erro ao obter usuarios");
            }
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Resposta<int>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> InserirUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var resultado = await _usuariosService.InserirUsuario(usuario);
                return Ok(new Resposta<int>(resultado));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir usuario");
                return BadRequest("Erro ao inserir usuario");
            }
        }

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Resposta<string>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                await _usuariosService.AtualizarUsuario(usuario);
                return Ok(new Resposta<string>("Atualizado com sucesso!"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar usuario");
                return BadRequest("Erro ao atualizar usuario");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Resposta<string>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ObjectResult> DeletarUsuario([FromRoute] int id)
        {
            try
            {
                await _usuariosService.DeletarUsuario(id);
                return Ok(new Resposta<string>("Usuario deletado!"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao deletar usuario");
                return BadRequest("Erro ao deletar usuario");
            }
        }

    }
}
