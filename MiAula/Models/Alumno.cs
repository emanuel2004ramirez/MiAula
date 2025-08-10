using System.Globalization;

namespace MiAula.Models
{
    public class Alumno
    {


        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        

        // Constructor
        public Alumno(int id, string nombre, string apellido, string fecha_nacimiento, string grado, string seccion)
        {
            
            Id= id;
            Nombre = nombre;
            Apellido = apellido;
            Fecha_Nacimiento = fecha_nacimiento;
            Grado = grado;
            Seccion = seccion;

        }
    }
}
