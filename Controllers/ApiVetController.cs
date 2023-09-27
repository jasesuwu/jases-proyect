using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgroBro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AgroBro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiVetController : Controller
    {
        private AppDbContext _context;
        public ApiVetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veterinaria>>> GetApiVets()
        {
            var vets = await _context.Veterinarias.ToListAsync();
            return vets;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinaria>> GetApiVet(int Id)
        {
            var vet = await _context.Veterinarias.Where(m => m.Id == Id).Include(m => m.Noticias).FirstAsync();
            return vet;
        }
        [HttpGet("findnombre/{nombre}")]
        public async Task<ActionResult<List<Veterinaria>>> ApiVetsFindName(string nombre)
        {
            var vets = await _context.Veterinarias.Where(m => EF.Functions.Like(m.Nombre, "%" + nombre + "%")).Include(m => m.Noticias).ToListAsync();
            return vets;
        }

        [HttpPost]
        public async Task<ActionResult<Veterinaria>> PostApiVet(Veterinaria model)
        {
            if (ModelState.IsValid)
            {
                _context.Veterinarias.Add(model);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetApiVet), new { id = model.Id });
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApiVet(int Id)
        {
            var vet = await _context.Veterinarias.FindAsync(Id);
            if (vet == null)
            {
                return NotFound();
            }
            _context.Remove(vet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditApiVet(Veterinaria model, int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }catch(DbUpdateConcurrencyException){
                    throw;
                }
            }
            return NotFound();
        }
    }

}