using Microsoft.AspNetCore.Mvc;
using University.Application.Semesters.Contracts;
using University.Application.Semesters.Contracts.Dtos;

namespace University.API.Controllers;

[ApiController]
[Route("api/semester")]
public class SemesterController : Controller
{
    private readonly ISemesterService _semesterService;

    public SemesterController(ISemesterService semesterService)
    {
        _semesterService = semesterService;
    }

    [HttpPost]
    public int Add(AddSemesterDto dto)
    {
        return _semesterService.Add(dto);
    }

    [HttpGet]
    public List<GetSemesterDto> GetAll()
    {
        return _semesterService.GetAll();
    }

    [HttpGet("{id:int}")]
    public GetSemesterDto GetById(int id)
    {
        return _semesterService.GetById(id);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateSemesterDto dto)
    {
        _semesterService.Update(id, dto);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _semesterService.Delete(id);
    }
}
