using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/pets")]
[ApiController]

public class PetController : ControllerBase
{
    private static List<Pet> _pets = new()
    {
        new Pet {IdPet = 1, PetName = "Korgi", HairColor = "White", PetCategory = "Dog", Weight = 50.0},
        new Pet {IdPet = 2, PetName = "Kajtek", HairColor = "Brazowy", PetCategory = "Dog", Weight = 30.0},
        new Pet {IdPet = 3, PetName = "Wargas", HairColor = "Black", PetCategory = "Dog", Weight = 45.0}
    };
    
    private static List<Visit> _visits = new()
    {
        new Visit { VisitDate = "24-10-2003", VisPet = _pets[0], VisitCost = 100.0, VisitDescription = "Everthings good"}
    };
    
    // [HttpGet]
    // public IActionResult GetVisit(string name)
    // {
    //     var pet = _pets.FirstOrDefault(p => p.PetName.Equals(name));
    //     List<Visit> tempListVisits = new List<Visit>();
    //     for (int i = 0; i < _visits.Count; i++)
    //     {
    //         if (_visits[i].VisPet.PetName.Equals(pet.PetName))
    //         {
    //             tempListVisits.Add(_visits[i]);
    //         }
    //     }
    //     return Ok(tempListVisits);
    // }
    
    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpGet]
    public IActionResult GetPets()
    {
        return Ok(_pets);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.IdPet == id);
        if (pet == null)
        {
            return NotFound($"Pet with id {id} was not found");
        }

        return Ok(pet);
    }

    [HttpPost]
    public IActionResult AddPet(Pet pet)
    {
        _pets.Add(pet);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdatedPet(int id, Pet pet)
    {
        var petToEdit = _pets.FirstOrDefault(p => p.IdPet == id);
        if (petToEdit == null)
        {
            return NotFound();
        }

        _pets.Remove(petToEdit);
        _pets.Add(pet);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletePet(int id)
    {
        var petToDelete = _pets.FirstOrDefault(p => p.IdPet == id);
        if (petToDelete == null)
        {
            return NoContent();
        }

        _pets.Remove(petToDelete);
        return NoContent();
    }

    public List<Pet> GetList()
    {
        return _pets;
    }

}