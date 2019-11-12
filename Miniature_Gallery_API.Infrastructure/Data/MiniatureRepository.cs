using System;
using System.Collections.Generic;
using System.Linq;
using Miniature_Gallery_API.Core.Models;
using Miniature_Gallery_API.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Miniature_Gallery_API.Infrastructure.Data
{
    public class MiniatureRepository : IMiniatureRepository
    {
        private readonly AppDbContext _dbContext;

        public MiniatureRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Miniature Add(Miniature item)
        {
            _dbContext.Miniatures.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Miniature Get(int id)
        {
            return _dbContext.Miniatures
                .Include(a => a.Game)
                .Include(a => a.Name)
                .Include(a => a.Keywords)
                .SingleOrDefault(b => b.Id == id);

        }

        public IEnumerable<Miniature> GetAll()
        {
            return _dbContext.Miniatures;
                
        }

        public Miniature Update(Miniature updatedMiniature)
        {
            // get the ToDo object in the current list with this id 
            var currentMiniature = _dbContext.Miniatures.Find(updatedMiniature.Id);

            // return null if todo to update isn't found
            if (currentMiniature == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentMiniature)
                .CurrentValues
                .SetValues(updatedMiniature);

            // update the todo and save
            _dbContext.Miniatures.Update(currentMiniature);
            _dbContext.SaveChanges();
            return currentMiniature;
        }

        public void Remove(Miniature Miniature)
        {
            _dbContext.Miniatures.Remove(Miniature);
            _dbContext.SaveChanges();
        }

        
    }
}
