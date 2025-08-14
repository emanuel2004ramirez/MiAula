namespace MiAula.Models
{
    public class Util
    {
        public int UtilId { get; set; }
        public int ClaseId { get; set; }
        public string Nombre { get; set; }
        public bool Obligatorio { get; set; }
    

    public Util(int UtilId, int ClaseId, string Nombre, bool Obligatorio)
        {
            this.UtilId = UtilId;
            this.ClaseId = ClaseId;
            this.Nombre = Nombre;
            this.Obligatorio = Obligatorio;
        }
    }
}
