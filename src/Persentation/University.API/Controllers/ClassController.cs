using Microsoft.AspNetCore.Mvc;
using University.Application.Classes.Contracts;
using University.Application.Classes.Contracts.Dtos;

namespace University.API.Controllers;

[ApiController]
[Route("api/class")]
public class ClassController : Controller
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }
    [HttpGet]
    public List<GetClassDto> GetAll()
    {
        return _classService.GetAll();
    }

    [HttpGet("{id:int}")]
    public GetClassDto GetById(int id)
    {
        return _classService.GetById(id);
    }

    [HttpPost]
    public int Add(AddClassDto dto)
    {
        return _classService.Add(dto);
    }

    [HttpPut("{id:int}")]
    public void Update(int id, UpdateClassDto dto)
    {
        _classService.Update(id, dto);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _classService.Delete(id);
    }
}
