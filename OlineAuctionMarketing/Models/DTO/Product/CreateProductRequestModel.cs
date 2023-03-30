using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class CreateProductRequestModel
    {
        public IFormFile Image { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartingTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndingTime { get; set; } = DateTime.MinValue;
        public double StartingPrice { get; set; }
        public int AuctioneerId { get; set; } 
        public int CategoryId { get;set; }
    }
}
