using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AgroBro.Models
{
    public class AppDbContext : IdentityDbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Veterinaria>? Veterinarias { get; set; }
        public DbSet<Noticias>? Noticias { get; set; }
    }
}