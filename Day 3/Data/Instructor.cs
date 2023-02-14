namespace Lab3.Data;

public class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Degree { get; set; }

    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public List<Department> Departments { get; set; } 

    public Department Department { get; set; }

    public List<InstructorCourse> InstructorCourses { get; set; } 
}
