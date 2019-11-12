using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public interface IMiniatureService
    {
        Miniature Add(Miniature Miniature);
        Miniature Get(int id);
        IEnumerable<Miniature> GetAll();
        void Remove(Miniature Miniature);
        Miniature Update(Miniature updatedMiniature);
    }
}