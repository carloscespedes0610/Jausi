using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguridad.Models.VM
{
    public class clsTipoUsuarioVM
    {
        [Key]
        public long TipoUsuarioId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "{0} Inválido")]
        public string TipoUsuarioCod { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "{0} Inválido")]
        public string TipoUsuarioDes { get; set; }

        [Display(Name = "Estado")]
        public long EstadoId { get; set; }

        [NotMapped]
        [Display(Name = "Estado")]
        public string EstadoDes { get; set; }
    }
}