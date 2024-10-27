﻿using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Services
{
    public partial interface IService
    {
        BaseResponse<List<CategoryDto>> GetAllCategories();
        BaseResponse<CategoryDto> CreateCategory(CategoryDto category);
    }
}