namespace MiAula.Models
{
    public class Clase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public string Grado { get; set; }

        public string Seccion { get; set; }

        public string Horario { get; set; }

        public Clase(int id, string nombre,string grado,string seccion,string horario) { 
        
         Id = id;
            Nombre = nombre;
            Grado = grado;
            Seccion = seccion;
            Horario = horario;

        }

    }
}
