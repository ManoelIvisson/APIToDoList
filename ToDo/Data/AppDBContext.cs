using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data {
    public class AppDBContext : DbContext {
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}