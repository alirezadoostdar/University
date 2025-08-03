using University.Application.ClassEnrollments.Contracts;
using University.Application.ClassEnrollments.Contracts.Dtos;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.ClassEnrollments;

public class ClassEnrollmentService : IClassEnrollmentService
{
    private readonly IClassEnrollmentRepository _classEnrollmentRepository;
    private readonly IUnitOfWork _uow;

    public ClassEnrollmentService(IClassEnrollmentRepository classEnrollmentRepository, IUnitOfWork uow)
    {
        _classEnrollmentRepository = classEnrollmentRepository;
        _uow = uow;
    }

    public void Add(AddClassEnrollmentDto dto)
    {
        var enrollment = new ClassEnrollment
        {
            ClassId = dto.ClassId,
            StudentId = dto.StudentId,
            RegisterDate = DateTime.UtcNow
        };

        _classEnrollmentRepository.Add(enrollment);
        _uow.Save();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetClassEnrollmentDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public GetClassEnrollmentDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateClassEnrollmentDto dto)
    {
        throw new NotImplementedException();
    }
}
