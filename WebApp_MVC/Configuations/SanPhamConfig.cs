using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.Xml;
using WebApp_MVC.Models;

namespace WebApp_MVC.Configuations
{
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(x => x.ID);

            builder.ToTable("SanPham");

            builder.Property(x => x.Gia).HasColumnType("money");

            // C1
            //builder.Property(x => x.TenSanPham).HasColumnType("nvarchar(100)");

            //C2

            builder.Property(x => x.TenSanPham).HasMaxLength(100).IsUnicode(true).IsRequired();

            builder.HasOne(x => x.DanhMuc).WithMany(x => x.SanPhams).HasForeignKey(x => x.IDDanhMuc);

        }
    }
}
