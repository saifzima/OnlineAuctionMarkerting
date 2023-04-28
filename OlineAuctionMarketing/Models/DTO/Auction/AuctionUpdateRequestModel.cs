namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class AuctionUpdateRequestModel
    {

        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; } = DateTime.MinValue;
        public double StartingPrice { get; set; }
       
    }
}
