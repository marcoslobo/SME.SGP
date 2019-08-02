using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SGP.Dados.Repositorios;
using SME.SGP.Dominio.Repositorios;

namespace SME.SGP.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection services)
        {
            //RegisterUnitOfWork(services, environmentName);
            RegistrarRepositorios(services);
            //RegistrarControlesCasoDeUso(services, environmentName);
            //RegistrarServicos(services);
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioAluno, RepositorioAluno>();
        }
    }
}