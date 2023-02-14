namespace Lab3.Data;

public class StudentCourse
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public int? Grade { get; set; }

    public Course Course { get; set; }

    public Student Student { get; set; }
}
