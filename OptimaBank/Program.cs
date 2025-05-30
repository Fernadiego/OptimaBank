using OptimaBank.ApplicationLogic;
using OptimaBank.Domain;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;
using OptimaBank.SQLServerDataProvider;
using OptimaBank.SQLServerDataProvider.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.ApplicationLogic.PlazoFijo;
using OptimaBank.UI;
using OptimaBank.UI.Controllers;
using OptimaBank.Services.Interfaces;
using OptimaBank.Services.DataModel;

namespace OptimaBank
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var formMain = serviceProvider.GetRequiredService<FrmMain>();
                Application.Run(formMain);
            }            
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<FrmMain>();

            // DATA MODEL SERVICIOS
            services.AddScoped<IDataModelRepository, DataModelRepository>()
                .AddScoped<IDataModelService, DataModelService>()
                .AddScoped<PlazoFijoController>();

            // USUARIO
            services.AddScoped<FrmLogin>()
                .AddScoped<UsuarioController>()
                .AddScoped<IEncriptarApplicationService, EncriptarApplicationService>()
                .AddScoped<ILoginAppService<Usuario>, LoginAppService>()
                .AddScoped<IApplicationManager<Usuario>, ApplicationManager<Usuario>>()
                .AddScoped<IRepositoryManager<Usuario>, RepositoryManager<Usuario>>();

            // PLAZO FIJO
            services.AddScoped<FrmPlazoFijo>()
                .AddScoped<PlazoFijoController>()
                .AddScoped<IPlazoFijoRepository, PlazoFijoRepository>()
                .AddScoped<IPlazoFijoApplicationService, PlazoFijoApplicationService>();
                
            services.AddScoped<IApplicationManager<Telefono>, ApplicationManager<Telefono>>()
                .AddScoped<IApplicationManager<Componente>, ApplicationManager<Componente>>()
                .AddScoped<IApplicationManager<UsuarioPermiso>, ApplicationManager<UsuarioPermiso>>()
                .AddScoped<IApplicationManager<Permiso>, ApplicationManager<Permiso>>()

                
                .AddScoped<IRepositoryManager<Telefono>, RepositoryManager<Telefono>>()
                .AddScoped<IRepositoryManager<Componente>, RepositoryManager<Componente>>()
                .AddScoped<IRepositoryManager<Permiso>, RepositoryManager<Permiso>>()
                .AddScoped<IRepositoryManager<UsuarioPermiso>, RepositoryManager<UsuarioPermiso>>()
                
                .AddScoped<IDbContext<Usuario>, DbContext<Usuario>>()
                .AddScoped<IDbContext<Telefono>, DbContext<Telefono>>()
                .AddScoped<IDbContext<Componente>, DbContext<Componente>>()
                .AddScoped<IDbContext<Permiso>, DbContext<Permiso>>()
                .AddScoped<IDbContext<UsuarioPermiso>, DbContext<UsuarioPermiso>>()

                .AddScoped<IUsuarioDbContext, UsuarioDbContext>()

                .AddScoped<IDataProtectorApp, DataProtectorAppService>()

                .AddScoped(typeof(IEncriptarApplicationService), typeof(EncriptarApplicationService))
                .AddScoped(typeof(ILoginAppService<Usuario>), typeof(LoginAppService))
                .AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));

            services.AddDataProtection();
        }
    }
}