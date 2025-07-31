using University.Application.Students.Contracts.Dtos;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _uow;

    public StudentService(IStudentRepository studentRepository, IUnitOfWork uow)
    {
        _studentRepository = studentRepository;
        _uow = uow;
    }

    public int Add(AddStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Family = dto.Family,
            BirthDate = dto.BirthDate,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            IdentityCode = dto.IdentityCode,
            StudentCode = GenerateStudentCode()
        };

        _studentRepository.Add(student);
        _uow.Save();
        return student.Id;
    }

    private int GenerateStudentCode()
    {
        string timePart = DateTime.Now.ToString("yyyyMMddHHmmss");
        return int.Parse(timePart.Substring(2));
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetStudentDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public GetStudentDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateStudentDto dto)
    {
        throw new NotImplementedException();
    }
}
