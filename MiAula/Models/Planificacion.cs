using System.Runtime.CompilerServices;

namespace MiAula.Models
{
    public class Planificacion
    {
        public int Id { get; set; }

        public int Id_Clase { get; set; }

        public string Tema { get; set; }

        public string Objetivo { get; set; }

        public string Fecha_Inicio { get; set; }

        public string Fecha_Fin { get; set; }

        public int Porcentaje_Tareas { get; set; }

        public int Porcentaje_Examenes { get; set; }

        public Planificacion(int id,int id_clase,string tema,string objetivo,string fecha_inicio,string fecha_fin,int porcentaje_tareas,int porcentaje_examne) { 

            Id = id;
            Id_Clase = id_clase;
            Tema = tema;
            Objetivo = objetivo;
            Fecha_Inicio = fecha_inicio;
            Fecha_Fin = fecha_fin;
            Porcentaje_Tareas = porcentaje_tareas;
            Porcentaje_Examenes = porcentaje_examne;
        }

    }
}
