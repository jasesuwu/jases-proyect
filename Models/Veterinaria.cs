using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Collections.Generic;
namespace AgroBro.Models
{
    public class Veterinaria
    {
        public int Id{get; set;}
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre{get; set;}
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion{get; set;}
    
        [Required]
        [Display(Name = "Modo")]
        public string Modo{get; set;}
        public string Aplicabilidad{get; set;}
         [Required]

        [Display(Name = "Formulación")]
        public string Formulacion{get; set;}
        [Required]
        [Display(Name = "Indicaciones")]
        public string Indicaciones{get; set;}
        [Required]
        [Display(Name = "Dosis Administrativa")]

        public string DosisAdm{get; set;}

        [Required]
        [Display(Name = "Presentación")]
        public string Presentacion{get; set;}
        [Required]
        [Display(Name = "Image Presentación")]
        public string Image{get; set;}
        [Required]
        [Display(Name = "Image Detalle")]
        public string ImageDetail{get; set;}
        public List<Noticias> Noticias {get; set;}
        public Veterinaria(){
            Noticias = new List<Noticias>();
        }

    }
}