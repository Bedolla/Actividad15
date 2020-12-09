using Actividad.Data.Entities;
using System;
using System.Linq;

namespace Actividad.Api.Repositories
{
    public static class QueryableExtensions
    {
        public static IQueryable<Usuario> Buscar(this IQueryable<Usuario> usuarios, string terminoBuscado) =>
            String.IsNullOrWhiteSpace(terminoBuscado) ?
                usuarios :
                usuarios.Where
                (u =>
                    u.Nombre.Contains(terminoBuscado) ||
                    u.Apellido.Contains(terminoBuscado) ||
                    u.Correo.Contains(terminoBuscado)
                );
    }
}
