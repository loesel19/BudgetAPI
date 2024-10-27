using BudgetAPI.BusinessLayer.Dtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Factories
{
    public static class BaseFactory
    {
        public static T ToEntity<T>(this BaseDto dto) where T : BaseEntity, new()
        {
            T entity = new T();
            if (dto != null)
            {
                entity.UpdatedBy = dto.UpdatedBy ?? -1;
                entity.AddedBy = dto.AddedBy ?? -1;
                entity.DateAdded = dto.DateAdded;
                entity.DateUpdated = dto.DateUpdated;
                entity.Id = dto.Id;
                entity.IsDeleted = dto.IsDeleted ?? false;
            }
            return entity;
        }

        public static T ToDomain<T>(this IEntity entity) where T : BaseDto, new()
        {
            T dto = new T();
            if (entity != null)
            {
                dto.UpdatedBy = entity.UpdatedBy;
                dto.AddedBy = entity.AddedBy;
                dto.DateAdded = entity.DateAdded;
                dto.DateUpdated = entity.DateUpdated;
                dto.Id = entity.Id;
                dto.IsDeleted = entity.IsDeleted;
            }
            return dto;
        }
    }
}
