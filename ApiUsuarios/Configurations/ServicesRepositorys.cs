﻿using Application.IServices;
using Application.Services;

namespace ApiUsuarios.Configurations
{
    public  static class ServicesRepositorys
    {
        public static IServiceCollection AdicionarServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuariosService, UsuariosService>();
            return services;
        }
    }
}
