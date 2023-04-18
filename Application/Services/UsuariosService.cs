using Application.IServices;
using Domain.Models;
using Infradata.IRepositorys;

namespace Application.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuarioRepository;

        public UsuariosService(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtemUsuarios()
        {
            return await _usuarioRepository.Get();
        }

        public async Task<int> InserirUsuario(Usuario usuario)
        {
            ValidarData(usuario);
            return await _usuarioRepository.Insert(usuario);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            ValidarData(usuario);
            await _usuarioRepository.Update(usuario);
        }

        private static void ValidarData(Usuario usuario)
        {
            var dataMaxima = DateTime.Now.Date.AddDays(1);
            if (usuario.DataNascimento > dataMaxima)
            {
                throw new ArgumentException("Data maior que a atual");
            }
        }

        public async Task DeletarUsuario(int id)
        {
            await _usuarioRepository.Delete(id);
        }
    }
}
