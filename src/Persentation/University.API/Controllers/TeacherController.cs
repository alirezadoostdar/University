using Microsoft.AspNetCore.Mvc;
using University.Application.Teachers.Contracts;
using University.Application.Teachers.Contracts.Dtos;

namespace University.API.Controllers;

[ApiController]
[Route("api/teacher")]
public class TeacherController : Controller
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<GetTeacherDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    public GetTeacherDto GetById(int id)
    {
        return _service.GetById(id);
    }

    [HttpPost]
    public int Add(AddTeacherDto dto)
    {
        return _service.Add(dto);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateTeacherDto dto)
    {
        _service.Update(id, dto);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
