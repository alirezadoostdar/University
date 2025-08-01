namespace University.Domain.Entities;

public class ClassEnrollment
{
    public int Id { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public DateTime RegisterDate { get; set; }
}