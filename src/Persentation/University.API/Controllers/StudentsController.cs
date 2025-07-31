using Microsoft.AspNetCore.Mvc;

namespace University.API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
