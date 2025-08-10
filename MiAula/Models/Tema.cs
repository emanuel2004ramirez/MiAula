using System.Text.Json.Serialization;

namespace MiAula.Models
{
    public class Tema
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("objetivo")]
        public string Objetivo { get; set; }

        [JsonPropertyName("id_Clase")]
        public int Id_Clase { get; set; }

        [JsonPropertyName("descripcionT")]
        public string DescripcionT { get; set; }

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("fecha_Entrega")]
        public string Fecha_Entrega { get; set; }

        [JsonPropertyName("fecha_Inicio")]
        public string Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_Fin")]
        public string Fecha_Fin { get; set; }

        [JsonPropertyName("porcentaje_Tareas")]
        public int Porcentaje_Tareas { get; set; }

        [JsonPropertyName("porcentaje_Examenes")]
        public int Porcentaje_Examenes { get; set; }

        // Constructor sin parámetros para el deserializador
        public Tema() { }

        public Tema(string nombre, string objetivo, int id_clase, string descripcionT, string tipo, string fecha_Entrega, string fecha_Inicio, string fecha_Fin, int porcentaje_Tareas, int porcentaje_Examenes)
        {
            this.Nombre = nombre;
            this.Objetivo = objetivo;
            this.Id_Clase = id_clase;
            this.DescripcionT = descripcionT;
            this.Tipo = tipo;
            this.Fecha_Entrega = fecha_Entrega;
            this.Fecha_Inicio = fecha_Inicio;
            this.Fecha_Fin = fecha_Fin;
            this.Porcentaje_Tareas = porcentaje_Tareas;
            this.Porcentaje_Examenes = porcentaje_Examenes;
        }

        public override string ToString()
        {
            return $"Tema: {Nombre}, Objetivo: {Objetivo}, ID Clase: {Id_Clase}, Descripción: {DescripcionT}, Tipo: {Tipo}, Fecha Entrega: {Fecha_Entrega}, Fecha Inicio: {Fecha_Inicio}, Fecha Fin: {Fecha_Fin}, % Tareas: {Porcentaje_Tareas}, % Exámenes: {Porcentaje_Examenes}";
        }
    }
}

