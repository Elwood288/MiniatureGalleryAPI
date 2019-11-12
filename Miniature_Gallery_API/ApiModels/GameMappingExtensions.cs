using System;
using System.Collections.Generic;
using System.Linq;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.ApiModels
{
    public static class GameMappingExtenstions
    {

        public static GameModel ToApiModel(this Game Game)
        {
            return new GameModel
            {
                Id = Game.Id,
                Name = Game.Name,
                Attributes = Game.Attributes,
                /*miniatures = Game.miniatures*/

            };
        }

        public static Game ToDomainModel(this GameModel GameModel)
        {
            return new Game
            {
                Id = GameModel.Id,
                Name = GameModel.Name,
                Attributes = GameModel.Attributes,
                /*miniatures = GameModel.miniatures*/
            };
        }

        public static IEnumerable<GameModel> ToApiModels(this IEnumerable<Game> Games)
        {
            return Games.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Game> ToDomainModels(this IEnumerable<GameModel> GameModels)
        {
            return GameModels.Select(a => a.ToDomainModel());
        }
    }
}
