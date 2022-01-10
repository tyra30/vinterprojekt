using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Platform
    {
        public Rectangle rec;

        private Color color = Color.WHITE;

        public Platform(int x, int y, int w, int h)
        {
            rec = new Rectangle(x, y, w, h);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, color);
        }


    }
}