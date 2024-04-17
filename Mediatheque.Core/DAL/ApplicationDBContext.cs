using Mediatheque.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Mediatheque.Core.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<CD> CD { get; set; }

        public DbSet<JeuxDeSociete> JeuDeSociete { get; set; }

        public DbSet<Etagere> Etagere { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
