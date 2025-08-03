namespace University.Application.ClassEnrollments.Contracts.Dtos;

public record GetClassEnrollmentDto
(
    int ClassId,
    int StudentId,
    DateTime RegisterDate
);
