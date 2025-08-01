using Microsoft.AspNetCore.Mvc;
using University.Application.Students;
using University.Application.Students.Contracts.Dtos;

namespace University.API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : Controller
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id:int}")]
    public GetStudentDto GetById(int id)
    {
        return _studentService.GetById(id);
    }

    [HttpGet]
    public List<GetStudentDto> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpPost]
    public int Add(AddStudentDto dto)
    {
        return  _studentService.Add(dto);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateStudentDto dto)
    {
        _studentService.Update(id, dto);
    }

}
