using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models.DTO.Product;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctioneerRepository _auctioneerRepository;
        private readonly IAuctionRepository _productRepository;
        private readonly IWebHostEnvironment _webpost;
        private readonly ICategoryRepository _categoryRepository;
        public AuctionService(IAuctionRepository ProductRepository, IWebHostEnvironment webpost, IAuctioneerRepository auctioneerRepository, ICategoryRepository categoryRepository)
        {
            _auctioneerRepository = auctioneerRepository;
            _productRepository = ProductRepository;
            _webpost = webpost;
            _categoryRepository= categoryRepository;
        }

       
        public AuctionResponseModel Create(CreateAuctionRequestModel createProductRequestModel,int userId)
        {
            var auctioneer = _auctioneerRepository.Get(x => x.UsersId == userId);
            var ImageName = "";
            if (createProductRequestModel.Image != null)
            {
                var path = _webpost.WebRootPath;
                var imagepath = Path.Combine(path, "Images");
                Directory.CreateDirectory(imagepath);
                var imagetype = createProductRequestModel.Image.ContentType.Split('/')[1];
                if (imagetype != "png" && imagetype != "jpg" && imagetype != "jpeg")
                {
                    return new AuctionResponseModel
                    {
                        Massage = "Fail to create product because file type is not image",
                        Status = false
                    }; 
                }
                ImageName = $"{Guid.NewGuid()}.{imagetype}";
                var fullpath = Path.Combine(imagepath, ImageName);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    createProductRequestModel.Image.CopyTo(stream);
                }
            }
            var auction = new Auction
            {
                ProductName = createProductRequestModel.ProductName,
                Description = createProductRequestModel.Description,
                StartingPrice = createProductRequestModel.StartingPrice,
                StartingTime = createProductRequestModel.StartingTime,
                EndingTime = createProductRequestModel.EndingTime,
                Image = ImageName,
                AuctioneerId = auctioneer.Id,
                CategoryId = createProductRequestModel.CategoryId,
            };
            var createAuction = _productRepository.Create(auction);
            if (createAuction == null)
            {
                return new AuctionResponseModel
                {
                    Massage = "fail to create",
                    Status = false,
                };
            }
            return new AuctionResponseModel
            {
                Data = new AuctionDTO
                {
                    Id = createAuction.Id,
                    ProductName = createAuction.ProductName,
                    Description = createAuction.Description,
                    StartingPrice = createAuction.StartingPrice,
                    StartingTime = createAuction.StartingTime,
                    EndingTime = createAuction.EndingTime,
                    IsActive = createAuction.IsActive,
                    Image = ImageName,

                },
                Massage = "Successfully Created",
                Status = true,

            };
        }

        public BaseResponse Delete(int id)
        {
            var getProduct = _productRepository.GetById(id);
            if (getProduct == null)
            {
                return new BaseResponse
                {
                    Massage = "product does not exist",
                    Status = false,
                };
            }
            var deleteProduct = _productRepository.Delete(getProduct);
            return new BaseResponse
            {
                Massage = "deleted",
                Status = true
            };
        }

        public AuctionsResponseModel GetAll()
        {
            var getAll = _productRepository.GetAllAuctions(x => true);

            if (getAll == null)
            {
                return new AuctionsResponseModel
                {
                    Massage = "failed to fetch",
                    Status = false,
                };

            }
            return new AuctionsResponseModel
            {
                Massage = "successfully fetched",
                Status = true,
                Data = getAll.Select(x => new AuctionDTO
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    IsActive= x.IsActive,
                    StartingTime= x.StartingTime,
                    EndingTime= x.EndingTime,
                    StartingPrice= x.StartingPrice,
                    Created= DateTime.Now,
                    Image = x.Image,

                }).ToList()
            };
        }

        public AuctionResponseModel GetById(int productId)
        {
            var getById = _productRepository.GetById(productId);
            if (getById == null)
            {
                return new AuctionResponseModel
                {
                    Massage = "Failed to get id",
                    Status = false,
                };
            }
            return new AuctionResponseModel
            {
                Massage = "successfully fetched",
                Status = true,
                Data = new AuctionDTO
                {
                    Id = getById.Id,
                    ProductName = getById.ProductName,
                    Description = getById.Description,
                    IsActive = true,
                    StartingTime = getById.StartingTime,
                    EndingTime = getById.EndingTime,
                    StartingPrice = getById.StartingPrice,
                    Created = DateTime.Now,
                    Image = getById.Image
                }
            };
        }

        public BaseResponse Update(AuctionUpdateRequestModel productUpdateRequestModel, int productId)
        {
            var get = _productRepository.Get(x => x.Id == productId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "failed to Update",
                    Status = false,
                };
            }
            get.Id = productId;
            get.ProductName = productUpdateRequestModel.ProductName;
            get.Description= productUpdateRequestModel.Description;
            get.StartingPrice = productUpdateRequestModel.StartingPrice;
            get.StartingTime = productUpdateRequestModel.StartingTime;
            get.EndingTime = productUpdateRequestModel.EndingTime;
            _productRepository.Update(get);
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }
        public BaseResponse Auction(AuctionRequestModel auctionRequestModel, int userId)
        {
            var get = _productRepository.GetById(auctionRequestModel.Id);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "failed to auction",
                    Status = false,
                };
            }
            if (get.StartingPrice < auctionRequestModel.StartingPrice)
            {
                return new BaseResponse
                {
                    Massage = "",
                    Status = false,
                };
            }
            var customer = _auctioneerRepository.Get(a => a.UsersId == userId);
            get.ProductName = auctionRequestModel.ProductName;
            get.Description = auctionRequestModel.Description;
            get.StartingPrice += auctionRequestModel.StartingPrice;
            get.StartingTime= auctionRequestModel.StartingTime;
            get.EndingTime= auctionRequestModel.EndingTime;
            _productRepository.Update(get);
            return new BaseResponse
            {
                Massage = "successful",
                Status = true
            };
        }

        public BiddersResponseModel GetAuctionBidder(int auctionId)
        {
            var getAll = _productRepository.GetAuctionBidder(auctionId).ToList();
            if(getAll == null)
            {
                return new BiddersResponseModel
                {
                    Massage = "failed to auction",
                    Status = false,
                };
            }

            var auctioBidder = new BiddersResponseModel
            {
                Massage = "successful",
                Status = true,
                Data = getAll.Select(x => new BidderDTO
                {
                    Id = x.Id,
                    FirstName  = x.Bidder.Users.FirstName,
                    LastName  = x.Bidder.Users.LastName,

                }).ToList(),
            };
            return auctioBidder;
            
        }
    }
}
