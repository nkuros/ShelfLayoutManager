namespace ShelfLayoutManager.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Models;
using ShelfLayoutManager.Services;


[ApiController]
[Route("[controller]")]
public class CabinetController : ControllerBase
{
    private readonly ICabinetService _cabinetService;
    private readonly IMapper _mapper;

    public CabinetController(ICabinetService cabinetService, IMapper mapper)
    {
        _cabinetService = cabinetService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllCabinets()
    {
        var cabinets = _cabinetService.GetAllCabinets();
        return Ok(cabinets);
    }

    [HttpGet("{number}")]
    public IActionResult GetCabinetByNumber(int number)
    {
        var cabinet = _cabinetService.GetCabinetByNumber(number);
        return Ok(cabinet);
    }

    [HttpGet("{number}/rows")]
    public IActionResult GetRowsForCabinet(int number)
    {
        var rows = _cabinetService.GetRowsFromCabinet(number);
        return Ok(rows);
    }

    [HttpPost]
    public IActionResult CreateCabinet(CabinetModel request)
    {
        _cabinetService.CreateCabinet(request);
        return Ok(new { message = "Cabinet created" });
    }

    [HttpPut]
    public IActionResult UpdateCabinet([FromHeader]int number,  CabinetModel request)
    {
        _cabinetService.UpdateCabinet(number, request);
        return Ok(new { message = "Cabinet updated" });
    }

    [HttpDelete]
    public IActionResult DeleteCabinet([FromHeader]int number)
    {
        _cabinetService.DeleteCabinet(number);
        return Ok(new { message = "Cabinet deleted" });
    }

}


[ApiController]
[Route("[controller]")]
public class RowControlller : ControllerBase
{
    private readonly IRowService _rowService;
    private readonly IMapper _mapper;

    public RowControlller(IRowService rowService, IMapper mapper)
    {
        _rowService = rowService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllRows()
    {
        var rows = _rowService.GetAllRows();
        return Ok(rows);
    }

    [HttpGet("{rowNumber}")]
    public IActionResult GetRowByNumber(int rowNumber)
    {
        var row = _rowService.GetRowByNumber(rowNumber);
        return Ok(row);
    }

    [HttpGet("{number}/lanes")]
    public IActionResult GetRowsForCabinet(int number)
    {
        var rows = _rowService.GetLanesFromRow(number);
        return Ok(rows);
    }

    [HttpPost]
    public IActionResult CreateRow([FromHeader] int cabinetNumber, RowModel request)
    {
        _rowService.CreateRow(cabinetNumber, request);
        return Ok(new { message = "Row created" });
    }

    [HttpPut]
    public IActionResult UpdateRow([FromHeader]int rowNumber,  RowModel request)
    {
        _rowService.UpdateRow(rowNumber, request);
        return Ok(new { message = "Row updated" });
    }

    [HttpDelete]
    public IActionResult DeleteRow([FromHeader]int cabinetNumber, int rowNumber)
    {
        _rowService.DeleteRow(cabinetNumber, rowNumber);
        return Ok(new { message = "Row deleted" });
    }
}

[ApiController]
[Route("[controller]")]
public class LaneController : ControllerBase
{
    private readonly ILaneService _laneService;
    private readonly IMapper _mapper;

    public LaneController(ILaneService laneService, IMapper mapper)
    {
        _laneService = laneService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllLanes()
    {
        var lanes = _laneService.GetAllLanes();
        return Ok(lanes);
    }

    [HttpGet("{laneNumber}")]
    public IActionResult GetLaneByNumber(int laneNumber)
    {
        var lane = _laneService.GetLaneByNumber(laneNumber);
        return Ok(lane);
    }

    [HttpPost]
    public IActionResult CreateLane( [FromHeader]int rowNumber, LaneModel request)
    {
        _laneService.CreateLane(rowNumber, request);
        return Ok(new { message = "Lane created" });
    }

    [HttpPut]
    public IActionResult UpdateLane([FromHeader] int rowNumber,[FromHeader]  int laneNumber, LaneModel request)
    {
        _laneService.UpdateLane(laneNumber, request);
        return Ok(new { message = "Lane updated" });
    }

    [HttpDelete]
    public IActionResult DeleteLane([FromHeader] int rowNumber,[FromHeader]  int laneNumber)
    {
        _laneService.DeleteLane(rowNumber, laneNumber);
        return Ok(new { message = "Lane deleted" });
    }
}