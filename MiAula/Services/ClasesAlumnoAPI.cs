using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public class ClasesAlumnoAPI
    {

        public static bool AsignarClases_Alumno(int idAlumno, List<int> idsClases)
        {
            HttpClient client = new HttpClient();

            var datos = new 
            {
                idAlumno = idAlumno,
                idClases = idsClases
            };

            string url = ConexionAPI.URLBase + "/AlumnoClases";

            var postTask = client.PostAsJsonAsync(url, datos);
            postTask.Wait();

            var result = postTask.Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultadoTask = result.Content.ReadFromJsonAsync<bool>();
                resultadoTask.Wait();
                return resultadoTask.Result;
            }

            return false;
        }

        public static List<Alumno> AlumnoNoTieneClases(string seccion, string Grado)
        {

            List<Alumno> alumnos = new List<Alumno>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/AlumnoClases?"+"grado="+Grado+"&seccion="+seccion;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                alumnos = result.Content.ReadFromJsonAsync<List<Alumno>>().Result;
                return alumnos;
            }
            return alumnos;
        }

    }

}
