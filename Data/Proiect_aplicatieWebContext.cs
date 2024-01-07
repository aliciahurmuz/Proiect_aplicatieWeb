using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Proiect_aplicatieWeb.Data
{
    public class Proiect_aplicatieWebContext : IdentityDbContext<IdentityUser>
    {
        public Proiect_aplicatieWebContext(DbContextOptions<Proiect_aplicatieWebContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_aplicatieWeb.Models.Medic> Medic { get; set; } = default!;
        public DbSet<Proiect_aplicatieWeb.Models.Specializare> Specializare { get; set; } = default!;
        public DbSet<Proiect_aplicatieWeb.Models.Interventie> Interventie { get; set; } = default!;
        public DbSet<Proiect_aplicatieWeb.Models.Pacient> Pacient { get; set; } = default!;
        public DbSet<Proiect_aplicatieWeb.Models.Programare> Programare { get; set; } = default!;
    }
}
