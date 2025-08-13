using MiAula.ModelS;

namespace MiAula.Models
{
    public class VerTareaC
    {
        public List<Tarea> Tareas { get; set; }
        public Clase Clase { get; set; }
        public List<Planificacion> planificacion{ get; set; }


        public VerTareaC()
        {

            planificacion = new List<Planificacion>();
            Tareas = new List<Tarea>();
            Clase = null;
        }

        
    }
}
