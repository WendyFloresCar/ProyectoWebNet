using System.ComponentModel.DataAnnotations;

namespace ProyectoBase.Models.Entidades
{
    public class Sede
    {
        [Key]
        public int idSede { get; set; }

        public string descripcion { get; set; }
    }
}