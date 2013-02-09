using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTank
{
    class Decoder
    {
        private int myId = 0;
        Coin coin;
        Life life;
        Player player;
        private List<Player> players;
        private List<GameObject> water;
        private List<Brick> bricks;
        private List<Coin> coins;
        private List<GameObject> stones;
        private List<Life> lives;
       
        public Decoder()
        {
            players = new List<Player>();
            bricks = new List<Brick>();
            water = new List<GameObject>();
            coins = new List<Coin>();
            stones = new List<GameObject>();
            lives = new List<Life>();
            
        }

        public List<Player> Players { get { return players; } }
        public List<Brick> Bricks { get { return bricks; } }
        public List<GameObject> Water { get { return water; } }
        public List<GameObject> Stone { get { return stones; } }
        public List<Coin> Coins { get { return coins; } }
        public List<Life> Lives { get { return lives; } }

        public int MyID{get { return myId; } }

        public void decode(String str)
        {
            if(str.StartsWith("S:")){
                int length=str.Length;
                String str1=str.Substring(2,length-3);
                String[] temp=str1.Split(new char[] {':'});

                foreach(String s in temp )
                    createPlayer(s);
                
            }

            if (str.StartsWith("I:")) {
                int i = 0;
                int length = str.Length;
                String str1 = str.Substring(2,length - 3);
                myId = Convert.ToInt32(str.Substring(3, 1));
                Console.WriteLine("ME: P" + myId);
                String[] temp = str1.Split(new char[] { ':' });


                foreach (String tempStr in temp) {
                    if (tempStr.StartsWith("P")) {
                        i++;
                    }
                }

                String[] bricksList = temp[i].Split(new char[] {';'});

                foreach (String tempStr in bricksList) {
                    createBricks(tempStr);
                }

                String[] stonesList = temp[i+1].Split(new char[] { ';' });


                foreach (String tempStr in stonesList) {
                    createStone(tempStr);
                }

                String[] waterList = temp[i+2].Split(new char[] { ';' });


                foreach (String tempStr in waterList) {
                    createWater(tempStr);
                }
            }

            if (str.StartsWith("C:"))
            {
                int length = str.Length;
                String str1 = str.Substring(2, length - 3);
                String[] temp = str1.Split(new char[] { ':' });

                String[] cor = temp[0].Split(new char[] {','});
                int x = Convert.ToInt32(cor[0]);
                int y = Convert.ToInt32(cor[1]);
                int time = Convert.ToInt32(temp[1]);
                int value = Convert.ToInt32(temp[2]);
                coin = createCoin(x, y, time, value);
               
               
            }

            if (str.StartsWith("L:"))
            {
                int length = str.Length;
                String str1 = str.Substring(2, length - 3);
                String[] temp = str1.Split(new char[] { ':' });

                String[] cor = temp[0].Split(new char[] { ',' });
                
                int x = Convert.ToInt32(cor[0]);
                int y = Convert.ToInt32(cor[1]);
                int time = Convert.ToInt32(temp[1]);
                life = createLife(x, y, time);
              
               
            }

            if (str.StartsWith("G:")) 
            {
                int k = 0;
                int length = str.Length;
                String str1 = str.Substring(2, length - 3);
                String[] temp = str1.Split(new char[] { ':' });


                foreach (String tempStr in temp) {
                    if (tempStr.StartsWith("P")) {
                        k++;
                        updatePlayer(tempStr);
                    }
                }

                String[] temp1 = temp[k].Split(new char[] { ';' });
                foreach (String tempStr in temp1)
                {
                    updateBrick(tempStr);
                }

            }
            }

            public void createPlayer(String tempStr)
            {
                int id = Convert.ToInt32(tempStr.Substring(1, 1));
                String[] temp1 = tempStr.Split(new char[] {';'});
                String[] cor = temp1[1].Split(new char[] {','});

                int x = Convert.ToInt32(cor[0]);
                int y = Convert.ToInt32(cor[1]);
                int dir = Convert.ToInt32(temp1[2].Substring(0, 1));

                players.Add(new Player(id, x, y, dir));
        }

        public void createWater(String tempStr)
        {

            String[] cor = tempStr.Split(new char[] {','});
            int x = Convert.ToInt32(cor[0]);
            int y = Convert.ToInt32(cor[1]);
            water.Add(new GameObject(x,y));
                    
        }

        public void createBricks(String tempStr)
        {
            String[] cor = tempStr.Split(new char[] { ',' });
            int x = Convert.ToInt32(cor[0]);
            int y = Convert.ToInt32(cor[1]);
            bricks.Add(new Brick( x, y));
                          
        }

        public void createStone(String tempStr)
        {

            String[] cor = tempStr.Split(new char[] { ',' });
            int x = Convert.ToInt32(cor[0]);
            int y = Convert.ToInt32(cor[1]);
            stones.Add(new GameObject(x,y));
                           
        }

        public Coin createCoin(int x, int y, int t, int value)
        {
            Coin coin = new Coin(x, y, t, value);
            coins.Add(coin);                
            return coin;
        }

        public Life createLife(int x, int y, int t)
        {
            Life life = new Life(x, y, t);
            lives.Add(life);
            return life;
        }

        public void updatePlayer(String tempStr)
        {
            int id = Convert.ToInt32(tempStr.Substring(1, 1));
            String[] temp = tempStr.Split(new char[] { ';' });
            String[] cor = temp[1].Split(new char[] { ',' });

            int x = Convert.ToInt32(cor[0]);
            int y = Convert.ToInt32(cor[1]);
            int dir = Convert.ToInt32(temp[2]);
            int health = Convert.ToInt32(temp[4]);
            int nCoins = Convert.ToInt32(temp[5]);
            int points = Convert.ToInt32(temp[6]);

            player = players[id];
            int oldX = player.X;
            int oldY = player.Y;

            player.X = x;
            player.Y = y;
            player.Direction = dir;
            player.Health = health;
            player.Coins = nCoins;
            player.Points = points;

            foreach(Coin coinObj in coins) {
               if (coinObj.X == x && coinObj.Y == y) {
                   coinObj.X=-1;
                   coinObj.Y=-1;
               }
            }
            foreach(Life lifeObj in lives) {
                if (lifeObj.X == x && lifeObj.Y == y) {
                    lifeObj.X = -1;
                    lifeObj.Y = -1;
                }
            }
        }

        public void updateBrick(String temp)
        {
            String[] temp1 = temp.Split(new char[] { ',' });
            int x = Convert.ToInt32(temp1[0]);
            int y = Convert.ToInt32(temp1[1]);
            int damageLevel = Convert.ToInt32(temp1[2]);

            int n=bricks.FindIndex(p => p.X == x && p.Y == y);
            bricks[n].DamageLevel = damageLevel;

            if (damageLevel == 4)
            {
                bricks[n].X = -1;
                bricks[n].Y = -1;
            }
        }

        //public void removeCoin(Coin coin)
        //{
        //    coins.Remove(coin);
        // }

        //public void removeLife(Life life)
        //{
        //   lives.Remove(life);
          
        //}

    }
}
