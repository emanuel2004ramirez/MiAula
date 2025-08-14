namespace MiAula
{
    public class Notas_Finales_Clases
    {

        public int id_clase { get; set; }
        public int id_alumno { get; set; }
        public int nota_final { get; set; }

        public Notas_Finales_Clases(int id_clase, int id_alumno, int nota_final)
        {
            this.id_clase = id_clase;
            this.id_alumno = id_alumno;
            this.nota_final = nota_final;
        }
    }
}
