using Microsoft.AspNetCore.Mvc;
using WebApplicationUrlParams.Contracts;

namespace WebApplicationUrlParams.Controllers;

[ApiController]
[Route("studenten")]
public class StudentController : ControllerBase
{
    private readonly List<StudentContract> _studentContracts;

    public StudentController()
    {
        _studentContracts = [];
        _studentContracts.Add(new StudentContract { Id = 1, Naam = "Jan", GeboorteDatum = new DateTime(2005, 3, 8), IsGeslaagd = true });
        _studentContracts.Add(new StudentContract { Id = 2, Naam = "Piet", GeboorteDatum = new DateTime(2006, 3, 12), IsGeslaagd = false });
        _studentContracts.Add(new StudentContract { Id = 3, Naam = "Tom", GeboorteDatum = new DateTime(2005, 7, 8), IsGeslaagd = true });
        _studentContracts.Add(new StudentContract { Id = 4, Naam = "Marjet", GeboorteDatum = new DateTime(2007, 3, 16), IsGeslaagd = true });
        _studentContracts.Add(new StudentContract { Id = 5, Naam = "Timmy", GeboorteDatum = new DateTime(2005, 3, 8), IsGeslaagd = true });
        _studentContracts.Add(new StudentContract { Id = 6, Naam = "Misty", GeboorteDatum = new DateTime(2004, 9, 8), IsGeslaagd = false });
        _studentContracts.Add(new StudentContract { Id = 7, Naam = "Nathalie", GeboorteDatum = new DateTime(2005, 3, 19), IsGeslaagd = true });
        _studentContracts.Add(new StudentContract { Id = 8, Naam = "Désiré", GeboorteDatum = new DateTime(2000, 3, 8), IsGeslaagd = false });
    }

    /*
     * http://localhost:5209/studenten?
     *      isGeslaagd=true&
     *      nameContains=t&
     *      acceptabeleGeboorteJaren=2005&
     *      acceptabeleGeboorteJaren=2006&
     *      acceptabeleGeboorteJaren=2007
     */
    [HttpGet]
    public ActionResult<IEnumerable<StudentContract>> Get(
        [FromQuery] string? nameContains = null,
        [FromQuery] bool? isGeslaagd = null,
        [FromQuery] int[]? acceptabeleGeboorteJaren = null
    ) => Ok( _studentContracts
        .Where(s => nameContains is null || s.Naam.Contains(nameContains, StringComparison.CurrentCultureIgnoreCase))
        .Where(s => isGeslaagd is null || s.IsGeslaagd == isGeslaagd)
        .Where(s => acceptabeleGeboorteJaren is null || acceptabeleGeboorteJaren.Contains(s.GeboorteDatum.Year))
    );

    [HttpGet("{id}")]
    public ActionResult<StudentContract?> GetSingle([FromRoute]int id) => _studentContracts.SingleOrDefault(s => s.Id == id);
}