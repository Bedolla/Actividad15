using SQLite;

namespace Actividad.Mobile.Models
{
    public class Base
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
