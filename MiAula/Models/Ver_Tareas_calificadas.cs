using MiAula.ModelS;
using System.Text.Json.Serialization;

namespace MiAula.Models
{

    public class Ver_Tareas_calificadas
    {
        public int id_tarea { get; set; }

        public int id_clase { get; set; }
        public int id_alumno { get; set; }

        public int nota { get; set; }

        public string comentario { get; set; }

        public Alumno alumno { get; set; }
        public Tarea tarea { get; set; }

        public Clase clase { get; set; }

        public Planificacion planificacion { get; set; }

        public Ver_Tareas_calificadas(int id_tarea, int id_clase, int id_alumno, int nota, string comentario)
        {
            this.id_tarea = id_tarea;
            this.id_clase = id_clase;
            this.id_alumno = id_alumno;
            this.nota = nota;
            this.comentario = comentario;
            this.alumno = null;
            this.tarea = null;
            this.clase = null;
            this.planificacion = null;

        }
    }

}