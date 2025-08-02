namespace University.Application.Semesters.Contracts.Dtos;

public record UpdateSemesterDto
(
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    bool Active
);
