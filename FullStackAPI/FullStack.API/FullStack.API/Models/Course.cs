namespace FullStack.API.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeCourse> EmployeeCourses { get; set; }
    }
}
