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

    [HttpPost]
    public int Add(AddStudentDto dto)
    {
        return _studentService.Add(dto);
    }

    public IActionResult Index()
    {
        return View();
    }
}
