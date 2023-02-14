namespace Lab3.Data;

public class Course
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Duration { get; set; }

    public int? TopicId { get; set; }

    public List<InstructorCourse> InsCourses { get; set; } 

    public List<StudentCourse> StudCourses { get; set; } 

    public Topic Topic { get; set; }
}
