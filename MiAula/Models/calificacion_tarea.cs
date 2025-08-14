using System.Text.Json.Serialization;

namespace MiAula.Models
{
    public class calificacion_tarea
    {

        public int Id_tarea { get; set; }
        public int Id_alumno { get; set; }
        public int Id_clase { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }

        [JsonConstructor]
        public calificacion_tarea(int id_tarea, int id_alumno, int id_clase, int nota, string comentario)
        {

            Id_tarea = id_tarea;
            Id_alumno = id_alumno;
            Id_clase = id_clase;
            Nota = nota;
            Comentario = comentario;
        }

    }
}
