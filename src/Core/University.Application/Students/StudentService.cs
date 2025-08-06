using University.Application.Students.Contracts.Dtos;
using University.Application.Students.Contracts.Exceptions;
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
            FirstName = dto.Name,
            LastName = dto.Family,
            BirthDate = dto.BirthDate,
            ContactInfo = new ContactInfo
            {
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber
            },
            FatherName = dto.FatherName,
            NationalCode = dto.IdentityCode,
            Code = GenerateStudentCode(),
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
            throw new StudentNotFoundException();

        _studentRepository.Delete(student);
    }

    public List<GetStudentDto> GetAll()
    {
        var list = _studentRepository.GetAll().Select(x => new GetStudentDto(
            x.Id,
            x.FirstName,
            x.LastName,
            x.BirthDate,
            x.Code,
            x.NationalCode,
            x.ContactInfo.PhoneNumber,
            x.ContactInfo.Address)).ToList();

        return list;
    }

    public GetStudentDto GetById(int id)
    {
        var student = _studentRepository.GetById(id);
        if (student is null)
            throw new StudentNotFoundException();

        var StudentDto = new GetStudentDto(
           student.Id,
           student.FirstName,
           student.LastName,
           student.BirthDate,
           student.Code,
           student.NationalCode,
           student.ContactInfo.PhoneNumber,
           student.ContactInfo.Address);

        return StudentDto;
    }

    public void Update(int id,UpdateStudentDto dto)
    {
        var student = _studentRepository.GetById(id);

        student.FirstName = dto.Name;
        student.LastName = dto.Family;
        student.BirthDate = dto.BirthDate;
        student.Code = dto.StudentCode;
        student.NationalCode = dto.IdentityCode;
        student.ContactInfo.PhoneNumber = dto.PhoneNumber;
        student.ContactInfo.Address = dto.Address;
        _studentRepository.Update(student);
        _uow.Save();
    }
}
