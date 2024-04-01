using UEHCourse.Models;
namespace UEHCourse.Repository
{
    public interface IFieldRepository
    {
        Field Add(Field field);
        Field Update(Field field);
        Field Delete(string fieldid);
        Field GetField(string fieldid);
        IEnumerable<Field> GetAllField();

    }
}
