﻿using System.ComponentModel.DataAnnotations;

namespace OlineAuctionMarketing.Models.DTO.Product
{
    public class AuctionRequestModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        //public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartingTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndingTime { get; set; } = DateTime.MinValue;
        public double StartingPrice { get; set; }
       
    }
}
