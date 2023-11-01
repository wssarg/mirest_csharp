namespace WebApplication2.Data
{

    using Microsoft.EntityFrameworkCore;
    using WebApplication2.Models;

    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public virtual DbSet<Persona> Personas { get; set; }

    }
}
