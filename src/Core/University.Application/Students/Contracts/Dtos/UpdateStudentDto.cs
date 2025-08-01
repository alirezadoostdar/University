namespace University.Application.Students.Contracts.Dtos;

public record UpdateStudentDto
(
    string Name,
    string Family,
    DateTime BirthDate,
    int StudentCode,
    string IdentityCode,
    string PhoneNumber,
    string Address
);
