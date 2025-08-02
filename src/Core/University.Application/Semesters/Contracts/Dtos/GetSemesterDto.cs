namespace University.Application.Semesters.Contracts.Dtos;

public record GetSemesterDto
(
    int Id,
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    bool Active
);
