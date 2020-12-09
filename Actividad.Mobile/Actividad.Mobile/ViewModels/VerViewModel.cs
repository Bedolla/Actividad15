using Actividad.Data.Entities;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace Actividad.Mobile.ViewModels
{
    public class VerViewModel : BaseViewModel
    {
        private Estacionamiento _estacionamiento;

        public VerViewModel(Estacionamiento estacionamiento)
        {
            this.Estacionamiento = estacionamiento;

            this.Inicializar();
        }

        public VerViewModel() { }

        public ObservableCollection<Pin> Pines { get; set; }

        public Estacionamiento Estacionamiento
        {
            get => this._estacionamiento;
            set
            {
                this._estacionamiento = value;
                this.OnPropertyChanged();
            }
        }
        
        private void Inicializar()
        {
            this.Pines = new ObservableCollection<Pin>
            {
                new Pin
                {
                    Label = $"{this.Estacionamiento.Nombre}",
                    Address = $"{this.Estacionamiento.Calle} {this.Estacionamiento.Numero}, {this.Estacionamiento.Colonia}",
                    Position = new Position(Convert.ToDouble(this.Estacionamiento.Latitud), Convert.ToDouble(this.Estacionamiento.Longitud)),
                    Type = PinType.Place
                }
            };
        }
    }
}
