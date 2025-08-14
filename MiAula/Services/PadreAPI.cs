using MiAula.Models;
using System.Globalization;
using System.Net;

namespace MiAula.Services
{
    public class PadreAPI
    {
        public static bool CrearPadre(int padreId, int alumnoId, string nombre, string apellido, string relacion, string telefono, string correo)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ConexionAPI.URLBase + "/Padre";
                var datos = new
                {
                    padreId = 0,
                    alumnoId = alumnoId,
                    nombre = nombre,
                    apellido = apellido,
                    relacion = relacion,
                    telefono = telefono,
                    correo = correo
                };
                var postTask = client.PostAsJsonAsync(url, datos);
                postTask.Wait();
                var result = postTask.Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var resultadoTask = result.Content.ReadFromJsonAsync<bool>();
                    resultadoTask.Wait();
                    return resultadoTask.Result;
                }
                return false;
            }

        }

        public static List<Padre> GetPadresPorAlumno(int alumnoId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ConexionAPI.URLBase + "/Padre/" + alumnoId;
                var getTask = client.GetAsync(url);
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<Padre>>();
                    readTask.Wait();
                    return readTask.Result;
                }
                return new List<Padre>();
            }
        }
    }
}
