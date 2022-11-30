using System.ComponentModel.DataAnnotations;

namespace ProyectoBase.Models.Entidades
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        [Display(Name = "Ruc")]
        [Required(ErrorMessage = "Ruc es requerido")]
        public string ruc { get; set; }

        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "Razón social es requerido")]
        public string razonSocial { get; set; }
    }
}

//DataAnnotations