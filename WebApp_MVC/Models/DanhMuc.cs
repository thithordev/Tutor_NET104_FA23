namespace WebApp_MVC.Models
{
    public class DanhMuc
    {
        public Guid ID { get; set; }
        public string TenDanhMuc { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set;}
    }
}
