using University.Application.Classes.Contracts;
using University.Application.Classes.Contracts.Dtos;
using University.Application.Classes.Contracts.Exceptions;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.Classes;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;
    private readonly IUnitOfWork _uow;

    public ClassService(IClassRepository classRepository, IUnitOfWork uow)
    {
        _classRepository = classRepository;
        _uow = uow;
    }

    public int Add(AddClassDto dto)
    {
        var newClass = new Class
        {
            CourseId = dto.CourseId,
            SemesterId = dto.SemesterId,
            TeacherId = dto.TeacherId,
            Capacity = dto.Capacity,
            Schedules = dto.Schedules.Select(x => new ClassSchedule
            {
                DayOfWeek = x.DayOfWeek,
                Start = x.Start,
                End = x.End,
                Room = x.Room
            }).ToHashSet()
        };

        _classRepository.Add(newClass);
        _uow.Save();
        return newClass.Id;
    }

    public void Delete(int id)
    {
        var cls = _classRepository.GetById(id);
        if (cls is null)
            throw new ClassNotFoundException();

        _classRepository.Delete(cls);
        _uow.Save();
    }

    public List<GetClassDto> GetAll()
    {
        var list = _classRepository.GetAll().Select(S => new GetClassDto(
            S.Id,
            S.CourseId,
            S.TeacherId,
            S.SemesterId,
            S.Capacity,
            S.Schedules.Select(s => new GetClassScheduleDto(
                s.Id,
                s.DayOfWeek,
                s.Start,
                s.End,
                s.Room)).ToList())).ToList();

        return list;
    }

    public GetClassDto GetById(int id)
    {
        var cls = _classRepository.GetById(id);
        if (cls is null)
            throw new ClassNotFoundException();

        var dto = new GetClassDto(
            cls.Id,
            cls.CourseId,
            cls.TeacherId,
            cls.SemesterId,
            cls.Capacity,
            cls.Schedules.Select(s => new GetClassScheduleDto(
                s.Id,
                s.DayOfWeek,
                s.Start,
                s.End,
                s.Room)).ToList());

        return dto;
    }

    public void Update(int id, UpdateClassDto dto)
    {
        var editClass = _classRepository.GetById(id);
        if (editClass is null)
            throw new ClassNotFoundException();

        editClass.CourseId = dto.CourseId;
        editClass.TeacherId = dto.TeacherId;
        editClass.SemesterId = dto.SemesterId;
        editClass.Capacity = dto.Capacity;
        editClass.Schedules = dto.Schedules.Select(s => new ClassSchedule
        {
            DayOfWeek = s.DayOfWeek,
            Start = s.Start,
            End = s.End,
            Room = s.Room
        }).ToHashSet();

        _classRepository.Update(editClass);
        _uow.Save();
    }
}
