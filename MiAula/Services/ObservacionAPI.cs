using MiAula.Models;
using System.Net;

namespace MiAula.Services
{
    public class ObservacionAPI
    {
        public static bool CrearObservacion(int ObservacionId, int AlumnoId, string Tipo, string Comentario)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ConexionAPI.URLBase + "/Observacion";
                var datos = new
                {
                    observacionId = 0,
                    alumnoId = AlumnoId,
                    fecha = "",
                    tipo = Tipo,
                    comentario = Comentario
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

            public static List<Observacion> GetObservacionesPorAlumno(int alumnoId)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string url = ConexionAPI.URLBase + "/Observacion/" + alumnoId;

                        var getTask = client.GetAsync(url);
                        getTask.Wait();

                        var result = getTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadFromJsonAsync<List<Observacion>>();
                            readTask.Wait();
                            return readTask.Result;
                        }
                        return new List<Observacion>();
                    }



        }




    }
}
