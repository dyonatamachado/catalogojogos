using System;

namespace CatalogoDeJogos.Models.ViewModels
{
    public class GameView
    {
        public GameView(Guid id, string name, string publisher, double price)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            Price = price;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Publisher { get; private set; }
        public double Price { get; private set; }
    }
}