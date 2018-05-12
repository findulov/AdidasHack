using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class AdidasDbContextFactory : IDesignTimeDbContextFactory<AdidasDbContext>
    {
        public AdidasDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=.\\;Database=AdidasHack;Trusted_Connection=True;MultipleActiveResultSets=true";

            var optionsBuilder = new DbContextOptionsBuilder<AdidasDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AdidasDbContext(optionsBuilder.Options);
        }
    }
}
