using Actividad.Data.Constants;
using Actividad.Data.Entities;
using Actividad.Mobile.ViewModels;
using Actividad.Mobile.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace Actividad.Mobile.Services
{
    public static class Dependencia
    {
        private static IServiceProvider Proveedor { get; set; }

        public static Page Inicio
        {
            get => Application.Current.MainPage;
            set => Application.Current.MainPage = value;
        }

        public static INavigation Navegacion => Application.Current.MainPage is MasterDetailPage masta ? masta.Detail.Navigation : Application.Current.MainPage.Navigation;

        public static T Obtener<T>(params object[] parametros) where T : class =>
            parametros is null ?
                ActivatorUtilities.CreateInstance<T>(Dependencia.Proveedor) :
                ActivatorUtilities.CreateInstance<T>(Dependencia.Proveedor, parametros);

        private static IServiceCollection ConfigurarServicios(this IServiceCollection servicios)
        {
            servicios.AddHttpClient<IServicioUsuarios, ServicioUsuarios>(c => c.BaseAddress = new Uri(Uris.Api));
            servicios.AddHttpClient<IServicioEstacionamientos, ServicioEstacionamientos>(c => c.BaseAddress = new Uri(Uris.Api));

            servicios.AddTransient<Usuario>();
            servicios.AddTransient<Estacionamiento>();

            servicios.AddTransient<VerPage>();
            servicios.AddTransient<LeerBorrarPage>();
            servicios.AddTransient<CrearEditarPage>();

            servicios.AddTransient<VerViewModel>();
            servicios.AddTransient<LeerBorrarViewModel>();
            servicios.AddTransient<CrearEditarViewModel>();

            return servicios;
        }

        public static void Inicializar() =>
            Dependencia.Proveedor = new ServiceCollection()
                                    .ConfigurarServicios()
                                    .BuildServiceProvider();
    }
}
