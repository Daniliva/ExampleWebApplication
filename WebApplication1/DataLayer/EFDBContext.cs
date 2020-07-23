using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{ 
    public class EFDBContext:DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {



        }

    }
    /// <summary>
    /// For Migrations
    /// </summary>
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=1;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
