using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Factories;
using BudgetAPI.BusinessLayer.Helpers;
using BudgetAPI.BusinessLayer.Responses;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.BusinessLayer.Helpers;

namespace BudgetAPI.BusinessLayer.Services
{
    public partial class Service: IService
    {

        public BaseResponse<UserDto> createUser(UserDto user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.Username == StringHelper.GetHash(user.Username));
            if (existingUser != null)
            {
                return new BaseResponse<UserDto>().Error(null, $"{user.Username} is already in use.", 400);
            }
            //encrypt username and password
            user.Username = StringHelper.GetHash(user.Username);
            user.Password = StringHelper.GetHash(user.Password);
            user.AddedBy = -1;

            _dbContext.Users.Add(user.ToEntity());
            _dbContext.SaveChanges();
            var newUser = _dbContext.Users.FirstOrDefault(x => x.Username == user.Username);
            return new BaseResponse<UserDto>().Success(newUser.ToDomain(), $"Successfully created new user.", 200);
        }

        public int GetId()
        {
            return UserHelper.GetId();
        }

        public BaseResponse<UserDto>? getUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return new BaseResponse<UserDto>().Error(null, $"no user with id {id} exists", 404);
            }
            return new BaseResponse<UserDto>().Success(user.ToDomain(), $"retrieved user {user.Username}", 200);
        }

        public BaseResponse<UserDto> signIn(UserDto userInfo)
        {
            var userhash = StringHelper.GetHash(userInfo.Username);
            var passwordhash = StringHelper.GetHash(userInfo.Password);
            var user = _dbContext.Users.Where(x => x.Username == userhash).FirstOrDefault();
            if (user == null)
            {
                return new BaseResponse<UserDto>().Error(null, $"No user found with username '{userInfo.Username}'.", 404);
            }
            if (user.Password != passwordhash)
            {
                return new BaseResponse<UserDto>().Error(null, $"Invalid password for user {userInfo.Username}.", 400);
            }

            return new BaseResponse<UserDto>().Success(user.ToDomain(), $"Successfully signed in as user '{userInfo.Username}'", 200);
        }
    }
}
