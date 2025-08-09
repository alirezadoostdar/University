namespace University.Application.Students.Contracts.Dtos;

public record GetStudentDto
(
    int Id,
    string Name,
    string Family,
    string FatherName,
    DateTime BirthDate,
    int StudentCode,
    string IdentityCode,
    string PhoneNumber,
    string Address
);
