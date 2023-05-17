using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Enums;
using OlineAuctionMarketing.Inplementation.Repository;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.DTO.Bidder;
using OlineAuctionMarketing.Models.DTO.Category;
using OlineAuctionMarketing.Models.Entities;
using System.Security.Claims;

namespace OlineAuctionMarketing.Inplementation.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuctionRepository _productRepository;
        public CategoryService(ApplicationContext context,ICategoryRepository categoryRepository,IAuctionRepository productRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public CategoryResponseModel Create(CreateCategoryRequestModel createCategoryRequestModel)
        {
            var category = _categoryRepository.Get(x => x.Name == createCategoryRequestModel.Name);
            if (category != null)
            {

                return new CategoryResponseModel
                {
                    Massage = "Name does not  exist",
                    Status = false
                };
            }
            var categories = new Category
            {
                Name = createCategoryRequestModel.Name,
                Description = createCategoryRequestModel.Description,
                IsAvalible=true,
                Created = DateTime.Now,
            };
            
            _categoryRepository.Create(categories);

            return new CategoryResponseModel
            {
                Massage = "Succeccfully created",
                Status = true
            };
        }

        public BaseResponse Delete(int categoryId)
        {
            var getCategory = _categoryRepository.Get(x => x.Id == categoryId);
            if (getCategory == null)
            {
                return new BaseResponse
                {
                    Massage = "Auctioneer does not exist",
                    Status = false
                };
            }
            var deleteCategory = _categoryRepository.Delete(getCategory);
            return new BaseResponse
            {
                Massage = "Deleted",
                Status = true
            };
        }

        public CategorysResponseModel GetAll()
        {
            var get = _categoryRepository.GetAllCategories(x => true);
            if (get == null)
            {
                return new CategorysResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch",
                };
            }
            var count = get.Count();
            return new CategorysResponseModel
            {
                Massage = "Successfully fetch",
                Status = true,
                Data = get.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name= x.Name,
                    Description= x.Description,
                    IsAvalible= x.IsAvalible,
                    Created = x.Created,

                }).ToList(),
            };
        }

        public CategoryResponseModel GetById(int categoryId)
        {
            var get = _categoryRepository.Get(x => x.Id == categoryId);
            if (get == null)
            {
                return new CategoryResponseModel
                {
                    Status = false,
                    Massage = "Failed to fetch"
                };
            }
            var category = new CategoryDTO
            {
                Id = get.Id,
               Name= get.Name,
               Description= get.Description,
               IsAvalible= get.IsAvalible,
               IsDeleted= get.IsDeleted,
               Modified = get.Modified,
                Created = get.Created,
            };
            return new CategoryResponseModel
            {
                Data = category,
                Massage = "Successfully fetch",
                Status = true
            };
        }

        public BaseResponse Update(CategoryResponseModel categoryUpdateRequestModel, int categoryId)
        {
            var get = _categoryRepository.Get(x => x.Id == categoryId);
            if (get == null)
            {
                return new BaseResponse
                {
                    Massage = "Successfully updated",
                    Status = true
                };
            }
            get.Id = categoryId;
            get.Name = categoryUpdateRequestModel.Data.Name;
            get.Description = categoryUpdateRequestModel.Data.Description;
            _categoryRepository.Update(get);    
            return new BaseResponse
            {
                Massage = "successfully Updated",
                Status = true,
            };
        }
    }
}
