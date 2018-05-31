using System.ComponentModel.DataAnnotations;

namespace Seguridad.Models.VM
{
    public class clsEstadoVM
    {
        [Key]
        public long EstadoId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "{0} Inválido")]
        public string EstadoCod { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "{0} Inválido")]
        public string EstadoDes { get; set; }

        [Display(Name = "Aplicación")]
        public long AplicacionId { get; set; }
    }
}