using System;
using System.Collections.Generic;
using Miniature_Gallery_API.Core.Models;

namespace Miniature_Gallery_API.Core.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _GameRepo;

        public GameService(IGameRepository GameRepo)
        {
            _GameRepo = GameRepo;
        }

        public Game Add(Game Game)
        {
            // TODO: implement add
            _GameRepo.Add(Game);
            return Game;
        }

        public Game Get(int id)
        {
            // TODO: return the specified Game using Find()
            return _GameRepo.Get(id);
        }

        public IEnumerable<Game> GetAll()
        {
            // TODO: return all Games using ToList()
            return _GameRepo.GetAll();
        }

        public Game Update(Game updatedGame)
        {
            // update the todo and save
            var Game = _GameRepo.Update(updatedGame);
            return Game;
        }

        public void Remove(Game Game)
        {
            // TODO: remove the Game
            _GameRepo.Remove(Game);
        }

    }

}
