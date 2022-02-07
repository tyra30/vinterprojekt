using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

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
        private float margin = 13f;

        public int xDir = 0;

        private int speed = 10;

        public float yVel = 0;

        const float gravity = 0.5f;

        public float yAcc = gravity;

        public bool isGrounded;

        public List<Item> inventory = new List<Item>();

        public int coinCounter = 0;


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
            isGrounded = false;

            rec.x += xDir * speed;

            yVel += yAcc;
            rec.y += yVel;

            UpdateCollisionBoxes();

            UpdateCoinCounter();

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
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP) && isGrounded)
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



        public void Collide(Rectangle r)
        {

            //TOP COLLISION
            if (Raylib.CheckCollisionRecs(top, r) && yVel < 0)
            {
                rec.y = r.y + r.height;
                yVel = 0;
            }
            //DOWN COLLISION
            else if (Raylib.CheckCollisionRecs(down, r) && yAcc > 0)
            {
                rec.y = r.y - rec.height;
                yVel = 0;
                isGrounded = true;
            }
            //RIGHT COLLISION
            else if (Raylib.CheckCollisionRecs(right, r) && xDir > 0)
            {
                rec.x = r.x - rec.width;
                xDir = 0;
            }
            //LEFT COLLISION
            else if (Raylib.CheckCollisionRecs(left, r) && xDir < 0)
            {
                rec.x = r.x + r.width;
                xDir = 0;
            }

            UpdateCollisionBoxes();
        }

        public void Pickup(Item item)
        {
            item.active = false;

            inventory.Add(item);

        }

        public bool HasKey()
        {
            foreach (Item item in inventory)
            {
                if (item is Key)
                {
                    return true;
                }
            }

            return false;

        }


        private void UpdateCoinCounter()
        {
            int counter = 0;
            foreach (Item item in inventory)
            {
                if (item is Coin)
                {
                    counter++;
                }
            }
            coinCounter = counter;
        }
    }
}