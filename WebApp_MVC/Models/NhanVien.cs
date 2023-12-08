using System.ComponentModel.DataAnnotations;

namespace WebApp_MVC.Models
{
    public class NhanVien
    {
        [Key]
        public Guid Id { get; set; }
        public string Ten {  get; set; } = string.Empty;
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public int Luong { get; set; }
        public bool TrangThai { get; set; }
    }
}
