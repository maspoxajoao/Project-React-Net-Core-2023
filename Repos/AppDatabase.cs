using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Repos
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }
    }
}
