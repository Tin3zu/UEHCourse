using UEHCourse.Models;
namespace UEHCourse.Repository
{
    public class FieldRepository : IFieldRepository
    {
        private readonly UEHCourseContext _context;

        public FieldRepository(UEHCourseContext context)
        {
            _context = context;
        }

        public Field Add(Field field)
        {
            _context.Fields.Add(field);
            _context.SaveChanges();
            return field;

        }

        public Field Delete(string fieldid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Field> GetAllField()
        {
            return _context.Fields;
        }

        public Field GetField(string fieldid)
        {
            return _context.Fields.Find(fieldid);
        }

        public Field Update(Field field)
        {
            _context.Update(field);
            _context.SaveChanges();
            return field;

        }
    }
}

