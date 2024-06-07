using System.Collections.Generic;

namespace CourseApi.Models
{
    public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public int Popularity { get; set; }
    public bool Enrolled { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}

}
