using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public class CalificarAPI
    {


        public static Notas_Finales_Clases Notas_Finales_Clases(Notas_Finales_Clases nota)
        {



            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Calificar/Notas_Finales_Clases";
            var postTask = client.PostAsJsonAsync(url, nota);
            postTask.Wait();
            var result = postTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return result.Content.ReadFromJsonAsync<Notas_Finales_Clases>().Result;
            }
            return null;
        }

        public static List<Ver_Tareas_calificadas> Lista_Calificacion_Tareas(int id_clase, int id_alumno)
        {

            List<Ver_Tareas_calificadas> lista = new List<Ver_Tareas_calificadas>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + $"/Alumno/Lista_calificaciones_tareas?id_clase={id_clase}&id_alumno={id_alumno}";
            var getTask = client.GetAsync(url);             
            getTask.Wait();
            var result = getTask.Result;
            
            if (result.StatusCode == HttpStatusCode.OK)
            {
                lista = result.Content.ReadFromJsonAsync<List<Ver_Tareas_calificadas>>().Result;
                return lista;
            }
            return lista;
        }
    }
}
