namespace University.Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }

    public ICollection<Class> Classes{ get; set; }
}
