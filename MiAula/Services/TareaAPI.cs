using MiAula.Models;

namespace MiAula.Services
{
    public class TareaAPI
    {


        public static List<Tarea> GetTarea_ByID(int id)
        {
            List<Tarea> tareas = new List<Tarea>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea?id=" + id;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                tareas = result.Content.ReadFromJsonAsync<List<Tarea>>().Result;
                return tareas;
            }
            return tareas;
        }

        public static List<Tarea> GetTarea_By_Materia_ID(string tema, int id)
        {
            List<Tarea> tareas = new List<Tarea>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea/ID_MATERIA?tema=" + tema + "&id=" + id;
                                                
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                tareas = result.Content.ReadFromJsonAsync<List<Tarea>>().Result;
                return tareas;
            }
            return tareas;
        }

        public static Examen Get_ExamenBY_IDCLASE(int id)
        {
            Examen examen = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea/Get_ExamenBY_IDCLASE?id="+id;

            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                examen = result.Content.ReadFromJsonAsync<Examen>().Result;
                return examen;
            }
            return examen;

        }

        public static bool Calificar_Tarea(List<calificacion_tarea> tarea)
        {

            
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea";
            var json = System.Text.Json.JsonSerializer.Serialize(tarea);
            Console.WriteLine(json);

            var postTask = client.PostAsJsonAsync(url, tarea);
            postTask.Wait();
            var result = postTask.Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;

        }

        public static bool Calificar_Examen(calificacion_examen examen)
        {
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea/CalificarExamen";
            var postTask = client.PostAsJsonAsync(url, examen);
            postTask.Wait();
            var result = postTask.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static Tarea Tarea_ByID(int id)
        {
            Tarea tarea = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Tarea/tarea/"+id;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                tarea = result.Content.ReadFromJsonAsync<Tarea>().Result;
                return tarea;
            }
            return tarea;
        }
    }
}
