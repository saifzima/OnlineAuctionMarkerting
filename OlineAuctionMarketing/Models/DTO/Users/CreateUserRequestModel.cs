using OlineAuctionMarketing.Enums;

namespace OlineAuctionMarketing.Models.DTO.Users
{
	public class CreateUserRequestModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }
	}
}
