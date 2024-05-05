namespace ShelfLayoutManager.Services;

using AutoMapper;


using System.ComponentModel.DataAnnotations;
using ShelfLayoutManager.Entities;
using ShelfLayoutManager.Helpers;
using ShelfLayoutManager.Context;
using ShelfLayoutManager.Models;

public interface IShelfService
{
    Cabinet GetCabinetByNumber(int number);
    IEnumerable<Cabinet> GetAllCabinets();

    Row GetRowByNumber(int number);
    IEnumerable<Row> GetAllRows();

    Lane GetLaneByNumber(int laneNumber);
    IEnumerable<Lane> GetAllLanes();

    void CreateCabinet(CreateCabinetRequest model);
    void UpdateCabinet(int cabinetNumber, UpdateCabinetRequest model);
    void DeleteCabinet(int cabinetNumber);

    void CreateRow(int cabinetNumber ,CreateRowRequest model);
    void UpdateRow(int rowNumber, UpdateRowRequest model);
    void DeleteRow(int cabinetNumber, int rowNumber);

    void CreateLane(int rowNumber,CreateLaneRequest model);
    void UpdateLane(int rowNumber, UpdateLaneRequest model);
    void DeleteLane(int rowNumber, int laneNumber);
}

public class ShelfService : IShelfService 
{
    private  CabinetContext _cabinetContext;
    private  RowContext _rowContext;

    private  LaneContext _laneContext; 

    private readonly IMapper _mapper;

    public ShelfService(CabinetContext cabinetContext,RowContext rowContext, LaneContext laneContext, IMapper mapper)
    {
        _cabinetContext = cabinetContext;
        _rowContext = rowContext;
        _laneContext = laneContext;
        _mapper = mapper;
    }
    public Cabinet GetCabinetByNumber(int cabinetNumber)
    {
        var cabinet = _cabinetContext.Cabinets.Find(cabinetNumber);
        if (cabinet == null) throw new ValidationException("Cabinet not found");
        return cabinet;
    }
    public IEnumerable<Cabinet> GetAllCabinets()
    {
        return _cabinetContext.Cabinets;
    }
    public void CreateCabinet(CreateCabinetRequest model)
    {
        var cabinet = _mapper.Map<Cabinet>(model);
        _cabinetContext.Cabinets.Add(cabinet);
        _cabinetContext.SaveChanges();
    }
      public void UpdateCabinet(int cabinetNumber, UpdateCabinetRequest model)
    {

        try
        {
            var cabinet = GetCabinetByNumber(cabinetNumber);
            _mapper.Map(model, cabinet);
            _cabinetContext.Cabinets.Update(cabinet);
            _cabinetContext.SaveChanges();
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
            _cabinetContext.Cabinets.Remove(cabinet);
            _cabinetContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete cabinet. Details: {error}", e);
        }
    }
    

    public Row GetRowByNumber(int number)
    {
        var row = _rowContext.Rows.Find(number);
        if (row == null) throw new ValidationException("Row not found");
        return row;
    }
    public IEnumerable<Row> GetAllRows()
    {
        return _rowContext.Rows;
    }
    public IEnumerable<Row> GetRowsFromCabinet(int cabinetNumber)
    {
        var cabinet = _cabinetContext.Cabinets.Find(cabinetNumber);
        if (cabinet == null) throw new ValidationException("Cabinet not found");
        return cabinet.Rows;
    }
    public void CreateRow(int cabinetNumber, CreateRowRequest model)
    {

        var cabinet = GetCabinetByNumber(cabinetNumber);
        var row = _mapper.Map<Row>(model);


        _rowContext.Rows.Add(row);
        _rowContext.SaveChanges();
        cabinet.Rows.Add(row);
        // _cabinetContext.Cabinets.Update(cabinet);
        // _cabinetContext.SaveChanges();


    }

    public void UpdateRow(int number, UpdateRowRequest model)
    {
        try
        {
            var row = GetRowByNumber(number);
            row = _mapper.Map(model, row);
            _rowContext.SaveChanges();
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
            var cabinet = GetCabinetByNumber(cabinetNumber);
            var row = GetRowByNumber(rowNumber);

            cabinet.Rows.Remove(row);
            _rowContext.Rows.Remove(row);
            _rowContext.SaveChanges();

            // _cabinetContext.Cabinets.Remove(cabinet);
            // _cabinetContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete row. Details: {error}", e);
        }

    }

    public Lane GetLaneByNumber(int laneNumber)
    {
        var lane = _laneContext.Lanes.Find(laneNumber);
        if (lane == null) throw new ValidationException("Lane not found");
        return lane;
    }
    public IEnumerable<Lane> GetAllLanes()
    {
        return _laneContext.Lanes;
    }



    public void CreateLane(int rowNumber,CreateLaneRequest model)
    {
        try
        {
            var row = GetRowByNumber(rowNumber);
            var lane = _mapper.Map<Lane>(model);
            _laneContext.Lanes.Add(lane);
            row.Lanes.Add(lane);
            _laneContext.SaveChanges();
            // _rowContext.Lanes.Add(lane);
        // _rowContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not create lane. Details: {error}", e);
        }

    }

    public void UpdateLane( int laneNumber, UpdateLaneRequest model)
    {
        try
        {
            var lane = GetLaneByNumber(laneNumber);
            _mapper.Map(model, lane);
            _laneContext.Lanes.Update(lane);
            _laneContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new ValidationException("Could not update lane. Details: {error}", e);
        }

    }

    public void DeleteLane(int rowNumber,int laneNumber)
    {
        try
        {
            var lane = GetLaneByNumber(laneNumber);
            var row = GetRowByNumber(rowNumber);

            row.Lanes.Remove(lane);
            // _rowContext.Lanes.Remove(lane);
            // _rowContext.SaveChanges();
            _laneContext.Lanes.Remove(lane);
            _laneContext.SaveChanges();

        }
        catch (Exception e)
        {
            throw new ValidationException("Could not delete lane. Details: {error}", e);
        }

    }

}