using Microsoft.AspNetCore.Mvc;
using University.Application.Courses.Contracts;
using University.Application.Courses.Contracts.Dtos;

namespace University.API.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public List<GetCourseDto> GetAll()
    {
        return _courseService.GetAll();
    }

    [HttpGet("{id:int}")]
    public GetCourseDto GetById(int id)
    {
        return _courseService.GetById(id);
    }

    [HttpPost]
    public int Add(AddCourseDto dto)
    {
        return _courseService.Add(dto);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateCourseDto dto)
    {
        _courseService.Update(id, dto);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _courseService.Delete(id);
    }
}
