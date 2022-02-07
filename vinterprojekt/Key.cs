using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Key : Item
    {
        public Key(int x, int y, int w, int h) : base(x, y, w, h)
        {
            color = Color.BLUE;
        }
    }
}