using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Test() {

            ViewData["Message"] = "Tutor NET104";
            ViewBag.ABC = "abc";
            int namnay = 2023;
            SanPham sp = new SanPham()
            {
                ID = Guid.NewGuid(),
                TenSanPham = "Dien thoai 15 pro max",
                Gia = 240000000,
                Soluong = 100,
                TrangThai = 1,
            };

            ViewData["SanPham"] = sp;
            return View(namnay);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult tangsodem() 
        {
        
            return View("Test");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}