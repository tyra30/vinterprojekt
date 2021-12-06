using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Player
    {
        public Rectangle rec;

        public int xDir = 0;

        public int speed = 10;


        public Player(int x, int y, int w, int h)
        {
            rec = new Rectangle(x, y, w, h);
        }

        public void Update()
        {
            KeyboardInput();

            rec.x += xDir * speed;
        }


        private void KeyboardInput()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                xDir = -1;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                xDir = 1;
            }
            else
            {
                xDir = 0;
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, Color.BLACK);

        }

    }
}