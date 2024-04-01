using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UEHCourse.Models;
using UEHCourse.Models.Authentication;
using X.PagedList;


namespace UEHCourse.Controllers
{
    public class HomeController : Controller
    {

        UEHCourseContext db = new UEHCourseContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("khoahoc")]
        public IActionResult KhoaHoc(int? page)
        {

            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Courses.AsNoTracking().OrderBy(x => x.CourseName);
            PagedList<Course> lst = new PagedList<Course>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("danhmuckhoahoc")]
        public IActionResult DanhMucKhoaHoc(int fieldid)
        {
            List<Course> lstsanpham = db.Courses.Where(x => x.FieldId == fieldid).OrderBy(X => X.CourseName).ToList();
            return View(lstsanpham);
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
        [Route("blog")]
        public IActionResult Blog()
        {
            return View();
        }
        [Route("lienhe")]
        public IActionResult LienHe()
        {
            return View();
        }
        [Route("giokhoahoc")]
        [Authentication2]
        public IActionResult GioKhoaHoc()
        {
            return View();
        }
        public IActionResult ChiTietKhoaHoc(string courseId)
        {
            int courseIdInt = int.Parse(courseId);
            var course = db.Courses.SingleOrDefault(x => x.CourseId == courseIdInt);
            var imageName = db.ImageNames.Where(x => x.CourseId == courseIdInt).ToList();
            ViewBag.imageName= imageName;
            return View(course);
        }

        //LoginUsser
      
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (HttpContext.Session.GetString("Clogin") == null)
            {
                return View();
            }
            else
            {
                // Nếu đã đăng nhập thì chuyển hướng đến trang Index
                return RedirectToAction("index");
            }
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(Customer user)
        {
            if (HttpContext.Session.GetString("Clogin") == null)
            {
                var u = db.Set<Customer>()
                            .Where(x => x.Clogin.Equals(user.Clogin) && x.Cpassword.Equals(user.Cpassword))
                            .FirstOrDefault();

                if (u != null)
                {
                    // Nếu tìm thấy người dùng, đặt thông tin đăng nhập vào session và chuyển hướng đến trang Index
                    HttpContext.Session.SetString("Clogin", u.Clogin);
                    return RedirectToAction("index"); // Điều hướng đến trang Index của HomeController (thay thế HomeController bằng tên controller mặc định của bạn)
                }
                else
                {
                    // Nếu không tìm thấy người dùng, hiển thị trang đăng nhập lại với thông báo lỗi
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View();
                }
            }
            else
            {
                // Nếu đã đăng nhập thì chuyển hướng đến trang Index
                return RedirectToAction("index"); // Điều hướng đến trang Index của HomeController (thay thế HomeController bằng tên controller mặc định của bạn)
            }
        }
        /*[Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Clogin");
            // Assuming you are using cookie-based authentication
            Response.Cookies.Delete(".AspNetCore.Session");

            return RedirectToAction("Login");
        }
*/


    }
}
