using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.DTO.Users
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public UserRole Role { get; set; }
	}
}
