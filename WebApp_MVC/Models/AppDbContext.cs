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

            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc()
                {
                    ID = Guid.Parse("35c0128c-cebd-4501-afc4-74a686be8018"),
                    TenDanhMuc = "Đồ ăn",
                    TrangThai = 1
                },
                new DanhMuc()
                {
                    ID = Guid.Parse("c031e6c3-4074-4236-ad30-3e83acd5b770"),
                    TenDanhMuc = "Quần áo",
                    TrangThai = 1
                }
                );
            ;
        }
    }
}
