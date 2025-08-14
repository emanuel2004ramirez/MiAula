using MiAula.Models;
using System.Globalization;
using System.Net;
namespace MiAula.Services

{
    public class AsistenciaAPI
    {


        public static bool Create_Asistencia(int AlumnoId, String estado)
        {
            HttpClient client = new HttpClient();
            var datos = new
            {
                AlumnoId = AlumnoId,
                Estado = estado,
                id = 0
            };
            string url = ConexionAPI.URLBase + "/Asistencia";
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

        public static EstadisticaAlumno get_Estadisticas(int alumnoId)
        {
            EstadisticaAlumno estadistica = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + $"/Asistencia/EstadisticaAlumno?alumnoId={alumnoId}";

            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var temp = result.Content.ReadFromJsonAsync<EstadisticaAlumno>().Result;

                int total = temp.Presente + temp.NoVino + temp.Excusa;
                double porcentaje = total > 0 ? (double)temp.Presente / total * 100 : 0;

                estadistica = new EstadisticaAlumno
                {
                    Presente = temp.Presente,
                    NoVino = temp.NoVino,
                    Excusa = temp.Excusa,
                    PorcentajePresente = Math.Round(porcentaje, 2)
                };
            }

            return estadistica;
        }

    }
}
