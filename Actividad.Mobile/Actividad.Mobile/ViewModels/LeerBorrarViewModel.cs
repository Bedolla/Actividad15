using Actividad.Data.Entities;
using Actividad.Mobile.Extensions;
using Actividad.Mobile.Services;
using Actividad.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Actividad.Mobile.ViewModels
{
    public class LeerBorrarViewModel : BaseViewModel
    {
        private string _buscado;
        private ObservableCollection<Estacionamiento> _estacionamientos;
        private string _informacion;
        private Estacionamiento _seleccionado;

        public LeerBorrarViewModel(IServicioEstacionamientos servicioEstacionamientos)
        {
            this.ServicioEstacionamientos = servicioEstacionamientos;

            this.AgregarCommand = new Command(this.Agregar);
            this.BorrarCommand = new Command<Estacionamiento>(this.Borrar);
            this.EditarCommand = new Command<Estacionamiento>(this.Editar);
            this.BuscarCommand = new Command<string>(this.Buscar);
        }

        public LeerBorrarViewModel() { }

        private IServicioEstacionamientos ServicioEstacionamientos { get; }

        public ObservableCollection<Estacionamiento> Estacionamientos
        {
            get => this._estacionamientos;
            set
            {
                this._estacionamientos = value;
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

        public Estacionamiento Seleccionado
        {
            get => this._seleccionado;
            set
            {
                this._seleccionado = value;
                if (value != null) this.Ver(value);
            }
        }

        public string Buscado
        {
            get => this._buscado;
            set
            {
                this._buscado = value;
                if (value.EsNulo()) this.Buscar(value);
                this.OnPropertyChanged();
            }
        }

        public ICommand AgregarCommand { get; set; }
        public ICommand BorrarCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand BuscarCommand { get; set; }

        public async void ListarEstacionamientos()
        {
            try
            {
                List<Estacionamiento> estacionamientos = await this.ServicioEstacionamientos.ObtenerTodosAsync();

                if ((estacionamientos != null) && (estacionamientos.Count > 0))
                {
                    this.Estacionamientos = new ObservableCollection<Estacionamiento>
                    (
                        estacionamientos
                            .OrderBy(p => p.Municipio)
                            .ThenBy(p => p.Colonia)
                            .ThenBy(p => p.Calle)
                            .ThenBy(p => p.Nombre)
                            .ToList()
                    );

                    this.Informacion = $"{estacionamientos.Count} {(estacionamientos.Count.Equals(1) ? "estacionamiento encontrado" : "estacionamientos encontrados")}";
                }
                else
                {
                    this.Estacionamientos = new ObservableCollection<Estacionamiento>();
                    this.Informacion = "No hay estacionamientos, agrégue uno";
                }
            }

            catch (Exception excepcion)
            {
                this.Informacion = excepcion.Message;
            }
        }

        private async void Agregar() => await Dependencia.Navegacion.PushAsync(Dependencia.Obtener<CrearEditarPage>(null));

        private async void Borrar(Estacionamiento estacionamiento)
        {
            if (!await Application.Current.MainPage.DisplayAlert("Borrar", $"¿Realmente desea borrar a {estacionamiento.Nombre}?", "Sí", "No")) return;

            try
            {
                await this.ServicioEstacionamientos.BorrarAsync(estacionamiento.Id);

                this.ListarEstacionamientos();
            }

            catch (Exception excepcion)
            {
                this.Informacion = excepcion.Message;
            }
        }

        private async void Editar(Estacionamiento estacionamiento) => await Dependencia.Navegacion.PushAsync(Dependencia.Obtener<CrearEditarPage>(estacionamiento));

        private async void Ver(Estacionamiento estacionamiento) => await Dependencia.Navegacion.PushAsync(Dependencia.Obtener<VerPage>(estacionamiento));

        private async void Buscar(string consulta)
        {
            if (consulta.EsNulo())
            {
                this.ListarEstacionamientos();
            }
            else
            {
                consulta = consulta.RemoverDiacriticos().ToLower();

                this.Estacionamientos = new ObservableCollection<Estacionamiento>
                (
                    (await this.ServicioEstacionamientos.ObtenerTodosAsync())
                    .Where
                    (
                        u =>
                            u.Nombre.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Descripcion.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Costo.ToString(CultureInfo.CurrentCulture).RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Calificacion.ToString(CultureInfo.CurrentCulture).RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Numero.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Calle.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Colonia.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.CodigoPostal.RemoverDiacriticos().ToLower().Contains(consulta) ||
                            u.Municipio.RemoverDiacriticos().ToLower().Contains(consulta)
                    )
                    .OrderBy(p => p.Municipio)
                    .ThenBy(p => p.Colonia)
                    .ThenBy(p => p.Calle)
                    .ThenBy(p => p.Nombre)
                    .ToList()
                );

                this.Informacion = $"{this.Estacionamientos.Count} {(this.Estacionamientos.Count.Equals(1) ? "estacionamiento encontrado" : "estacionamientos encontrados")}";
            }
        }
    }
}
