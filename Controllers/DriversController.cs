using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBaseNet7Code.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBaseNet7Code.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private static List<Driver> _drivers = new List<Driver>()
    {
        new Driver()
        {
            Id = 1,
            Name = "Lewis Hamilton",
            Team = "Mercedes AMG F1",
            DriverNumber = 44
        },
        new Driver()
        {
            Id = 2,
            Name = "George Russel",
            Team = "Mercedes AMG F1",
            DriverNumber = 63
        },
        new Driver()
        {
            Id = 3,
            Name = "Sebastian Vettel",
            Team = "Aston Martin",
            DriverNumber = 5
        }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_drivers);
    }

    [HttpGet("GetById")]
    public IActionResult Get(int id)
    {
        return Ok(_drivers.FirstOrDefault(x => x.Id == id));
    }

    [HttpPost("AddDriver")]
    public IActionResult AddDriver(Driver driver)
    {
        _drivers.Add(driver);
        return Ok();
    }

    [HttpDelete("DeleteDriver")]
    public IActionResult RemoveDriver(int id)
    {
        var driver = _drivers.FirstOrDefault(x => x.Id == id);

        if (driver == null)

        return NotFound();

        _drivers.Remove(driver);

        return NoContent();
           
    }

    [HttpPatch("UpdateDriver")]
    public IActionResult UpdateDriver(Driver driver)
    {
        var existDriver = _drivers.FirstOrDefault(x => x.Id == driver.Id);

        if (existDriver == null)

            return NotFound();

        existDriver.Name = driver.Name;
        existDriver.Team = driver.Team;
        existDriver.DriverNumber = driver.DriverNumber;

        return NoContent();
    }


}

