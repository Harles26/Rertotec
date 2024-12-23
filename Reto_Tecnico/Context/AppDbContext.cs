using Microsoft.EntityFrameworkCore;
using Reto_Tecnico.Models;

namespace Reto_Tecnico.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Clientes>Cliente {  get; set; }
    }
}
