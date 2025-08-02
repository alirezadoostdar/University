using University.Application.Courses.Contracts;
using University.Application.Courses.Contracts.Dtos;
using University.Application.Courses.Contracts.Exceptions;
using University.Domain.Entities;
using University.Domain.Interfaces;

namespace University.Application.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _uow;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork uow)
    {
        _courseRepository = courseRepository;
        _uow = uow;
    }

    public int Add(AddCourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Unit = dto.Unit,
        };

        _courseRepository.Add(course);
        _uow.Save();
        return course.Id;
    }

    public void Delete(int id)
    {
        var course = _courseRepository.GetById(id);
        if (course is null)
            throw new CourseNotFoundException();

        _courseRepository.Delete(course);
        _uow.Save();
    }

    public List<GetCourseDto> GetAll()
    {
        var list = _courseRepository.GetAll()
            .Select(x => new GetCourseDto(
                x.Id,
                x.Title,
                x.Unit)).ToList();

        return list;
    }

    public GetCourseDto GetById(int id)
    {
        var course = _courseRepository.GetById(id);
        if (course is null)
            throw new CourseNotFoundException();

        var dto = new GetCourseDto(course.Id, course.Title, course.Unit);
        return dto;
    }

    public void Update(int id, UpdateCourseDto dto)
    {
        var course = _courseRepository.GetById(id);
        if(course is null)
            throw new CourseNotFoundException();

        course.Title = dto.Title;
        course.Unit = dto.Unit;
        _courseRepository.Update(course);
        _uow.Save();
    }
}
