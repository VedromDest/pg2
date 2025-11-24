using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers;

[ApiController]
[Route("studenten")]
public class StudentController : ControllerBase
{
    private readonly List<Student> _students = new List<Student>
    {
        new Student { Id = 1, GeboorteJaar = 2005, Naam = "Jeroen", IsGeslaagd = true },
        new Student { Id = 2, GeboorteJaar = 2006, Naam = "Timmy", IsGeslaagd = true },
        new Student { Id = 3, GeboorteJaar = 2007, Naam = "Stan", IsGeslaagd = false }
    };

    // http://localhost:5232/studenten?geboorteJaren=2005&geboorteJaren=2006&naamContains=j
    [HttpGet]
    public ActionResult<List<Student>> Get(
        [FromQuery] string? naamContains = null, 
        [FromQuery] bool? isGeslaagd = null,
        [FromQuery] int[]? geboorteJaren = null)
    {
        return _students
            .Where(s => naamContains == null || s.Naam.Contains(naamContains, StringComparison.CurrentCultureIgnoreCase))
            .Where(s => isGeslaagd == null || s.IsGeslaagd == isGeslaagd)
            .Where(s => geboorteJaren == null || geboorteJaren.Contains(s.GeboorteJaar))
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById([FromRoute] int id)
    {
        return _students.Single(s => s.Id == id);
    }
    
    
}