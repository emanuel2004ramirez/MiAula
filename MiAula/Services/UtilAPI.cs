using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public class UtilAPI
    {


        public static bool Create_Util(int claseId, string nombre, bool obligatorio)
        {
            HttpClient client = new HttpClient();

            // Crear objeto a enviar
            var util = new Util(0, claseId, nombre, obligatorio);

            string url = ConexionAPI.URLBase + "/Util"; // Ajusta la URL si tu endpoint es diferente
            var postTask = client.PostAsJsonAsync(url, util);
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

        public static List<UtilEstadistica> GetEstadisticas(int claseId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ConexionAPI.URLBase + "/Util/" + claseId;
                var getTask = client.GetAsync(url);
                getTask.Wait();
                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<UtilEstadistica>>();
                    readTask.Wait();
                    return readTask.Result;
                }
                return new List<UtilEstadistica>();
            }
        }

        public static List<Util> GetUtilesPorMateria(int materiaId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ConexionAPI.URLBase + "/Util/" + materiaId;
                var getTask = client.GetAsync(url);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<Util>>();
                    readTask.Wait();
                    return readTask.Result ?? new List<Util>();
                }

                return new List<Util>();
            }
        }

    }
}
