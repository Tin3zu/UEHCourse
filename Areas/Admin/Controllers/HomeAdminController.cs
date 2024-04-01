using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UEHCourse.Models;
using X.PagedList;
using UEHCourse.Models.Authentication;
namespace UEHCourse.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]

    public class HomeAdminController : Controller
    {
        Models.UEHCourseContext db = new Models.UEHCourseContext(); 

        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {    
                return View(Index);
        }

        [Route("baocaothongke")]
        [Authentication]
        public IActionResult BaoCaoThongKe()
        {
            return View();
        }
        [Route("danhsachhocvien")]
        [Authentication]
        public IActionResult DanhSachHocVien()
        {
            return View();
        }
        [Route("quanlygiaodich")]
        [Authentication]
        public IActionResult QuanLyGiaoDich()
        {
            return View();
        }
        [Route("dangtaikhoahoc")]
        [Authentication]
        public IActionResult DangTaiKhoaHoc()
        {
            return View();
        }
        [Route("quanlyadmin")]
        [Authentication]
        public IActionResult QuanLyAdmin()
        {
            return View();
        }
        [Route("quanlyadmin1")]
        public IActionResult QuanLyAdmin1()
        {
            return View();
        }
        [Route("quanlyadmin2")]
        public IActionResult QuanLyAdmin2()
        {
            return View();
        }
        [Route("quanlyadmin3")]
        public IActionResult QuanLyAdmin3()
        {
            return View();
        }
        [Route("quanlyadmin4")]
        public IActionResult QuanLyAdmin4()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        [Authentication]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Courses.AsNoTracking().OrderBy(x => x.CourseName);
            PagedList<Course> lst = new PagedList<Course>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("themmoisanpham")]
        [HttpGet]
        [Authentication]
        public IActionResult ThemMoiSanPham()
        {
            return View();
        }
        [Route("themmoisanpham")]
        [HttpPost]
        public IActionResult ThemMoiSanPham(int CourseId, string CourseName, decimal Price, DateTime DateCreated, string FieldName, string SupplierName, string Status)
        {
            // Check dữ liệu
            if (string.IsNullOrEmpty(CourseName))
            {
                ModelState.AddModelError("CourseName", "Tên khóa học không được để trống");
                return View();
            }
            if (db.Courses.Any(c => c.CourseId == CourseId))
            {
                ModelState.AddModelError("CourseId", "CourseId đã tồn tại");
                return View();
            }
            // Khai báo dữ liệu
            Course newCourse = new Course();
            newCourse.CourseId = CourseId;
            newCourse.CourseName = CourseName;
            newCourse.Price = Price;
            newCourse.DateCreated = DateCreated;
            newCourse.FieldName = FieldName;
            newCourse.SupplierName = SupplierName;
            newCourse.Status = Status;
            // Thêm đối tượng mới vào bảng
            db.Courses.Add(newCourse);
            // Lưu trữ vào cơ sở dữ liệu
            db.SaveChanges();
            // Redirect đến action DanhMucSanPham để hiển thị danh sách sản phẩm sau khi đã thêm mới
            return RedirectToAction("DanhMucSanPham");
        }
        //Sửa sản phẩm
        [Route("suasanpham")]
        [HttpGet]
        [Authentication]
        public IActionResult SuaSanPham(int id)
        {
            var sanPham = db.Courses.Find(id);
            return View(sanPham);
        }
        [Route("suasanpham")]
        [HttpPost]
        public IActionResult SuaSanPham(Course model)
        {
            var sanPham = db.Courses.Find(model.CourseId);
            sanPham.FieldName = model.FieldName;
            sanPham.SupplierName = model.SupplierName;
            sanPham.CourseName = model.CourseName;
            sanPham.DateCreated = model.DateCreated;
            sanPham.Price = model.Price;
            sanPham.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }

        //Xóa sản phẩm
        [Route("xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham (int  id)
        {
            var sanPham= db.Courses.Find(id);
            db.Courses.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }

        //LoginAdmin
        [Route("login")]
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                // Nếu đã đăng nhập thì chuyển hướng đến trang Index
                return RedirectToAction("Index");
            }
        }
        [Route("login")]
        [HttpPost]
        public IActionResult LoginAdmin(AdminModel user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.Set<AdminModel>()
                            .Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password))
                            .FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.UserName);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index"); 
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult LogoutAdmin()
        {
            HttpContext.Session.Remove("UserName");
            // Assuming you are using cookie-based authentication
            Response.Cookies.Delete(".AspNetCore.Session");

            return RedirectToAction("LoginAdmin");
        }


    }
}
    