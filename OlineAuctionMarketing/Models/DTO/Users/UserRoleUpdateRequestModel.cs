namespace OlineAuctionMarketing.Models.DTO.Users
{
	public class UserRoleUpdateRequestModel :BaseResponse
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
