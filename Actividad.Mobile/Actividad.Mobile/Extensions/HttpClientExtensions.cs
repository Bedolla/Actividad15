using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Actividad.Mobile.Extensions
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public static Task<T> GetJsonAsync<T>(this HttpClient cliente, string uri, object cuerpo = null) => cliente.EnviarJsonAsync<T>(HttpMethod.Get, uri, cuerpo);

        public static Task PostJsonAsync(this HttpClient cliente, string uri, object cuerpo) => cliente.EnviarJsonAsync(HttpMethod.Post, uri, cuerpo);

        public static Task<T> PostJsonAsync<T>(this HttpClient cliente, string uri, object cuerpo) => cliente.EnviarJsonAsync<T>(HttpMethod.Post, uri, cuerpo);

        public static Task PutJsonAsync(this HttpClient cliente, string uri, object cuerpo) => cliente.EnviarJsonAsync(HttpMethod.Put, uri, cuerpo);

        public static Task<T> PutJsonAsync<T>(this HttpClient cliente, string uri, object cuerpo) => cliente.EnviarJsonAsync<T>(HttpMethod.Put, uri, cuerpo);

        public static Task DeleteJsonAsync(this HttpClient cliente, string uri, object cuerpo = null) => cliente.EnviarJsonAsync(HttpMethod.Delete, uri, cuerpo);

        public static Task<T> DeleteJsonAsync<T>(this HttpClient cliente, string uri, object cuerpo = null) => cliente.EnviarJsonAsync<T>(HttpMethod.Delete, uri, cuerpo);

        private static Task EnviarJsonAsync(this HttpClient cliente, HttpMethod metodo, string uri, object cuerpo) => cliente.EnviarJsonAsync<SinRespuesta>(metodo, uri, cuerpo);

        private static async Task<T> EnviarJsonAsync<T>(this HttpClient cliente, HttpMethod metodo, string uri, object cuerpo)
        {
            HttpResponseMessage respuesta = await cliente.SendAsync(new HttpRequestMessage(metodo, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(cuerpo, HttpClientExtensions.Opciones), Encoding.UTF8, "application/json")
            });

            return (typeof(T) == typeof(SinRespuesta)) || String.IsNullOrWhiteSpace(await respuesta.Content.ReadAsStringAsync()) ? default : JsonSerializer.Deserialize<T>(await respuesta.Content.ReadAsStringAsync(), HttpClientExtensions.Opciones);
        }

        private class SinRespuesta { }
    }
}
