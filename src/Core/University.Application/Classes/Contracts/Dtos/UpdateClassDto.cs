namespace University.Application.Classes.Contracts.Dtos;

public record UpdateClassDto
(
    int CourseId,
    int TeacherId,
    int SemesterId,
    byte Capacity,
    List<AddClassScheduleDto> Schedules
);


public record UpdateClassScheduleDto
(
    byte DayOfWeek,
    TimeOnly Start,
    TimeOnly End,
    string Room
);