using Academy_2025.Data;

namespace Academy_2025.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository()
        {
            _context = new ApplicationDbContext();


        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(course => course.Id == id);

        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(course => course.Id == id);


            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;
                _context.SaveChanges();
                return course;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(course => course.Id == id);


            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
