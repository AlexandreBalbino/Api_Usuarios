using Domain.Models;

namespace Infradata.IRepositorys
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<int> Insert(Usuario usuarios);
        Task Update(Usuario usuarios);
        Task Delete(int id);
    }
}
