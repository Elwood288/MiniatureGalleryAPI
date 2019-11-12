using System;
using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public class MiniatureService : IMiniatureService
    {
        private IMiniatureRepository _miniatureRepo;

        public MiniatureService(IMiniatureRepository repo) { _miniatureRepo = repo; }

        public Miniature Add(Miniature Miniature)
        {
          
            _miniatureRepo.Add(Miniature);
            return Miniature;
        }

        public Miniature Get(int id)
        {
            // TODO: return the specified Activity using Find()
            return _miniatureRepo.Get(id);
        }

        public IEnumerable<Miniature> GetAll()
        {
            // TODO: return all Activitys using ToList()

            return _miniatureRepo.GetAll();
        } 

        public Miniature Update(Miniature updatedMiniature)
        {
            // update the todo and save
            var Miniature = _miniatureRepo.Update(updatedMiniature);
            return Miniature;
        }

        public void Remove(Miniature miniature)
        {
            // TODO: remove the Activity
            _miniatureRepo.Remove(miniature);
        }

       

    }

}
