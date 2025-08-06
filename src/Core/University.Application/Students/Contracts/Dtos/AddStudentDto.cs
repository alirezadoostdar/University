using University.Domain.Entities;

namespace University.Application.Students.Contracts.Dtos;

public record AddStudentDto
(
    string Name,
    string Family,
    DateTime BirthDate,
    string FatherName,
    string IdentityCode,
    string PhoneNumber,
    Gender Gender,
    string Address
);
