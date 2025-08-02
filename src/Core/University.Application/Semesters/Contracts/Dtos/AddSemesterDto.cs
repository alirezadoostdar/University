namespace University.Application.Semesters.Contracts.Dtos;

public record AddSemesterDto
(
    string Title,
    DateTime StartDate,
    DateTime EndDate
);
