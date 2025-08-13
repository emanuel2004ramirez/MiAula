namespace MiAula.Models
{
    public class Examen
    {
        public int Id_Clase { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public float Valor { get; set; }

        
        public Examen(int id_clase,string nombre, string fecha, float valor)
        {
            Id_Clase = id_clase;
            Nombre = nombre;
            Fecha = fecha;
            Valor = valor;
        }
    }
}
