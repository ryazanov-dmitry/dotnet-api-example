using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UavApi.Data;
using UavApi.DTOs;

namespace UavApi.Controllers;

[Route("api/threats")]
[ApiController]
public class ThreatController : ControllerBase
{
    private readonly UavDbContext _db;

    public ThreatController(UavDbContext db)
    {
        _db = db;
    }

    [HttpPost("report")]
    public IActionResult ReportThreat(ReportThreatDto dto)
    {
        var uav = _db.Uavs.Find(dto.UavId);
        if (uav == null) return NotFound($"UAV with ID {dto.UavId} not found.");

        var threat = new Threat
        {
            UavId = dto.UavId,
            Description = dto.Description,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
        _db.Threats.Add(threat);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetThreatById), new { id = threat.Id }, threat);
    }

    [HttpGet]
    public IActionResult GetAllThreats()
    {
        return Ok( _db.Threats.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetThreatById(int id)
    {
        var threat = _db.Threats.Find(id);
        return threat == null ? NotFound() : Ok(threat);
    }
}
