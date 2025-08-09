using Book.Model;
using Microsoft.EntityFrameworkCore;

namespace Book.Context
{
    public class Dbcontexts : DbContext
    {
        public Dbcontexts(DbContextOptions<Dbcontexts> options) : base(options) { }

        public DbSet<BookStore> books { get; set; }
    }
}
