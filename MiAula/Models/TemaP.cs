namespace MiAula.Models
{
    public class TemaP
    {

        public class TareaViewModel
        {
            public string Descripcion { get; set; }
            public string Tipo { get; set; }
            public string FechaLimite { get; set; }
        }

        // Modelo para los temas que contienen una lista de tareas
        public class TemaViewModel
        {
            public string Nombre { get; set; }
            public string Objetivos { get; set; }
            public List<TareaViewModel> Tareas { get; set; }
        }

        // Modelo principal para la planificación completa
        public class PlanificacionViewModel
        {
            public string FechaInicio { get; set; }
            public string FechaFin { get; set; }
            public int PorcentajeTareas { get; set; }
            public int PorcentajeExamenes { get; set; }
            public List<TemaViewModel> Temas { get; set; }
        }
    }
}
