namespace MiAula.Models
{
    public class Calificar_Lista_Alumno_id_Clase
    {
        public List<Alumno> alumnos;
        public int id_clase;
        public Alumno alumno;
        public List<Tarea> tareas;
        public Examen examen;
        public List<Ver_Tareas_calificadas> tareas_calificadas;

        public Calificar_Lista_Alumno_id_Clase()
        {
            this.alumnos = new List<Alumno>();
            this.id_clase = 0;
            this.alumno = null;
            this.tareas = new List<Tarea>();
            this.examen = null;
            this.tareas_calificadas = new List<Ver_Tareas_calificadas>();
        }


    }
}
