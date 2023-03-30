using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class ProductDTO : BaseEntities
    {
        public string Image { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; } = DateTime.MinValue;
        public double StartingPrice { get; set; }

    }
}
