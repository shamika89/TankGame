using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTank
{
    class Life: GameObject
    {
      
        private int lifeTime;

        public Life(int x, int y, int lifeTime)
            : base(x, y)
        {
            
            this.lifeTime = lifeTime;
        }
        

        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

    }
    }

