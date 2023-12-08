using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_MVC.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid ID { get; set; }
        public Guid IDDanhMuc {  get; set; }
        public string TenSanPham {  get; set; }
        public float Gia { get; set; }
        public int Soluong { get; set; }
        public int TrangThai { get; set; }
        [ForeignKey("IDDanhMuc")]
        public virtual DanhMuc? DanhMuc { get; set; }
    }
}
