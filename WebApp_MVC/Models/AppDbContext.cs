using Microsoft.EntityFrameworkCore;
using WebApp_MVC.Configuations;

namespace WebApp_MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=bt1;Integrated Security=True;Trust Server Certificate=True");
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SanPhamConfig());
            modelBuilder.ApplyConfiguration(new DanhMucConfig());
        }
    }
}
