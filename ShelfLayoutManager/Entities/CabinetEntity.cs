using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ShelfLayoutManager.Entities
    {
    public class Cabinet
    {   
         [Key]
        public int Number { get; set; }
        public List<Row> Rows { get; set; }
        public Position Position { get; set; }
        public Size Size { get; set; }
    }


    public class Position
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class Size
    {
        [Key]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
    }

        public class Row
    {
         [Key]
        public int Number { get; set; }
        public List<Lane> Lanes { get; set; }
        public int PositionZ { get; set; }
        public int Height { get; set; }
    }

    public class Lane
    {
         [Key]
        public int Number { get; set; }
        public string JanCode { get; set; }
        public int Quantity { get; set; }
        public int PositionX { get; set; }
    }
}

