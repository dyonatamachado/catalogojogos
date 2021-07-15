using System;

namespace CatalogoDeJogos.Core.Entities
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Publisher { get; private set; }
        public double Price { get; private set; }
        public bool Active { get; private set; }

        public void Deactivate()
        {
            Active = false;
        }
    }
}