namespace University.Application.Classes.Contracts.Dtos;

public record GetClassDto
(
    int Id,
    int CourseId,
    int TeacherId,
    int SemesterId,
    byte Capacity,
    List<GetClassScheduleDto> Schedules
);
public record GetClassScheduleDto
(
    int Id,
    byte DayOfWeek,
    TimeOnly Start,
    TimeOnly End,
    string Room
);