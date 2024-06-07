namespace CourseApi.Models
{
    public class Video
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public Lesson Lesson { get; set; } = null!;
}

}
