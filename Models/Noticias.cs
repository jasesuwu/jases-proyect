using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Collections.Generic;
namespace AgroBro.Models
{
    public class Noticias
    {
        public int Id {get; set;}
        [Required]
        [Display(Name = "Título")]
        public string? Titulo {get; set;}
        public string? Posteo {get; set;}

        [Required]
        [Display(Name = "Descripción")]
        public string? Descripcion {get; set;}
        public int VeterinariaId {get; set;}
        public Veterinaria? Veterinaria {get; set;}
    }
}