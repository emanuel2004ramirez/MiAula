using System.Text.Json.Serialization;

namespace MiAula.ModelS
{
    public class Planificacion
    {
        public int PlanificacionId { get; set; }
        public int ClaseId { get; set; }
        public string Tema { get; set; }
        public string Objetivo { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Porcentaje_Tareas { get; set; }
        public string Porcentaje_Examenes { get; set; }

        [JsonConstructor]
        public Planificacion(int PlanificacionId, int ClaseId, string Tema, string Objetivo, string Fecha_Inicio, string Fecha_Fin, string Porcentaje_Tareas, string Porcentaje_Examenes)
        {
            this.PlanificacionId = PlanificacionId;
            this.ClaseId = ClaseId;
            this.Tema = Tema;
            this.Objetivo = Objetivo;
            this.Fecha_Inicio = Fecha_Inicio;
            this.Fecha_Fin = Fecha_Fin;
            this.Porcentaje_Tareas = Porcentaje_Tareas;
            this.Porcentaje_Examenes = Porcentaje_Examenes;
        }

    }
}