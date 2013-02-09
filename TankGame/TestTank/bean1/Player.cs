using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTank
{
    class Player :GameObject
    {
        private int id;
        private int direction;
        private int health;
        private int coins;
        private int points;

        public Player(int id, int x, int y, int direction)
            : base(x, y)
        {
            this.id = id;
            this.direction = direction;
            this.health = 100;
            this.coins = 0;
            this.points = 0;
            
        }

        public int ID
        {
            get { return id; }
            set { id= value; }
        }

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
