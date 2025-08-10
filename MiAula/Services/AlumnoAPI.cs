using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public class AlumnoAPI
    {
        public static List<Alumno> getAll()
        {
            List<Alumno> alumno = new List<Alumno>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Alumno";
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                alumno = result.Content.ReadFromJsonAsync<List<Alumno>>().Result;
                return alumno;
            }
            return alumno;

        }

        public static Alumno get_Alumno(int id)
        {
            Alumno alumno = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Alumno/" + id;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                alumno = result.Content.ReadFromJsonAsync<Alumno>().Result;
                return alumno;
            }
            return alumno;

        }

        public static bool Edit_Alumno(int id, string nombre, string apellido, string fv, string grado, string seccion)
        {
            HttpClient client = new HttpClient();
            var datos = new
            {
                id = id,
                nombre = nombre,
                apellido = apellido,
                fecha_nacimiento = fv,
                grado = grado,
                seccion = seccion

            };
            string url = ConexionAPI.URLBase + "/Alumno/" + id;
            var putTask = client.PutAsJsonAsync(url, datos);
            putTask.Wait();
            var result = putTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var resultadoTask = result.Content.ReadFromJsonAsync<bool>();
                resultadoTask.Wait();
                return resultadoTask.Result;
            }
            return false;
        }
        public static bool Delete_Alumno(int id)
        {

            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Alumno/" + id;
            var getTask = client.DeleteAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var resultadoTask = result.Content.ReadFromJsonAsync<bool>();
                resultadoTask.Wait();

                return resultadoTask.Result;
            }
            return false;

        }

        public static bool Create_Alumno(string nombre, string apellido, string fecha_nacimiento, string grado, string seccion)
        {
            HttpClient client = new HttpClient();
            var datos = new
            {
                nombre = nombre,
                apellido = apellido,
                fecha_nacimiento = fecha_nacimiento,
                grado = grado,
                seccion = seccion,
                id = 0
            };
            string url = ConexionAPI.URLBase + "/Alumno";
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

        public static Alumno buscar (int id)
        {
            Alumno alumno = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Alumno/" + id;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                alumno = result.Content.ReadFromJsonAsync<Alumno>().Result;
                return alumno;
            }
            return alumno;
        }
    }
}
