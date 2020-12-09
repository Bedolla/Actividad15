using Actividad.Data.Entities;
using Actividad.Mobile.Services;
using Actividad.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Actividad.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearEditarPage : ContentPage
    {
        public CrearEditarPage(Estacionamiento estacionamiento)
        {
            this.InitializeComponent();

            this.BindingContext = Dependencia.Obtener<CrearEditarViewModel>(estacionamiento); 
        }
    }
}
