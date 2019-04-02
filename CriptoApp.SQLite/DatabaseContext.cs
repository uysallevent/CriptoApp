using CriptoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CriptoApp.SQLite
{
    public class DatabaseContext:DbContext
    {
        public DbSet<UserPortfoyModel> UserPortfoy { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
        
    }
}
