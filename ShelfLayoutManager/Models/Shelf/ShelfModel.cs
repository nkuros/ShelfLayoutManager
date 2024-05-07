namespace ShelfLayoutManager.Models;
using System.ComponentModel.DataAnnotations;
using ShelfLayoutManager.Entities;

public class CabinetModel
{
    [Required]
    public List<RowModel> Rows { get; set; }
    [Required]
    public PositionModel Position { get; set; }
    [Required]
    public SizeModel Size { get; set; }
    
}

public class SizeModel
{
    [Required]
    public int Width { get; set; }
    [Required]
    public int Depth { get; set; }
    [Required]
    public int Height { get; set; }
}

public class PositionModel
{
    [Required]
    public int X { get; set; }
    [Required]
    public int Y { get; set; }
    [Required]
    public int Z { get; set; }
}

public class RowModel
{

    [Required]
    public List<Lane> Lanes { get; set; }
    [Required]
    public int PositionZ { get; set; }
    [Required]
    public int Height { get; set; }
    // public RowSizeModel Size { get; set; }
}

// public class RowSizeModel
// {
//     [Required]
//     public int Height { get; set; }
// }

public class LaneModel
{
    public string JanCode { get; set; }
    public int Quantity { get; set; }
    [Required]
    public int PositionX { get; set; }
}

