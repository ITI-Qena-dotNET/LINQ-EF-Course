namespace Lab3.Data;

public class InstructorCourse
{
    public int InstructorId { get; set; }

    public int CourseId { get; set; }

    public string Evaluation { get; set; }

    public Course Course { get; set; }

    public Instructor Instructor { get; set; }
}
