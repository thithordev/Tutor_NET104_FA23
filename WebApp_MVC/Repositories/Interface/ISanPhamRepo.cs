using WebApp_MVC.Models;

namespace WebApp_MVC.Repositories.Interface
{
    public interface ISanPhamRepo
    {
        SanPham GetByID(Guid id);
        List<SanPham> GetAll();
        bool Update(SanPham sanPham);
        bool Delete(Guid id);
        bool Add(SanPham sanPham);
    }
}
