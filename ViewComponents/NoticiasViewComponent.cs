using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AgroBro.Models;

namespace AgroBro.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public List<Noticias> listNoticias = null;
        public NoticiasViewComponent(){
            var jsonString = File.ReadAllText("Models/Noticias.json");
            listNoticias = JsonConvert.DeserializeObject<List<Noticias>>(jsonString);

        }
        public async Task<IViewComponentResult> InvokeAsync(int num = 0){
            return View(listNoticias.Take(num).ToList());
        }
    }
}