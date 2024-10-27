using BudgetAPI.BusinessLayer.Dtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Factories
{
    public static class EntryFactory
    {
        public static EntryDto ToDomain(this Entry entity)
        {
            if(entity == null)
            {
                return null;
            }

            EntryDto dto = BaseFactory.ToDomain<EntryDto>(entity);
            dto.CategoryId = entity.CategoryId;
            dto.Amount = entity.Amount;
            dto.Description = entity.Description;
            dto.Date = entity.Date;

            return dto;
        }

        public static Entry ToEntity(this EntryDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            Entry entity = BaseFactory.ToEntity<Entry>(dto);
            entity.CategoryId = dto.CategoryId;
            entity.Amount = dto.Amount;
            entity.Description = dto.Description;
            entity.Date = dto.Date;

            return entity;
        }
    }
}
