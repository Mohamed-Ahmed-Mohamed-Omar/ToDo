using Microsoft.EntityFrameworkCore;
using ToDo_Zaher.Data.Entity;

namespace ToDo_Zaher.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ToDo_E> toDo_Es { get; set; }
    }
}
