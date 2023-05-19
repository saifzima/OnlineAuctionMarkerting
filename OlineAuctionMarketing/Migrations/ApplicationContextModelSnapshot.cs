﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OlineAuctionMarketing.Context;

#nullable disable

namespace OlineAuctionMarketing.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuctioneerId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndingTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemCondition")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("StartingPrice")
                        .HasColumnType("double");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AuctioneerId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.AuctionBidder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidderId");

                    b.ToTable("AuctionBidder");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auctioneer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("Auctioneer");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Bidder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("Bidders");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Bids", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BidderId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvalible")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3313),
                            Email = "Ibah@gmail.com",
                            FirstName = "Aduni",
                            IsDeleted = false,
                            LastName = "Ibah",
                            Modified = new DateTime(2023, 5, 18, 11, 47, 18, 856, DateTimeKind.Local).AddTicks(3330),
                            Password = "$2b$10$rVqWBhJneyf3Bxx1dqxcnOVkXdV9Mm3OWfrLw7oD2HJTBugJe.lgi",
                            ProfilePicture = "logo.jpg",
                            Role = 1,
                            UserName = "Admin",
                            phoneNumber = "08083901146"
                        });
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auction", b =>
                {
                    b.HasOne("OlineAuctionMarketing.Models.Entities.Auctioneer", "Auctioneer")
                        .WithMany("Auctions")
                        .HasForeignKey("AuctioneerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlineAuctionMarketing.Models.Entities.Category", "Category")
                        .WithMany("Auctions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auctioneer");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.AuctionBidder", b =>
                {
                    b.HasOne("OlineAuctionMarketing.Models.Entities.Auction", "Auction")
                        .WithMany("Bidder")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlineAuctionMarketing.Models.Entities.Bidder", "Bidder")
                        .WithMany("AuctionBidder")
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auctioneer", b =>
                {
                    b.HasOne("OlineAuctionMarketing.Models.Entities.Users", "Users")
                        .WithOne("Auctioneer")
                        .HasForeignKey("OlineAuctionMarketing.Models.Entities.Auctioneer", "UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Bidder", b =>
                {
                    b.HasOne("OlineAuctionMarketing.Models.Entities.Users", "Users")
                        .WithOne("Bidder")
                        .HasForeignKey("OlineAuctionMarketing.Models.Entities.Bidder", "UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Bids", b =>
                {
                    b.HasOne("OlineAuctionMarketing.Models.Entities.Auction", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OlineAuctionMarketing.Models.Entities.Bidder", "Bidder")
                        .WithMany("Bids")
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auction", b =>
                {
                    b.Navigation("Bidder");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Auctioneer", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Bidder", b =>
                {
                    b.Navigation("AuctionBidder");

                    b.Navigation("Bids");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Category", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("OlineAuctionMarketing.Models.Entities.Users", b =>
                {
                    b.Navigation("Auctioneer")
                        .IsRequired();

                    b.Navigation("Bidder")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
