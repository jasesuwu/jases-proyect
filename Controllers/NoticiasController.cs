using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AgroBro.Models;
using AgroBro.ViewModels;
namespace AgroBro.Controllers
{
    public class NoticiasController : Controller
    {
        private AppDbContext _context;
        public NoticiasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            var veter = await _context.Veterinarias.Where(x => x.Id == id).Include(x => x.Noticias).FirstAsync();
            return PartialView("~/Views/Vet/Noticias.cshtml", veter);
        }
        public async Task<IActionResult> Guardar(Noticias model){
            if(ModelState.IsValid){
                model.Posteo = DateTime.Now.Date.ToShortDateString();
                _context.Noticias.Add(model);
                await _context.SaveChangesAsync();
                return Redirect("/Vet/Details/" + model.VeterinariaId);
            }
            return Redirect("/Vet/Index");
            
        }
    }
}