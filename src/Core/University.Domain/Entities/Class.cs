namespace University.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public int SemesterId { get; set; }
    public Semester Semester { get; set; }

    public byte Capacity { get; set; }

    public HashSet<ClassSchedule> Schedules { get; set; } = new();
}
