using Domain.Models;

namespace Application.IServices
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> ObtemUsuarios();
        Task<int> InserirUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
        Task DeletarUsuario(int id);
    }
}
