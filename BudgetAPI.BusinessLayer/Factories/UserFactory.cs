using BudgetAPI.BusinessLayer.Dtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Factories
{
    public static class UserFactory
    {
        public static UserDto ToDomain(this User entity)
        {
            if (entity == null)
            {
                return null;
            }
            UserDto dto = BaseFactory.ToDomain<UserDto>(entity);
            dto.Username = entity.Username;
            dto.Password = entity.Password;
            dto.Email = entity.Email;

            return dto;
        }
        public static User ToEntity(this UserDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            User entity = BaseFactory.ToEntity<User>(dto);
            entity.Username = dto.Username;
            entity.Password = dto.Password;
            entity.Email = dto.Email;

            return entity;
        }
    }
}
