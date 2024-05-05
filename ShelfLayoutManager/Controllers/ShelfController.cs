namespace ShelfLayoutManager.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Models;
using ShelfLayoutManager.Services;


[ApiController]
[Route("[controller]")]

public class CabinetController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IMapper _mapper;

    public CabinetController(IShelfService cabinetService, IMapper mapper)
    {
        _shelfService = cabinetService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllCabinets()
    {
        var cabinets = _shelfService.GetAllCabinets();
        return Ok(cabinets);
    }
    [HttpGet("{number}")]
    public IActionResult GetCabinetByNumber(int number)
    {
        var cabinet = _shelfService.GetCabinetByNumber(number);
        return Ok(cabinet);
    }

    [HttpPost]
    public IActionResult CreateCabinet([FromBody] CreateCabinetRequest request)
    {
        _shelfService.CreateCabinet(request);
        return Ok(new { message = "Cabinet created" });
    }

    [HttpPut("{number}")]
    public IActionResult UpdateCabinet(int number, [FromBody] UpdateCabinetRequest request)
    {
        _shelfService.UpdateCabinet(number, request);
        return Ok(new { message = "Cabinet updated" });
    }

    [HttpDelete("{number}")]
    public IActionResult DeleteCabinet(int number)
    {
        _shelfService.DeleteCabinet(number);
        return Ok(new { message = "Cabinet deleted" });
    }

    [HttpGet]
    public IActionResult GetAllRows()
    {
        var rows = _shelfService.GetAllRows();
        return Ok(rows);
    }

    [HttpGet("{rowNumber}")]
    public IActionResult GetRowByNumber(int cabinetNumber, int rowNumber)
    {
        var row = _shelfService.GetRowByNumber(rowNumber);
        return Ok(row);
    }

    [HttpPost("{cabinetNumber}")]
    public IActionResult CreateRow(int cabinetNumber, [FromBody] CreateRowRequest request)
    {
        _shelfService.CreateRow(cabinetNumber, request);
        return Ok(new { message = "Row created" });
    }

    [HttpPut("{rowNumber}")]
    public IActionResult UpdateRow(int rowNumber, [FromBody] UpdateRowRequest request)
    {
        _shelfService.UpdateRow(rowNumber, request);
        return Ok(new { message = "Row updated" });
    }

    [HttpDelete("{cabinetNumber}/rows/{rowNumber}")]
    public IActionResult DeleteRow(int cabinetNumber, int rowNumber)
    {
        _shelfService.DeleteRow(cabinetNumber, rowNumber);
        return Ok(new { message = "Row deleted" });
    }

    [HttpGet("")]
    public IActionResult GetAllLanes()
    {
        var lanes = _shelfService.GetAllLanes();
        return Ok(lanes);
    }

    [HttpGet("{cabinetNumber}/rows/{rowNumber}/lanes/{laneNumber}")]
    public IActionResult GetLaneByNumber(int cabinetNumber, int rowNumber, int laneNumber)
    {
        var lane = _shelfService.GetLaneByNumber(laneNumber);
        return Ok(lane);
    }

    [HttpPost("{rowNumber}")]
    public IActionResult CreateLane(int rowNumber, [FromBody] CreateLaneRequest request)
    {
        _shelfService.CreateLane(rowNumber, request);
        return Ok(new { message = "Lane created" });
    }

    [HttpPut("{rowNumber}/lanes/{laneNumber}")]
    public IActionResult UpdateLane( int rowNumber, int laneNumber, [FromBody] UpdateLaneRequest request)
    {
        _shelfService.UpdateLane(laneNumber, request);
        return Ok(new { message = "Lane updated" });
    }

    [HttpDelete("rows/{rowNumber}/lanes/{laneNumber}")]
    public IActionResult DeleteLane(int rowNumber, int laneNumber)
    {
        _shelfService.DeleteLane(rowNumber, laneNumber);
        return Ok(new { message = "Lane deleted" });
    }

    
}