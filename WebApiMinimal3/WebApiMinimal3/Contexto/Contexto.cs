using Microsoft.EntityFrameworkCore;
using WebApiMinimal3.MODELS;

namespace WebApiMinimal3.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) => Database.EnsureCreated();

        public DbSet<Produto>Produto { get; set; }
    }
}
