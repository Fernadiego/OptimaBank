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
using OptimaBank.ApplicationLogic.Menues;
using OptimaBank.ApplicationLogic.Usuarios;
using OptimaBank.SQLServerDataProvider.Usuarios;

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
                .AddScoped<IRepositoryManager<Usuario>, RepositoryManager<Usuario>>()
                .AddScoped<IDbContext<Usuario>, DbContext<Usuario>>()
                .AddScoped<IUsuarioApplicationService<Usuario>, UsuarioApplicationService>();
                //.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // USUARIO-ROL
            services.AddScoped<IUsuarioRolApplicationService<UsuarioRol>, UsuarioRolApplicationService>()
                .AddScoped<IRepositoryManager<UsuarioRol>, RepositoryManager<UsuarioRol>>()
                .AddScoped<IDbContext<UsuarioRol>, DbContext<UsuarioRol>>()
                .AddScoped<IUsuarioDbContext, UsuarioDbContext>();

            // MENU
            services.AddScoped<MenuController>()
                .AddScoped<IMenuApplicationService<Menu>, MenuApplicationService>()
                .AddScoped<IApplicationManager<Menu>, ApplicationManager<Menu>>()
                .AddScoped<IRepositoryManager<Menu>, RepositoryManager<Menu>>()
                .AddScoped<IDbContext<Menu>, DbContext<Menu>>();

            // SUBMENU
            services.AddScoped<ISubMenuApplicationService<Submenu>, SubMenuApplicationService>()
                .AddScoped<IApplicationManager<Submenu>, ApplicationManager<Submenu>>()
                .AddScoped<IRepositoryManager<Submenu>, RepositoryManager<Submenu>>()
                .AddScoped<IDbContext<Submenu>, DbContext<Submenu>>();

            // PLAZO FIJO
            services.AddScoped<FrmPlazoFijo>()
                .AddScoped<PlazoFijoController>()
                .AddScoped<IPlazoFijoRepository, PlazoFijoRepository>()
                .AddScoped<IPlazoFijoApplicationService, PlazoFijoApplicationService>();
                
            services.AddScoped<IApplicationManager<Telefono>, ApplicationManager<Telefono>>()
                .AddScoped<IApplicationManager<Componente>, ApplicationManager<Componente>>()
                .AddScoped<IApplicationManager<UsuarioRol>, ApplicationManager<UsuarioRol>>()
                .AddScoped<IApplicationManager<Permiso>, ApplicationManager<Permiso>>()

                
                .AddScoped<IRepositoryManager<Telefono>, RepositoryManager<Telefono>>()
                .AddScoped<IRepositoryManager<Componente>, RepositoryManager<Componente>>()
                .AddScoped<IRepositoryManager<Permiso>, RepositoryManager<Permiso>>()
                .AddScoped<IRepositoryManager<UsuarioRol>, RepositoryManager<UsuarioRol>>()
                
                .AddScoped<IDbContext<Usuario>, DbContext<Usuario>>()
                .AddScoped<IDbContext<Telefono>, DbContext<Telefono>>()
                .AddScoped<IDbContext<Componente>, DbContext<Componente>>()
                .AddScoped<IDbContext<Permiso>, DbContext<Permiso>>()
                .AddScoped<IDbContext<UsuarioRol>, DbContext<UsuarioRol>>()

                .AddScoped<IUsuarioDbContext, UsuarioDbContext>()

                .AddScoped<IDataProtectorApp, DataProtectorAppService>()

                .AddScoped(typeof(IEncriptarApplicationService), typeof(EncriptarApplicationService))
                .AddScoped(typeof(ILoginAppService<Usuario>), typeof(LoginAppService))
                .AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));

            services.AddDataProtection();
        }
    }
}