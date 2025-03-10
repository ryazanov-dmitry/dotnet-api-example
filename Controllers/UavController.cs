using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UavApi.Data;
using UavApi.DTOs;

namespace UavApi.Controllers;
[Route("api/uavs")]
[ApiController]
public class UavController : ControllerBase
{
    private readonly UavDbContext _db;

    public UavController(UavDbContext db)
    {
        _db = db;
    }

    [HttpPost("register")]
    public IActionResult RegisterUav(RegisterUavDto dto)
    {
        var uav = new Uav { Name = dto.Name, Model = dto.Model };
        _db.Uavs.Add(uav);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetUavById), new { id = uav.Id }, uav);
    }

    [HttpGet]
    public IActionResult GetAllUavs()
    {
        return Ok(_db.Uavs.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetUavById(int id)
    {
        var uav = _db.Uavs.Find(id);
        return uav == null ? NotFound() : Ok(uav);
    }
}
