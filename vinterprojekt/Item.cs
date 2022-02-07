using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Item
    {
        public Rectangle rec;

        protected Color color = Color.WHITE;

        public bool active = true;

        public Item(int x, int y, int w, int h)
        {
            rec = new Rectangle(x, y, w, h);
        }

        public void Draw()
        {
            if (active)
            {
                Raylib.DrawRectangleRec(rec, color);
            }
        }


    }

}