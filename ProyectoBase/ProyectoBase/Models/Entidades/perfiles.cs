using System.ComponentModel.DataAnnotations;

namespace ProyectoBase.Models.Entidades
{
    public class perfiles
    {
        [Key]
        public int idPerfil { get; set; }

        public string descripcion { get; set; }
    }
}