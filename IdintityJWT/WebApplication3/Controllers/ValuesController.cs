using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{

    [HttpGet]
    [Authorize]
    public ActionResult GetAll()
    {
        return Ok(new List<string> { "Name", "Names" });
    }

    [HttpGet]
    [Route("engineer")]
    [Authorize(Policy = "Admin")]
    public ActionResult GetAllSecret()
    {
        return Ok(new List<string> { "Secret", "Secret Names" });
    }

    [HttpGet]
    [Route("ceo")]
    public ActionResult GetAllSecretForCEO()
    {
        return Ok(new List<string> { "CEO", "Secret Names" });
    }

    [HttpGet]
    [Route("none")]
    public ActionResult GetAllProducts()
    {
        return Ok(new List<string> { "Milk", "Chcken" });
    }
}
