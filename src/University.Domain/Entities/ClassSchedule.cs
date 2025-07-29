namespace University.Domain.Entities;

public class ClassSchedule
{
    public int Id { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public byte DayOfWeek { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public byte Room { get; set; }
}