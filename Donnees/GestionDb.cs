using API.models;
using Microsoft.EntityFrameworkCore;

namespace API.Donnees
{
    public class GestionDb:DbContext
    {

        public GestionDb(DbContextOptions<GestionDb> options):base(options)
        {

        }

        public DbSet<Salarie> salaries { get; set; }
        public DbSet<Departement> departements { get; set; }
    }
}
