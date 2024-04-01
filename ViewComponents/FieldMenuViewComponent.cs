using UEHCourse.Models;
using Microsoft.AspNetCore.Mvc;
using UEHCourse.Repository;

namespace UEHCourse.ViewComponents

{
    public class FieldMenuViewComponent: ViewComponent
    {
        private readonly IFieldRepository _field;
        public FieldMenuViewComponent(IFieldRepository fieldRepository)
        {
            _field = fieldRepository;
        }
        public IViewComponentResult Invoke()
        {
            var field = _field.GetAllField().OrderBy(x=>x.FieldName);
            return View(field);
        }

    }
}
