using WebApp_MVC.Models;
using WebApp_MVC.Repositories.Interface;

namespace WebApp_MVC.Repositories.Repository
{
    public class SanPhamRepo : ISanPhamRepo
    {
        AppDbContext _context;
        public SanPhamRepo()
        {
            _context = new AppDbContext(); //Khoi tao
        }

        public List<SanPham> GetAll()
        {
            return _context.SanPhams.ToList();
        }

        public SanPham GetByID(Guid id)
        {
            var obj = _context.SanPhams.FirstOrDefault(x => x.ID == id);
            return obj;
        }

        public bool Add(SanPham sanPham)
        {
            try
            {
                _context.SanPhams.Add(sanPham);
                _context.SaveChanges();

                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var obj = _context.SanPhams.FirstOrDefault(x => x.ID == id);

                if (obj == null)
                {
                    return false;
                }
                else
                {
                    _context.SanPhams.Remove(obj);
                    _context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(SanPham sanPham)
        {
            try
            {
                var obj = _context.SanPhams.FirstOrDefault(x => x.ID == sanPham.ID);

                if (obj == null)
                {
                    return false;
                }
                else
                {
                    // update thuoc tinh

                    obj.TenSanPham = sanPham.TenSanPham;
                    obj.Gia = sanPham.Gia;
                    obj.Soluong = sanPham.Soluong;
                    obj.TrangThai = sanPham.TrangThai;

                    _context.SanPhams.Update(obj);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
