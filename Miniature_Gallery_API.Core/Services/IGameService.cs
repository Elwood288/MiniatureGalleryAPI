using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public interface IGameService
    {
        Game Add(Game Game);
        Game Get(int id);
        IEnumerable<Game> GetAll();
        void Remove(Game Game);
        Game Update(Game updatedGame);
    }
}