using Actividad.Mobile.Database;
using Actividad.Mobile.Extensions;
using Actividad.Mobile.Services;
using Actividad.Mobile.Views;
using Xamarin.Forms;

namespace Actividad.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            BaseDeDatos.InicializarAsync().DispararOlvidarSeguro(false);

            Dependencia.Inicializar();

            this.MainPage = new NavigationPage(new LeerBorrarPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
