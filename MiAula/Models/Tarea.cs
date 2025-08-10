using System.Text.Json.Serialization;

namespace MiAula.Models
{
    public class Tarea
    {
        public int Id_Planificacion { get; set; }
        public int Id_Clase { get; set; }
        public string Tema { get; set; }
        public string Objetivo { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Porcentaje_Tareas { get; set; }
        public string Porcentaje_Examenes { get; set; }
        public int Id_Tarea { get; set; }

        public string Tareaa { get; set; }
        public string Tipo { get; set; }
        public string Archivo { get; set; }
        public string Fecha_Limite { get; set; }

        public string Nombre_Clase { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Horario { get; set; }

        [JsonConstructor]
        public Tarea(int id_planificacion, int id_clase, string tema, string objetivo, string fecha_inicio, string fecha_fin,
            string porcentaje_tareas, string porcentaje_examenes, int id_tarea, string tareaa, string tipo, string archivo,
            string fecha_limite, string nombre_clase, string grado, string seccion, string horario)
        {
            Id_Planificacion = id_planificacion;
            Id_Clase = id_clase;
            Tema = tema;
            Objetivo = objetivo;
            Fecha_Inicio = fecha_inicio;
            Fecha_Fin = fecha_fin;
            Porcentaje_Tareas = porcentaje_tareas;
            Porcentaje_Examenes = porcentaje_examenes;
            Id_Tarea = id_tarea;
            Tareaa = tareaa;
            Tipo = tipo;
            Archivo = archivo;
            Fecha_Limite = fecha_limite;
            Nombre_Clase = nombre_clase;
            Grado = grado;
            Seccion = seccion;
            Horario = horario;
        }

        public Tarea() { }
    }
}

