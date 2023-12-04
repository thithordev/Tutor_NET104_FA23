using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp_MVC.Models;

namespace WebApp_MVC.Configuations
{
    public class DanhMucConfig : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("DanhMuc");
            builder.Property(x => x.TenDanhMuc).HasMaxLength(100).IsUnicode(true).IsRequired();
        }
    }
}
