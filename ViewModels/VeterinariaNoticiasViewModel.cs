using System.Collections.Generic;
using AgroBro.Models;
namespace AgroBro.ViewModels
{
    public class VeterinariaNoticiasViewModel
    {
        public Veterinaria? Veterinaria { get; set; }
        public List<Noticias>? ListNoticias { get; set; }
    }
}