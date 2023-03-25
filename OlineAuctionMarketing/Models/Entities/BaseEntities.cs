﻿namespace OlineAuctionMarketing.Models.Entities
{
	public abstract class BaseEntities
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}
