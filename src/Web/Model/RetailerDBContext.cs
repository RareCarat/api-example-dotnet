using Microsoft.EntityFrameworkCore;

namespace API.RareCarat.Example.Model
{
    public class RetailerDBContext : DbContext, IRetailerDBContext
    {
        public RetailerDBContext(DbContextOptions<RetailerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Diamond> Diamonds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    public interface IRetailerDBContext
    {
        DbSet<Diamond> Diamonds { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
