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
    }
}
