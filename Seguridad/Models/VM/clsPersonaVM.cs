using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguridad.Models.VM
{
    public class clsPersonaVM
    {
        [Key,Display(Name="Id")]
        public long PersonaID { get; set; }
        [Required,StringLength(150),Display(Name = "Nombre")]
        public string PersonaNombre { get; set; }
        [Required,StringLength(30),Display(Name ="Sexo")]
        public string PersonaSexo { get; set; }
        [Required,StringLength(30),Display(Name ="Estado Civil")]
        public string PersonaEstadoCivil { get; set; }
        [Required,Display(Name ="Fecha de Nacimiento")]
        public DateTime PersonaFechaNacimiento { get; set; }
        [Required,StringLength(15),Display(Name ="Telefono")]
        public string PersonaTelefono { get; set; }

        public static string varPersonaId = nameof(PersonaID);
        public static string varPersonaNombre = nameof(PersonaNombre);
        public static string varPersonaSexo = nameof(PersonaSexo);
        public static string varPersonaEstadoCivil = nameof(PersonaEstadoCivil);
        public static string varPersonaFechaNacimiento = nameof(PersonaFechaNacimiento);
        public static string varPersonaTelefono = nameof(PersonaTelefono);

    }
}