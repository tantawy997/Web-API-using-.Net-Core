using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebApplication1.Filters;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    static List<Car> CarsList = new List<Car>()
    {
        new Car{Id = 1, Name = "kia",CreatedDate= DateTime.Parse("2010/10/7"),Type="Gas"},
        new Car{Id = 2, Name = "BMW",CreatedDate= DateTime.Parse("2011/12/2"),Type="Electric"},
        new Car{Id= 3, Name = "sorato", CreatedDate=DateTime.Parse("2020/1/3"),Type="Deisel"}
    };

    public CarsController(ILogger<CarsController> logger)
    {
        _logger = logger;
    }



    private readonly ILogger<CarsController> _logger;

    [HttpGet]

    public ActionResult<List<Car>> GetAllCars()
    {
        return CarsList;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<List<Car>> GetCarbyId(int id)
    {
        if (!ModelState.IsValid)
        {   
            _logger.LogWarning("invlid id");
            return BadRequest(new { message = "invalid id you have to input an existing id" });

        }


        var car = CarsList.FirstOrDefault(a => a.Id == id);

        if (id < 0)
        {
            return BadRequest(new { Message = "id is less than zero" });
        }
        if (car.Id != id)
        {
            return NotFound(new { Message = "invalid id" });
        }

        return Ok(car);

    }


    [HttpPost]

    [ValidateType]

    public ActionResult AddCar(Car input)
    {
        var car = CarsList.FirstOrDefault(a => a.Id == input.Id);
        if (input == null)
        {
            return BadRequest(new { Message = "invalid input" });
        }
        

        CarsList.Add(input);
        
        //return StatusCode(StatusCodes.Status201Created, CarsDictionary);
        return CreatedAtAction("GetCarbyId", new { id = input.Id }, new { Message = "the Car has been created" });
    }
    [HttpPut]
    [Route("{id:int:min(1)}")]
    public ActionResult EditCarById(int id, Car input)
    {

        var car = CarsList.FirstOrDefault(a => a.Id == id);
        if (id != input.Id)
        {
            return BadRequest(new { Message = "this id isn't in our database" });
        }

        if (input.Id != car.Id)
        {
            return NotFound();
        }

        car.Id = input.Id;
        car.Name = input.Name;
        car.CreatedDate = input.CreatedDate;
        car.Type = input.Type;

        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteCar(int id)
    {
        
        var car = CarsList.FirstOrDefault(a => a.Id == id);
        if (car.Id != id)
        {
            return NotFound(new { Message = "invalid id" });
        }
        CarsList.Remove(car);
        return StatusCode(StatusCodes.Status202Accepted);
    }

}
