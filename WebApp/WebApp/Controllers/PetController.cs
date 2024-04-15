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
    
}