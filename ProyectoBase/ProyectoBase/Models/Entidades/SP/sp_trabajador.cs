using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ProyectoBase.Models.Entidades.SP
{
    public class sp_trabajador
    {
        [Key]
        public int idTrabajador { get; set; }

        [Display(Name = "Nombres")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Display(Name = "Tipo Documento")]
        public string tipoDocumento { get; set; }

        [Display(Name = "Número Documento")]
        public string numeroDocumento { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Correo")]
        public string? correo { get; set; }

        public int idEmpresa { get; set; }
        public string razonSocial { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Estado Civil")]
        public string estadoCivil { get; set; }

        public bool estado { get; set; }
    }
}