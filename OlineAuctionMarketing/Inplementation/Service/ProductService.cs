using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Product;
using OlineAuctionMarketing.Models.Entities;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class ProductService : IProductService
    {
        private readonly IAuctioneerRepository _auctioneerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webpost;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository ProductRepository, IWebHostEnvironment webpost, IAuctioneerRepository auctioneerRepository, ICategoryRepository categoryRepository)
        {
            _auctioneerRepository = auctioneerRepository;
            _productRepository = ProductRepository;
            _webpost = webpost;
            _categoryRepository= categoryRepository;
        }

        public ProductResponseModel Create(CreateProductRequestModel createProductRequestModel,int userId)
        {
/*            var categories = _categoryRepository.Get(x => x.Id == userId);
*/          var auctioneer = _auctioneerRepository.Get(x => x.UsersId == userId);
            var ImageName = "";
            if (createProductRequestModel.Image != null)
            {
                var path = _webpost.WebRootPath;
                var imagepath = Path.Combine(path, "Images");
                Directory.CreateDirectory(imagepath);
                var imagetype = createProductRequestModel.Image.ContentType.Split('/')[1];
                if (imagetype != "png" && imagetype != "jpg" && imagetype != "jpeg")
                {
                    return new ProductResponseModel
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
            var product = new Product
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
            var createProduct = _productRepository.Create(product);
            if (createProduct == null)
            {
                return new ProductResponseModel
                {
                    Massage = "fail to create",
                    Status = false,
                };
            }
            return new ProductResponseModel
            {
                Data = new ProductDTO
                {
                    Id = createProduct.Id,
                    ProductName = createProduct.ProductName,
                    Description = createProduct.Description,
                    StartingPrice = createProduct.StartingPrice,
                    StartingTime = createProduct.StartingTime,
                    EndingTime = createProduct.EndingTime,
                    IsActive = createProduct.IsActive,
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

        public ProductsResponseModel GetAll()
        {
            var getAll = _productRepository.GetAllProducts(x => true);

            if (getAll == null)
            {
                return new ProductsResponseModel
                {
                    Massage = "failed to fetch",
                    Status = false,
                };

            }
            return new ProductsResponseModel
            {
                Massage = "successfully fetched",
                Status = true,
                Data = getAll.Select(x => new ProductDTO
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    IsActive= x.IsActive,
                    StartingTime= x.StartingTime,
                    EndingTime= x.EndingTime,
                    StartingPrice= x.StartingPrice,
                    Created= x.Created,
                    Image = x.Image,

                }).ToList()
            };
        }

        public ProductResponseModel GetById(int productId)
        {
            var getById = _productRepository.GetById(productId);
            if (getById == null)
            {
                return new ProductResponseModel
                {
                    Massage = "Failed to get id",
                    Status = false,
                };
            }
            return new ProductResponseModel
            {
                Massage = "successfully fetched",
                Status = true,
                Data = new ProductDTO
                {
                    Id = getById.Id,
                    ProductName = getById.ProductName,
                    Description = getById.Description,
                    IsActive = true,
                    StartingTime = getById.StartingTime,
                    EndingTime = getById.EndingTime,
                    StartingPrice = getById.StartingPrice,
                    Created = getById.Created,
                    Image = getById.Image
                }
            };
        }

        public BaseResponse Update(ProductUpdateRequestModel productUpdateRequestModel, int productId)
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
    }
}
