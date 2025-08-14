using System.Text.Json.Serialization;

namespace MiAula.Models
{
    public class calificacion_examen
    {

       

        public int id_alumno { get; set; }
        public int id_clase { get; set; }
        public string nota { get; set; }
        public string comentario { get; set; }

        [JsonConstructor]
        public calificacion_examen(int id_alumno, int id_clase, string nota, string comentario)
        {
        
            this.id_alumno = id_alumno;
            this.id_clase = id_clase;
            this.nota = nota;
            this.comentario = comentario;
        }
    }
}