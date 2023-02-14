namespace Lab3.Data;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public int? ManagerId { get; set; }

    public DateTime? ManagerHiredate { get; set; }

    public Instructor Manager { get; set; }

    public List<Instructor> Instructors { get; set; } 

    public List<Student> Students { get; set; } 
}
