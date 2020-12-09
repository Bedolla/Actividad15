using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms.Internals;

namespace Actividad.Mobile.Extensions
{
    public static class StringExtensions
    {
        public static string RemoverDiacriticos(this string textoConDiacriticos)
        {
            string palabra = textoConDiacriticos.Normalize(NormalizationForm.FormD);
            StringBuilder textoSinDiacriticos = new StringBuilder();

            palabra.ForEach(letra =>
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark) textoSinDiacriticos.Append(letra);
            });

            return textoSinDiacriticos.ToString().Normalize(NormalizationForm.FormC);
        }

        public static bool EsNulo(this string id) => String.IsNullOrWhiteSpace(id);

        public static string Valor(this string id) => String.IsNullOrWhiteSpace(id) ? null : id;
    }
}
