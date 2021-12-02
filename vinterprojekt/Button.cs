using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Button
    {
        public Rectangle rec;

        public string label;

        public int fontSize;

        public bool isPressed = false;

        public Button(int x, int y, int w, int h, int size, string text)
        {
            rec = new Rectangle(x, y, w, h);
            label = text;
            fontSize = size;


        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, Color.BLANK);
            if (isPressed)
            {
                Raylib.DrawText(label, (int)rec.x, (int)rec.y, fontSize, Color.BLUE);
            }


        }

        public void Update()
        {
            if (isPressed == false)
            {
                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    isPressed = true;
                }
            }
        }
    }
}