namespace University.Application.Students.Contracts.Dtos;

public record UpdateStudentDto
(
    int Id,
    string Name,
    string Family,
    DateTime BirthDate,
    int StudentCode,
    string IdentityCode,
    string PhoneNumber,
    string Address
);
