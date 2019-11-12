using System;
using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public interface IGameRepository
    {
        // create
        Game Add(Game todo);
        // read
        Game Get(int id);
        // update
        Game Update(Game todo);
        // delete
        void Remove(Game todo);
        // list
        IEnumerable<Game> GetAll();
    }
}
