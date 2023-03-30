using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Models.DTO.Category
{
    public class CategoryDTO : BaseEntities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvalible { get; set; }
    }
}
