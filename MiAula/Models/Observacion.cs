namespace MiAula.Models
{
    public class Observacion
    {
       
            public int ObservacionId { get; set; }
            public int AlumnoId { get; set; }
            // Se asigna automaticamente en la API
            public string Fecha { get; set; }  // Formato: "dd/MM/yyyy HH:mm:ss"
        public string Tipo { get; set; }  // Ej: "Conducta", "Académica"
            public string Comentario { get; set; }
            
            public Observacion() { }

            public Observacion(int observacionId, int alumnoId, string tipo, string comentario)
            {
                this.ObservacionId = observacionId;
                this.AlumnoId = alumnoId;
                this.Tipo = tipo;
                this.Comentario = comentario;
        }


    }
}
