using WebApp_MVC.Models;

namespace WebApp_MVC.Repositories.Interface
{
    public interface IDanhMucRepo
    {
        DanhMuc GetByID(Guid id);
        List<DanhMuc> GetAll();
        bool Update(DanhMuc danhMuc);
        bool Delete(Guid id);
        bool Add(DanhMuc danhMuc);
    }
}
