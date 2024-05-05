using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace ShelfLayoutManager.Entities
{
    public class SKU
    {
        // TODO: MAKE UNIQUE
        public string JanCode { get; set; }
        public string Name { get; set; }
        public string DrinkSize { get; set; }
        public ProductSize Dimensions { get; set; }
        public string ShapeType { get; set; }
        [Url]
        public string ImageUrl { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class ProductSize
    {
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Height { get; set; }
    }
}