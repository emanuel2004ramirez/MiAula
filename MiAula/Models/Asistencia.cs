namespace MiAula.Models
{
    public class Asistencia
    {

        public int Id { get; set; }
        public int AlumnoId { get; set; }
     

        public string Estado { get; set; }

        public Asistencia(int id, int alumnoId,  string estado)
        {
            Id = id;
            AlumnoId = alumnoId;
            
            Estado = estado;
        }

    }

}