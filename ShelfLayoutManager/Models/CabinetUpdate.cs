namespace ShelfLayoutManager.Models;
using System.ComponentModel.DataAnnotations;
using ShelfLayoutManager.Entities;

public class UpdateCabinetRequest
{
    [Required]
    public int Number { get; set; }
    public List<Row> Rows { get; set; }
    public Position Position { get; set; }
    public Size Size { get; set; }
    

}

public class UpdateRowRequest
{
    [Required]
    public int CabinetNumber { get; set; }
    [Required]
    public int RowNumber { get; set; }
    public List<Lane> Lanes { get; set; }
    public int PositionZ { get; set; }
    public int Height { get; set; }
}
public class UpdateLaneRequest
{
    [Required]
    public int CabinetNumber { get; set; }
    [Required]
    public int RowNumber { get; set; }
    [Required]
    public int LaneNumber { get; set; }
    public int Number { get; set; }
    public string JanCode { get; set; }
    public int Quantity { get; set; }
    public int PositionX { get; set; }
}
