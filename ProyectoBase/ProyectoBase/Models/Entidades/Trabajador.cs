using ProyectoBase.Models.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ProyectoBase.Models.Entidades
{
    public class Trabajador
    {
        [Key]
        public int idTrabajador { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Nombres es requerido")]
        [MaxLength(200)]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Apellidos es requerido")]
        public string apellidos { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "Tipo Documento es requerido")]
        public string tipoDocumento { get; set; }

        [Display(Name = "Número Documento")]
        [Required(ErrorMessage = "Número Documento es requerido")]
        public string numeroDocumento { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección es requerido")]
        public string direccion { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Correo es requerido")]
        public string correo { get; set; }

        public int idEmpresa { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Estado Civil es requerido")]
        public string estadoCivil { get; set; }

        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public TimeSpan horaCreacion { get; set; }

        [ForeignKey("idEmpresa")]
        public Empresa Empresa { get; set; }

        public string estadoCivil_View => estadoCivil == "S" ? "Soltero" : "Casado";

        public string estadoCivil_ViewSwitch
        {
            get
            {
                switch (estadoCivil)
                {
                    case "S":
                        return "Soltero";
                    case "C":
                        return "Casado";
                    default:
                        return "Viudo";
                }
            }
        }

    }
}