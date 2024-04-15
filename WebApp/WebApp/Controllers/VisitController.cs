using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/visits")]
[ApiController]

public class VisitController : ControllerBase
{
    
    
    private static List<Visit> _visits = new()
    {
        new Visit { VisitDate = "24-10-2003", VisPet = null, VisitCost = 100.0, VisitDescription = "Everthings good"}
    };
    
    [HttpGet("{idVi:int}")]
    public IActionResult GetVisit(int idVi)
    {
        return Ok(_visits);
    }
    
    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}