using Microsoft.AspNetCore.Mvc;
using University.Application.ClassEnrollments.Contracts;
using University.Application.ClassEnrollments.Contracts.Dtos;
using University.Domain.Interfaces;

namespace University.API.Controllers;

[ApiController]
[Route("api/classEnrollment")]
public class ClassEnrollmentController : Controller
{
    private readonly IClassEnrollmentService _classEnrollmentService;

    public ClassEnrollmentController(IClassEnrollmentService classEnrollmentService)
    {
        _classEnrollmentService = classEnrollmentService;
    }

    [HttpPost]
    public void Add(AddClassEnrollmentDto dto)
    {
        _classEnrollmentService.Add(dto);
    }

    [HttpDelete]
    public void Delete(DeleteClassEnrollmentDto dto)
    {
        _classEnrollmentService.Delete(dto);
    }
}
