using WebApp_MVC.Models;
using WebApp_MVC.Repositories.Interface;

namespace WebApp_MVC.Repositories.Repository
{
    public class DanhMucRepo : IDanhMucRepo
    {
        AppDbContext _context;
        public DanhMucRepo()
        {
            _context = new AppDbContext(); //Khoi tao
        }

        public List<DanhMuc> GetAll()
        {
            return _context.DanhMucs.ToList();
        }

        public DanhMuc GetByID(Guid id)
        {
            var obj = _context.DanhMucs.FirstOrDefault(x => x.ID == id);
            return obj;
        }

        public bool Add(DanhMuc danhMuc)
        {
            try
            {
                _context.DanhMucs.Add(danhMuc);
                _context.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var obj = _context.DanhMucs.FirstOrDefault(x => x.ID == id);

                if (obj == null)
                {
                    return false;
                }
                else
                {
                    _context.DanhMucs.Remove(obj);
                    _context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(DanhMuc danhMuc)
        {
            try
            {
                var obj = _context.DanhMucs.FirstOrDefault(x => x.ID == danhMuc.ID);

                if (obj == null)
                {
                    return false;
                }
                else
                {
                    // update thuoc tinh

                    obj.TenDanhMuc = danhMuc.TenDanhMuc;
                    obj.TrangThai = danhMuc.TrangThai;

                    _context.DanhMucs.Update(obj);
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
