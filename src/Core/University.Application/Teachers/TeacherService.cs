using University.Application.Teachers.Contracts;
using University.Application.Teachers.Contracts.Dtos;
using University.Application.Teachers.Contracts.Exceptions;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.Teachers;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IUnitOfWork _uow;

    public TeacherService(ITeacherRepository teacherRepository, IUnitOfWork uow)
    {
        _teacherRepository = teacherRepository;
        _uow = uow;
    }

    public int Add(AddTeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.Name,
            LastName = dto.Family,
            FatherName = dto.FatherName,
            BirthDate = dto.BirthDate,
            Code = GenerateStudentCode(),
            Gender = (Gender)dto.Gender,
            NationalCode = dto.IdentityCode,
            ContactInfo = new ContactInfo
            {
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            }
        };

        _teacherRepository.Add(teacher);
        _uow.Save();
        return teacher.Id;
    }

    private int GenerateStudentCode()
    {
        string timePart = DateTime.Now.ToString("yyyyMMmmss");
        return Convert.ToInt32(timePart);
    }

    public void Delete(int id)
    {
        var teacher = _teacherRepository.GetById(id);
        if (teacher is null)
            throw new TeacherNotFoundException();

        _teacherRepository.Delete(teacher);
        _uow.Save();
    }

    public List<GetTeacherDto> GetAll()
    {
        var list = _teacherRepository.GetAll()
            .Select(x => new GetTeacherDto(
                x.Id,
                x.FirstName,
                x.LastName)).ToList();

        return list;
    }

    public GetTeacherDto GetById(int id)
    {
        var teacher = _teacherRepository.GetById(id);
        if(teacher is null)
            throw new TeacherNotFoundException();

        var dto = new GetTeacherDto(teacher.Id, teacher.FirstName, teacher.LastName);
        return dto;
    }

    public void Update(int id, UpdateTeacherDto dto)
    {
        var teacher = _teacherRepository.GetById(id);
        if( teacher is null)
            throw new TeacherNotFoundException();

        teacher.FirstName = dto.Name;
        teacher.LastName = dto.Family;
        _teacherRepository.Update(teacher);
        _uow.Save();
    }
}
