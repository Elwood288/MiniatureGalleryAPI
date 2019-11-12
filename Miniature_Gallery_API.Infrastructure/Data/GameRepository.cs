using System;
using System.Collections.Generic;
using System.Linq;
using Miniature_Gallery_API.Core.Models;
using Miniature_Gallery_API.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Miniature_Gallery_API.Infrastructure.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Game Add(Game item)
        {
            _dbContext.Games.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Game Get(int id)
        {
            return _dbContext.Games
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _dbContext.Games
                .ToList();
        }

        public Game Update(Game updatedGame)
        {
            // get the ToDo object in the current list with this id 
            var currentGame = _dbContext.Games.Find(updatedGame.Id);

            // return null if todo to update isn't found
            if (currentGame == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentGame)
                .CurrentValues
                .SetValues(updatedGame);

            // update the todo and save
            _dbContext.Games.Update(currentGame);
            _dbContext.SaveChanges();
            return currentGame;
        }

        public void Remove(Game Game)
        {
            _dbContext.Games.Remove(Game);
            _dbContext.SaveChanges();
        }
    }
}
