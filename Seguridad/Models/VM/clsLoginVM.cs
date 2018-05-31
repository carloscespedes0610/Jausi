using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguridad.Models.VM
{
    public class clsLoginVM
    {
        [Key]
        public long UsuarioId { get; set; }

        [Display(Name = "Cuenta de Usuario")]
        [Required(ErrorMessage = "{0} Inválido")]
        public string UsuarioCod { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "{0} Inválida")]
        [DataType(DataType.Password)]
        public string UsuarioPass { get; set; }

        [NotMapped]
        public long EmpresaId { get; set; }
    }
}