
using MiAula.Models;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiAula.Services
{
    public class ClaseAPI
    {
        public static List<Clase> getAll()
        {
            List<Clase> clases = new List<Clase>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase";
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                clases = result.Content.ReadFromJsonAsync<List<Clase>>().Result;
                return clases;
            }
            return clases;

        }

        public static Clase get_Clase(int id)
        {
            Clase clase = null;
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/" + id;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                clase = result.Content.ReadFromJsonAsync<Clase>().Result;
                return clase;
            }
            return clase;

        }

        public static List<Clase> get_Clases_bySeccionGrado(string seccion, string Grado)
        {
            List<Clase> clases = new List<Clase>();
            HttpClient client = new HttpClient();



            string url = ConexionAPI.URLBase + "/Clase/Clase?seccion=" + seccion + "&Grado=" + Grado;
            
            var postTask = client.GetAsync(url);

            var result = postTask.Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var resultadoTask = result.Content.ReadFromJsonAsync<List<Clase>>();
                resultadoTask.Wait();
                clases = resultadoTask.Result;
                return clases;
            }

            return clases;
        }

        public static bool Edit_Clase(int id, string Nombre, string Grado, string Seccion, string Horario)
        {
            HttpClient client = new HttpClient();
            var datos = new
            {
                id = id,
                Nombre = Nombre,
                Grado = Grado,
                Seccion = Seccion,
                Horario = Horario
                
            };
            string url = ConexionAPI.URLBase + "/Clase/" + id;
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
        public static bool Delete_Clase(int id)
        {
            
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/" + id;
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

        public static bool Create_Clase(string Nombre, string Grado, string Seccion, string Horario)
        {
            HttpClient client = new HttpClient();
            var datos = new
            {
                Nombre = Nombre,
                Grado = Grado,
                Seccion = Seccion,
                Horario = Horario,
                id = 0
            };
            string url = ConexionAPI.URLBase + "/Clase";
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

        public static List<Clase> ClaseSinPlanificacion(string grado,string seccion)
        {


            List<Clase> clases = new List<Clase>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/ClaseSInP?grado="+grado+"&seccion="+seccion;
            var getTask = client.GetAsync(url);
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                clases = result.Content.ReadFromJsonAsync<List<Clase>>().Result;
                return clases;
            }
            return clases;
        }

        public static List<Clase> ClaseConPlanificacion(string grado, string seccion)
        {


            List<Clase> clases = new List<Clase>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/ClaseConP?grado=" + grado + "&seccion=" + seccion;
            var getTask = client.GetAsync(url);
            
            getTask.Wait();
            var result = getTask.Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                clases = result.Content.ReadFromJsonAsync<List<Clase>>().Result;
                return clases;
            }
            return clases;
        }

        public static List<Alumno> Alumnos_EN_CLASE(int idClase)
        {


            List<Alumno> alumnos = new List<Alumno>();
            HttpClient client = new HttpClient();
            string url = ConexionAPI.URLBase + "/Clase/Alumnos_EN_CLASE?id_clase="+idClase;
                                       

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


