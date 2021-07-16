using System;

namespace CatalogoDeJogos.Core.Entities
{
    public class Game
    {
        public Game(string name, string publisher, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Publisher = publisher;
            Price = price;
            Active = true;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Publisher { get; private set; }
        public double Price { get; private set; }
        public bool Active { get; private set; }

        public void Deactivate()
        {
            Active = false;
        }
        public void UpdateGame(string name, string publisher, double price)
        {
            Name = name;
            Publisher = publisher;
            Price = price;
        }
        public void UpdatePrice(double price)
        {
            Price = price;
        }
    }
}