using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SGP.Dados.Contexto;
using SME.SGP.Dados.Repositorios;
using SME.SGP.Dominio.Repositorios;
using System.Data;

namespace SME.SGP.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection services)
        {
            //RegisterUnitOfWork(services, environmentName);
            RegistrarRepositorios(services);
            RegistrarContextos(services);
            //RegistrarControlesCasoDeUso(services, environmentName);
            //RegistrarServicos(services);
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
            services.TryAddScoped<IDbConnection, DbContext>();
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioAluno, RepositorioAluno>();
        }
    }
}