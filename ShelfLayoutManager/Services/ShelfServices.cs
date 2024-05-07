namespace ShelfLayoutManager.Services;

using AutoMapper;

using System.ComponentModel.DataAnnotations;
using ShelfLayoutManager.Entities;
using ShelfLayoutManager.Helpers;
using ShelfLayoutManager.Context;
using ShelfLayoutManager.Models;

public interface ICabinetService
{
    Cabinet GetCabinetByNumber(int number);
    IEnumerable<Cabinet> GetAllCabinets();
    IEnumerable<Row> GetRowsFromCabinet(int cabinetNumber);

    void CreateCabinet(CabinetModel model);
    void UpdateCabinet(int cabinetNumber, CabinetModel model);
    void DeleteCabinet(int cabinetNumber);

}

public interface IRowService
{
    Row GetRowByNumber(int number);
    IEnumerable<Row> GetAllRows();
    IEnumerable<Lane> GetLanesFromRow(int rowNumber);

    void CreateRow(int cabinetNumber ,RowModel model);
    void UpdateRow(int rowNumber, RowModel model);
    void DeleteRow(int cabinetNumber, int rowNumber);

}

public interface ILaneService
{
    Lane GetLaneByNumber(int laneNumber);
    IEnumerable<Lane> GetAllLanes();
  
    void CreateLane(int rowNumber,LaneModel model);
    void UpdateLane(int laneNumber, LaneModel model);
    void DeleteLane(int rowNumber, int laneNumber);
}


public class CabinetService : ICabinetService 
{
    private  ShelfContext _context;


    private readonly IMapper _mapper;

    public CabinetService(ShelfContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Cabinet GetCabinetByNumber(int cabinetNumber)
    {
        var cabinet = _context.Cabinets.Find(cabinetNumber);
        if (cabinet == null) throw new KeyNotFoundException("Cabinet not found");
        return cabinet;
    }
    public IEnumerable<Cabinet> GetAllCabinets()
    {
        return _context.Cabinets;
    }

    public IEnumerable<Row> GetRowsFromCabinet(int cabinetNumber)
    {
        var cabinet = GetCabinetByNumber(cabinetNumber);
        return cabinet.Rows;
    }

    public void CreateCabinet(CabinetModel model)
    {
        var cabinet = _mapper.Map<Cabinet>(model);
        _context.Cabinets.Add(cabinet);
        _context.SaveChanges();
    }
      public void UpdateCabinet(int cabinetNumber, CabinetModel model)
    {

        try
        {
            var cabinet = GetCabinetByNumber(cabinetNumber);
            _mapper.Map(model, cabinet);
            _context.Cabinets.Update(cabinet);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not update cabinet. Details: {error}", e);
        }
    }

    public void DeleteCabinet(int cabinetNumber)
    {
        try
        {
            var cabinet = GetCabinetByNumber(cabinetNumber);
            _context.Cabinets.Remove(cabinet);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete cabinet. Details: {error}", e);
        }
    }
    
}


public class RowService : IRowService 
{

    private  ShelfContext _context;


    private readonly IMapper _mapper;

    public RowService( ShelfContext context, IMapper mapper)
    {

        _context = context;
        _mapper = mapper;
    }

    
    public Row GetRowByNumber(int number)
    {
        var row = _context.Rows.Find(number);
        if (row == null) throw new KeyNotFoundException("Row not found");
        return row;
    }
    public IEnumerable<Row> GetAllRows()
    {
        return _context.Rows;
    }

    public IEnumerable<Lane> GetLanesFromRow(int rowNumber)
    {
        var row = GetRowByNumber(rowNumber);
        return row.Lanes;
    }

    public void CreateRow(int cabinetNumber, RowModel model)
    {

        var cabinet = _context.Cabinets.Find(cabinetNumber);
        var row = _mapper.Map<Row>(model);


        _context.Rows.Add(row);
        cabinet.Rows.Add(row);
        _context.SaveChanges();

    }

    public void UpdateRow(int number, RowModel model)
    {
        try
        {
            var row = GetRowByNumber(number);
            row = _mapper.Map(model, row);
            _context.Rows.Update(row);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not update row. Details: {error}", e);
        }
    }

    public void DeleteRow(int cabinetNumber, int rowNumber)
    {
        try
        {
            var cabinet = _context.Cabinets.Find(cabinetNumber);
            var row = GetRowByNumber(rowNumber);

            cabinet.Rows.Remove(row);
            _context.Rows.Remove(row);
            _context.SaveChanges();

        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete row. Details: {error}", e);
        }

    }


}


public class LaneService : ILaneService
{
    private  ShelfContext _context;

    private readonly IMapper _mapper;

    public LaneService(ShelfContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Lane GetLaneByNumber(int laneNumber)
    {
        var lane = _context.Lanes.Find(laneNumber);
        if (lane == null) throw new KeyNotFoundException("Lane not found");
        return lane;
    }
    public IEnumerable<Lane> GetAllLanes()
    {
        return _context.Lanes;
    }

    public void CreateLane(int rowNumber, LaneModel model)
    {
        var row = _context.Rows.Find(rowNumber);
        var lane = _mapper.Map<Lane>(model);


        _context.Lanes.Add(lane);
        row.Lanes.Add(lane);
        _context.SaveChanges();


    }

    public void UpdateLane(int laneNumber, LaneModel model)
    {
        try
        {
            var lane = GetLaneByNumber(laneNumber);
            _mapper.Map(model, lane);
            _context.Lanes.Update(lane);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not update lane. Details: {error}", e);
        }
    }

    public void DeleteLane(int rowNumber, int laneNumber)
    {
        try
        {
            var row = _context.Rows.Find(rowNumber);
            var lane = GetLaneByNumber(laneNumber);
            
            row.Lanes.Remove(lane);
            _context.Lanes.Remove(lane);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete lane. Details: {error}", e);
        }
    }
}