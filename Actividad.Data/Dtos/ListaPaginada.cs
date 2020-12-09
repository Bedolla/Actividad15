using System.Collections.Generic;

namespace Actividad.Data.Dtos
{
    public class ListaPaginada<T> where T : class
    {
        public List<T> Lista { get; set; }
        public PaginacionMetaData MetaData { get; set; }
    }

    public class PaginacionPeticion
    {
        private const int TamanoMaximoPagina = 50;

        private int _cantidadPorPagina = 5;

        public int CantidadPorPagina
        {
            get => this._cantidadPorPagina;
            set => this._cantidadPorPagina = value > PaginacionPeticion.TamanoMaximoPagina ? PaginacionPeticion.TamanoMaximoPagina : value;
        }

        public string TerminoBuscado { get; set; }
        public string OrdenarPor { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public string Id { get; set; }
    }

    public class PaginacionMetaData
    {
        public int PaginaActual { get; set; }
        public int PaginasTotales { get; set; }
        public int TamanoPagina { get; set; }
        public int CantidadTotal { get; set; }

        public bool TieneAnterior => this.PaginaActual > 1;
        public bool TieneSiguiente => this.PaginaActual < this.PaginasTotales;
    }
}
