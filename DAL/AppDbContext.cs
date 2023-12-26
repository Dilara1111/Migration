using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Models;

namespace PurpleBuzz.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
        public DbSet<Cards>  Cards { get; set; }
        public DbSet<Contact> Contact { get; set; }

    }
}
