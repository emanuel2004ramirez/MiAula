
using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public static class PlanificacionAPI
    {
        public static bool CrearPlanificacion(List<Tema> tema)
        {

            HttpClient client = new HttpClient();


            string url = ConexionAPI.URLBase + "/Planificacion";

            var postTask = client.PostAsJsonAsync(url, tema);
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

        public static List<Tarea> Planificacion (string grado, string seccion)
        {
            List<Tarea> tareas = new List<Tarea>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/Planificacion?grado=" + grado + "&seccion=" + seccion;
                                               


            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                tareas = result.Content.ReadFromJsonAsync<List<Tarea>>().Result;
                return tareas;
            }
            return tareas;

        }

    }
}

                                                

