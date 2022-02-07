using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Coin : Item
    {
        public Coin(int x, int y, int w, int h) : base(x, y, w, h)
        {
            color = Color.YELLOW;
        }
    }
}