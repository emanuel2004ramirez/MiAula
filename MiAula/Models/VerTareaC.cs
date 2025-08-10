namespace MiAula.Models
{
    public class VerTareaC
    {
        public List<Tarea> Tareas { get; set; }
        public Clase Clase { get; set; }
        
        public VerTareaC()
        {


            Tareas = new List<Tarea>();
            Clase = null;
        }

        
    }
}
