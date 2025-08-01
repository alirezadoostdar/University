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
        string timePart = DateTime.Now.ToString("yyyyMMmmss");
        return Convert.ToInt32(timePart);
    }

    public void Delete(int id)
    {
        var student = _studentRepository.GetById(id);
        if (student is null)
            throw new Exception("student not found");
        _studentRepository.Delete(student);
    }

    public List<GetStudentDto> GetAll()
    {
        var list = _studentRepository.GetAll().Select(x => new GetStudentDto(
            x.Id,
            x.Name,
            x.Family,
            x.BirthDate,
            x.StudentCode,
            x.IdentityCode,
            x.PhoneNumber,
            x.Address)).ToList();
        return list;
    }

    public GetStudentDto GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        var StudentDto = new GetStudentDto(
            student.Id,
            student.Name,
            student.Family,
            student.BirthDate,
            student.StudentCode,
            student.IdentityCode,
            student.PhoneNumber,
            student.Address);

        return StudentDto;
    }

    public void Update(int id,UpdateStudentDto dto)
    {
        var student = _studentRepository.GetById(id);

        student.Name = dto.Name;
        student.Family = dto.Family;
        student.BirthDate = dto.BirthDate;
        student.StudentCode = dto.StudentCode;
        student.IdentityCode = dto.IdentityCode;
        student.PhoneNumber = dto.PhoneNumber;
        student.Address = dto.Address;
        _studentRepository.Update(student);
        _uow.Save();
    }
}
