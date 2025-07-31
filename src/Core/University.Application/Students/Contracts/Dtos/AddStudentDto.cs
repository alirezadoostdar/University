namespace University.Application.Students.Contracts.Dtos;

public record AddStudentDto
(
    string Name,
    string Family,
    DateTime BirthDate,
    string IdentityCode,
    string PhoneNumber,
    string Address
);
