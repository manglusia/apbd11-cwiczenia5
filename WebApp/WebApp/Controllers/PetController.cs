using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/pet")]
[ApiController]

public class PetController : ControllerBase
{

    [HttpGet]
    public string GetPets()
    {
        return "";
    }

}