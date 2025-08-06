namespace University.Domain.Entities;

public class Student : Person
{
    public ICollection<ClassEnrollment> ClassEnrollments { get; set; } = [];
}
