using UEHCourse.Models;

namespace UEHCourse.Areas.Admin.Controllers
{
    internal class UEHCourseContext : Models.UEHCourseContext
    {
        public IEnumerable<object> AdminModels { get; internal set; }
    }
}