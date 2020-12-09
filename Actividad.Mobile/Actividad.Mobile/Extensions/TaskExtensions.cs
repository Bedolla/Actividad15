using System;
using System.Threading.Tasks;

namespace Actividad.Mobile.Extensions
{
    public static class TaskExtensions
    {
        public static async void DispararOlvidarSeguro
        (
            this Task tarea,
            bool regresarAlContextoLlamante,
            Action<Exception> enExcepcion = null
        )
        {
            try
            {
                await tarea.ConfigureAwait(regresarAlContextoLlamante);
            }

            catch (Exception excepcion) when (enExcepcion != null)
            {
                enExcepcion(excepcion);
            }
        }
    }
}
