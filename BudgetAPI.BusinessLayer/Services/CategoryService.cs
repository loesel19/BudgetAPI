using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Factories;
using BudgetAPI.BusinessLayer.Responses;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Services
{
    public partial class Service : IService
    {
        private readonly DatabaseContext _dbContext;

        public Service(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BaseResponse<List<CategoryDto>> GetAllCategories()
        {
            var categories = _dbContext.Categories.ToList();
            if(categories == null || categories.Count() == 0)
            {
                return new BaseResponse<List<CategoryDto>>().Error(null, "No categories found", 404);
            }
            return new BaseResponse<List<CategoryDto>>().Success(categories.ConvertAll(x => x.ToDomain()), "");
        }
        public BaseResponse<CategoryDto> CreateCategory(CategoryDto category)
        {
            var existing = _dbContext.Categories.FirstOrDefault(x => x.Name.ToLower() == category.Name.ToLower());
            if(existing != null)
            {
                return new BaseResponse<CategoryDto>().Error(null, "Category name already exists.", 400);
            }

            if(category.AddedBy == null)
            {
                category.AddedBy = GetId();
            }
            _dbContext.Categories.Add(category.ToEntity());
            _dbContext.SaveChanges();
            existing = _dbContext.Categories.FirstOrDefault(x => x.Name.ToLower().Equals(category.Name.ToLower()));
            if(existing != null)
            {
                return new BaseResponse<CategoryDto>().Success(existing.ToDomain(), $"Successfully added category {category.Name}", 200);
            }
            return new BaseResponse<CategoryDto>().Error(null, $"Failed to add category {category.Name}");
        }

        public BaseResponse<List<EntryDto>> GetEntriesDateRange(int userId, DateTime? fromDate, DateTime? toDate, int? categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
