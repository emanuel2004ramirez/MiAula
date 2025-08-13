using System.Text.Json.Serialization;

namespace MiAula.Models
{
    public class Tarea
    {
        public int Id_Tarea { get; set; }
        public int Id_Clase { get; set; } 
        public string Tema { get; set; }
        public string Tareaa { get; set; }
        public string Tipo { get; set; }
        public string Archivo { get; set; }
        public string Fecha_Limite { get; set; }

        public int Valor { get; set; }

        [JsonConstructor]
        public Tarea(int id_clase,string tema, string tareaa, string tipo, string archivo, string fecha_limite, int valor)
        {
            Id_Tarea = 0;
            Id_Clase = id_clase;
            Tema = tema;
            Tareaa = tareaa;
            Tipo = tipo;
            Archivo = archivo;
            Fecha_Limite = fecha_limite;
            Valor = valor;
        }
    }
}
