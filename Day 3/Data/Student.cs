using System.ComponentModel.DataAnnotations;

namespace Lab3.Data;

public class Student
{
    //[Key]
    public int Id { get; set; }

    //[Required]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public int? Age { get; set; }

    public int? DepartmentId { get; set; }

    public int? StudentSuperId { get; set; }

    public Department Department { get; set; }

    public List<Student> LeadingStudents { get; set; }

    public Student StudentSuper { get; set; }

    public List<StudentCourse> StudCourses { get; set; } 
}
