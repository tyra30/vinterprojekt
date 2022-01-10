using System;
using Raylib_cs;
using System.Numerics;

namespace vinterprojekt
{
    public class Player
    {
        public Rectangle rec = new Rectangle(0, 0, 50, 50);

        private Rectangle top;
        private Rectangle left;
        private Rectangle down;
        private Rectangle right;

        private float collisionThickness = 0.3f;
        private float margin = 24f;

        public int xDir = 0;

        private int speed = 10;

        public float yVel = 0;

        const float gravity = 0.5f;

        public float yAcc = gravity;

        public bool isGrounded;


        public Player(int x, int y)
        {
            rec.x = x;
            rec.y = y;

            top = new Rectangle(x + margin, y - collisionThickness, rec.width - margin * 2, collisionThickness * 2);
            left = new Rectangle(x - collisionThickness, y + margin, collisionThickness * 2, rec.height - margin * 2);
            down = new Rectangle(x + margin, y - collisionThickness + rec.height, rec.width - margin * 2, collisionThickness * 2);
            right = new Rectangle(x - collisionThickness + rec.width, y + margin, collisionThickness * 2, rec.height - margin * 2);

        }

        public void Update()
        {
            KeyboardInput();

            rec.x += xDir * speed;

            yVel += yAcc;
            rec.y += yVel;

            UpdateCollisionBoxes();

        }

        private void UpdateCollisionBoxes()
        {
            top.x = rec.x + margin;
            left.x = rec.x - collisionThickness;
            down.x = rec.x + margin;
            right.x = rec.x - collisionThickness + rec.width;

            top.y = rec.y - collisionThickness;
            left.y = rec.y + margin;
            down.y = rec.y - collisionThickness + rec.height;
            right.y = rec.y + margin;


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
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                yVel = -20f;
            }

        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(rec, Color.BLACK);

            Raylib.DrawRectangleRec(top, Color.RED);
            Raylib.DrawRectangleRec(left, Color.RED);
            Raylib.DrawRectangleRec(down, Color.RED);
            Raylib.DrawRectangleRec(right, Color.RED);

        }

        public void LandOnGround()
        {
            isGrounded = true;

            //Stop Player Y Movement
            yAcc = 0;
            yVel = 0;
        }

        public void Collide(Rectangle r)
        {

            //RIGHT COLLISION
            if (Raylib.CheckCollisionRecs(right, r))
            {
                rec.x = r.x - rec.width;
                xDir = 0;
            }
            //LEFT COLLISION
            else if (Raylib.CheckCollisionRecs(left, r))
            {
                rec.x = r.x + r.width;
                xDir = 0;
            }
            //TOP COLLISION
            else if (Raylib.CheckCollisionRecs(top, r))
            {
                rec.y = r.y + r.height;
                yVel = 0;
            }
            //DOWN COLLISION
            else if (Raylib.CheckCollisionRecs(down, r))
            {
                rec.y = r.y - rec.height;
                yVel = 0;
            }

            UpdateCollisionBoxes();
        }


    }
}