using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/visits")]
[ApiController]

public class VisitController : ControllerBase
{
    
    
    private static List<Visit> _visits = new()
    {
        new Visit { VisitDate = "24-10-2003", VisPet = new Pet{IdPet = 1, PetName = "Korgi", HairColor = "White", PetCategory = "Dog", Weight = 50.0}, VisitCost = 100.0, VisitDescription = "Everthings good"},
        new Visit { VisitDate = "25-10-2003", VisPet = new Pet{IdPet = 2, PetName = "Kajtek", HairColor = "Brazowy", PetCategory = "Dog", Weight = 30.0}, VisitCost = 1000.0, VisitDescription = "Everthings bad"},
        new Visit { VisitDate = "26-10-2003", VisPet = new Pet{IdPet = 3, PetName = "Wargas", HairColor = "Black", PetCategory = "Dog", Weight = 45.0}, VisitCost = 10.0, VisitDescription = "Everthings ok"},
        new Visit { VisitDate = "27-10-2003", VisPet = new Pet{IdPet = 3, PetName = "Wargas", HairColor = "Black", PetCategory = "Dog", Weight = 45.0}, VisitCost = 500.0, VisitDescription = "Everthings BADD"}
        
    };
    
    [HttpGet("{idVi:int}")]
    public IActionResult GetVisit(int idVi)
    {
        var visit = _visits.FindAll(a => a.VisPet.IdPet == idVi);
        return Ok(visit);
    }
    
    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}