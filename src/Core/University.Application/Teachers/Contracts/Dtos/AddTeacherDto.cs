namespace University.Application.Teachers.Contracts.Dtos;

public record AddTeacherDto
(
    string Name,
    string Family,
    DateTime BirthDate,
    string FatherName,
    string IdentityCode,
    string PhoneNumber,
    int Gender,
    string Address
);
