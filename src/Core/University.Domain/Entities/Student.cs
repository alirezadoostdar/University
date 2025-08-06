namespace University.Domain.Entities;

public class Student : Person
{
    public ICollection<ClassEnrollment> Classes { get; set; }
}
