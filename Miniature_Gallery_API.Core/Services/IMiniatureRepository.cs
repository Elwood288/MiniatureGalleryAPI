using System;
using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public interface IMiniatureRepository
    {
        // create
        Miniature Add(Miniature todo);
        // read
        Miniature Get(int id);
        // update
        Miniature Update(Miniature todo);
        // delete
        void Remove(Miniature todo);
        // list
        IEnumerable<Miniature> GetAll();
       
    }
}
