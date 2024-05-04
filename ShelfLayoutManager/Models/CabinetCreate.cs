namespace ShelfLayoutManager.Models;
using System.ComponentModel.DataAnnotations;
using ShelfLayoutManager.Entities;

public class CreateCabinetRequest
{
    [Required]
    public int Number { get; set; }
    public List<Row> Rows { get; set; }
    public Position Position { get; set; }
    public Size Size { get; set; }
    
}

public class CreateRowRequest
{
    [Required]
    public int Number { get; set; }
    public List<Lane> Lanes { get; set; }
    public int PositionZ { get; set; }
    public int Height { get; set; }
}

public class CreateLaneRequest
{
    [Required]
    public int Number { get; set; }
    public string JanCode { get; set; }
    public int Quantity { get; set; }
    public int PositionX { get; set; }
}

