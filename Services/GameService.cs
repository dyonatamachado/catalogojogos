using System;
using System.Linq;
using CatalogoDeJogos.Models.InputModels;
using CatalogoDeJogos.Persistence;

namespace CatalogoDeJogos.Services
{
    public class GameService
    {
        private readonly GamesContext _dbContext;
        public GameService(GamesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckIfGameIsAlreadyRegistered(CreateGame createGame)
        {
            var game = _dbContext.Games.SingleOrDefault(g => g.Name == createGame.Name && 
                g.Publisher == createGame.Publisher);
            
            if(game == null)
                return true;

            return false;
        }

        public Guid GetGuidOfGameAlreadyRegistered(string name, string publisher)
        {
            var game = _dbContext.Games.SingleOrDefault(g => g.Name == name && 
                g.Publisher == publisher);
            
            return game.Id;
        }
    }
}