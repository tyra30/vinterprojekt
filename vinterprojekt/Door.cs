using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Door
    {
        public Rectangle rec;

        private Color color = Color.RED;

        public Door(int x, int y, int w, int h)
        {
            rec = new Rectangle(x, y, w, h);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, color);
        }
    }
}