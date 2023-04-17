using Infradata.IRepositorys;
using Infradata.Repositorys;

namespace ApiUsuarios.Configurations
{
    public static class RepositorysConfiguration
    {
        public static IServiceCollection AdicionarRepositorys(this IServiceCollection repositorys)
        {
            repositorys.AddScoped<IUsuariosRepository, UsuariosRepository>();
            return repositorys;
        }
    }
}
