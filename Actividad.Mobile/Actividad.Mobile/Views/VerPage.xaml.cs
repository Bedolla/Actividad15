using Actividad.Data.Entities;
using Actividad.Mobile.Services;
using Actividad.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Actividad.Mobile.Views
{
    public partial class VerPage : ContentPage
    {
        public VerPage(Estacionamiento estacionamiento)
        {
            this.InitializeComponent();

            this.BindingContext = Dependencia.Obtener<VerViewModel>(estacionamiento);

            //Location ubicacion = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(30)), new CancellationTokenSource().Token);
            this.Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(estacionamiento.Latitud), Convert.ToDouble(estacionamiento.Longitud)), Distance.FromMeters(200)));
        }
    }
}
