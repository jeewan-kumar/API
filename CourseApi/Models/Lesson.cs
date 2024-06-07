using System.Collections.Generic;

namespace CourseApi.Models
{
    public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Course Course { get; set; } = null!;
    public ICollection<Video> Videos { get; set; } = new List<Video>();
}

}
