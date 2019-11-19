using System;
using System.Collections.Generic;
using System.Linq;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.ApiModels
{
    public static class MiniatureMappingExtenstions
    {

        public static MiniatureModel ToApiModel(this Miniature miniature)
        {
            return new MiniatureModel
            {
                Id = miniature.Id,
                Name = miniature.Name,
                Game = miniature.Game,
                Keywords = miniature.Keywords?.Select(a => a.Name).ToArray()
                

            };
        }

        public static Miniature ToDomainModel(this MiniatureModel miniatureModel)
        {
            return new Miniature
            {
                Id = miniatureModel.Id,
                Name = miniatureModel.Name,
                Game = miniatureModel.Game,
                Keywords = miniatureModel.Keywords.Select(a => new Keyword { Name = a }).ToArray()
            };
        }

        public static IEnumerable<MiniatureModel> ToApiModels(this IEnumerable<Miniature> activities)
        {
            return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Miniature> ToDomainModels(this IEnumerable<MiniatureModel> miniatureModels)
        {
            return miniatureModels.Select(a => a.ToDomainModel());
        }
    }
}
