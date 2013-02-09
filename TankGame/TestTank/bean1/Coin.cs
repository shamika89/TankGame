using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTank
{
    class Coin :GameObject
    {
        private int price;
        private int lifeTime;

        public Coin(int x, int y, int lifeTime, int price)
            : base(x, y)
        {
            this.price = price;
            this.lifeTime = lifeTime;
        }
        

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

    }
}
