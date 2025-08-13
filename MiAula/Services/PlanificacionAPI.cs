
using API_MI_AULA.Models;
using MiAula.Models;
using MiAula.ModelS;
using System.Net;

namespace MiAula.Services
{
    public static class PlanificacionAPI
    {
        public static bool CrearPlanificacion(T_E planificacion)
        {

            HttpClient client = new HttpClient();


            string url = ConexionAPI.URLBase + "/Planificacion";

            var postTask = client.PostAsJsonAsync(url, planificacion);
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

        public static bool EliminarPlanificacion(int id)
        {
            HttpClient client = new HttpClient();


            string url = ConexionAPI.URLBase + "/Planificacion/"+id
            ;

            var delTask = client.DeleteAsync(url);
            delTask.Wait();

            var result = delTask.Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultadoTask = result.Content.ReadFromJsonAsync<bool>();
                resultadoTask.Wait();
                return resultadoTask.Result;
            }

            return false;

        }

        public static List<Planificacion> Planificacion (int id)
        {
            List<Planificacion> planificacion = new List<Planificacion>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/Planificacion?id="+id;




            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                planificacion = result.Content.ReadFromJsonAsync<List<Planificacion>>().Result;
                return planificacion;
            }
            return planificacion;

        }

    }
}

                                                

