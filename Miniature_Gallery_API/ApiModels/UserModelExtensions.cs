using Miniature_Gallery_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniature_Gallery_API.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this AppUser user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static AppUser ToDomainModel(this UserModel userModel)
        {
            return new AppUser
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<AppUser> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<AppUser> ToDomainModels(this IEnumerable<UserModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
