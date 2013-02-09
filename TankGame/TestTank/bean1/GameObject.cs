using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestTank
{
    class GameObject
    {
        private int x;
        private int y;

        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }


        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
