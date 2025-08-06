namespace University.Domain.Entities;

public class Teacher : Person
{
    public ICollection<Class> Classes{ get; set; }
}
