using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Book.Context
{
    public class DbcontextsFactory : IDesignTimeDbContextFactory<Dbcontexts>
    {
        public Dbcontexts CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Dbcontexts>();

            // ✅ PostgreSQL connection string
            var connectionString = "Host=192.168.0.104;Port=5432;Database=ToDoAPI_Database;Username=postgres;Password=1234;";

            optionsBuilder.UseNpgsql(connectionString);

            return new Dbcontexts(optionsBuilder.Options);
        }
    }
}
