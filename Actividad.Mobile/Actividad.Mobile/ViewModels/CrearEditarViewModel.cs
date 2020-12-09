using Actividad.Data.Entities;
using Actividad.Mobile.Extensions;
using Actividad.Mobile.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Actividad.Mobile.ViewModels
{
    public class CrearEditarViewModel : BaseViewModel
    {
        private string _botonGuardar;
        private Estacionamiento _estacionamiento;
        private string _informacion;

        public CrearEditarViewModel
        (
            IServicioEstacionamientos servicioEstacionamientos,
            Estacionamiento estacionamiento
        )
        {
            this.ServicioEstacionamientos = servicioEstacionamientos;

            this.LimpiarCommand = new Command(this.Limpiar);
            this.GuardarCommand = new Command(this.Guardar);

            if (estacionamiento is null || estacionamiento.Id.EsNulo())
            {
                this.Limpiar();
            }
            else
            {
                this.Estacionamiento = estacionamiento;
                this.BotonGuardar = "Editar";
            }
        }

        public CrearEditarViewModel() { }

        private IServicioEstacionamientos ServicioEstacionamientos { get; }

        public Estacionamiento Estacionamiento
        {
            get => this._estacionamiento;
            set
            {
                this._estacionamiento = value;
                this.OnPropertyChanged();
            }
        }

        public string Informacion
        {
            get => this._informacion;
            set
            {
                this._informacion = value;
                this.OnPropertyChanged();
            }
        }

        public string BotonGuardar
        {
            get => this._botonGuardar;
            set
            {
                this._botonGuardar = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand LimpiarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }

        private async void Guardar()
        {
            try
            {
                if
                (
                    this.Estacionamiento.Nombre.EsNulo() ||
                    this.Estacionamiento.Descripcion.EsNulo() ||
                    this.Estacionamiento.Numero.EsNulo() ||
                    this.Estacionamiento.Calle.EsNulo() ||
                    this.Estacionamiento.Colonia.EsNulo() ||
                    this.Estacionamiento.CodigoPostal.EsNulo() ||
                    this.Estacionamiento.Municipio.EsNulo() ||
                    this.Estacionamiento.Latitud.EsNulo() ||
                    this.Estacionamiento.Longitud.EsNulo()
                )
                {
                    this.Informacion = "Debe llenar todos los campos";
                    return;
                }

                if (this.Estacionamiento.Id.EsNulo())
                {
                    this.Estacionamiento.Id = Guid.NewGuid().ToString();

                    await this.ServicioEstacionamientos.CrearAsync(this.Estacionamiento);
                }
                else
                {
                    await this.ServicioEstacionamientos.EditarAsync(this.Estacionamiento);
                }

                if (this.BotonGuardar.Equals("Crear"))
                {
                    this.Estacionamiento.Id = null;
                    this.Limpiar();
                    this.Informacion = "Estacionamiento creado";
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso", "Estacionamiento editado", "Entendido");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception excepcion)
            {
                this.Informacion = excepcion.Message;
            }
        }

        private void Limpiar()
        {
            this.Estacionamiento = new Estacionamiento
            {
                Id = this.Estacionamiento?.Id.Valor(),
                Nombre = default,
                Descripcion = default,
                Costo = default,
                Calificacion = default,
                Numero = default,
                Calle = default,
                Colonia = default,
                CodigoPostal = default,
                Municipio = default,
                Latitud = default,
                Longitud = default
            };

            this.Informacion = String.Empty;
            this.BotonGuardar = this.Estacionamiento.Id.EsNulo() ? "Crear" : "Editar";
        }
    }
}
