using MiAula.Models;

namespace API_MI_AULA.Models
{
    public class T_E
    {
        public List<Tema> Tema { get; set; } = new List<Tema>();
        public Examen Examenes { get; set; }

        public T_E()
        {
            // Constructor vacío para inicializar las listas si es necesario
            Tema = new List<Tema>();
            Examenes = null;
        }

    }
}
