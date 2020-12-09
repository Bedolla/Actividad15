namespace Actividad.Data.Entities
{
    public class Estacionamiento
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Calificacion { get; set; }
        public string Numero { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
