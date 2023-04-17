using InfraData.IRepositorys;
using InfraData.Repositorys;

namespace Api_Usuarios.Configurations
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
