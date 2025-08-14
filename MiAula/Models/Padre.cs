namespace MiAula.Models
{
    public class Padre
    {
        public int PadreId { get; set; }
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Relacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Padre(int padreId, int alumnoId, string nombre, string apellido, string relacion, string telefono, string correo)
        {
            PadreId = padreId;
            AlumnoId = alumnoId;
            Nombre = nombre;
            Apellido = apellido;
            Relacion = relacion;
            Telefono = telefono;
            Correo = correo;
        }
    }
}
