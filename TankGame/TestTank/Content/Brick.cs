using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTank
{
    class Brick :GameObject
    {
        public Brick(int x, int y)
            : base(x, y)
        {
        }

        private int damageLevel = 0;

        public int DamageLevel
        {
            get { return damageLevel; }
            set { damageLevel = value; }
        }
    }
}
