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
            Name = dto.Name,
            Family = dto.Family
        };

        _teacherRepository.Add(teacher);
        _uow.Save();
        return teacher.Id;
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
                x.Name,
                x.Family)).ToList();

        return list;
    }

    public GetTeacherDto GetById(int id)
    {
        var teacher = _teacherRepository.GetById(id);
        if(teacher is null)
            throw new TeacherNotFoundException();

        var dto = new GetTeacherDto(teacher.Id, teacher.Name, teacher.Family);
        return dto;
    }

    public void Update(int id, UpdateTeacherDto dto)
    {
        var teacher = _teacherRepository.GetById(id);
        if( teacher is null)
            throw new TeacherNotFoundException();

        teacher.Name = dto.Name;
        teacher.Family = dto.Family;
        _teacherRepository.Update(teacher);
        _uow.Save();
    }
}
