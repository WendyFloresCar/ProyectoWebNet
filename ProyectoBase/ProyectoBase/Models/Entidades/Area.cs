using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBase.Models.Entidades
{
    public class Area
    {
        [Key]
        public int idArea { get; set; }

        public string descripcion { get; set; }
        public int idSede { get; set; }

        [ForeignKey("idSede")]
        public Sede Sede { get; set; }
    }
}