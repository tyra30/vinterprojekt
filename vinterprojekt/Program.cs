using System;
using System.Collections.Generic;
using Raylib_cs;

namespace vinterprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //GAME
            int screenWidth = 1920;
            int screenHeight = 1000;
            string gamestate = "level1";

            //LEVEL 1
            Button level1P = new Button(650, 900, 150, 150, 60, "P");
            Button level1L = new Button(1510, 550, 50, 50, 30, "L");
            Button level1A = new Button(1250, 150, 200, 100, 200, "A");
            Button level1Y = new Button(1400, 550, 50, 50, 30, "Y");
            Button level1b = new Button(675, 500, 600, 210, 30, "");

            //LEVEL 2
            Player snowman = new Player(50, 400);
            List<Platform> platformsLevel2 = new List<Platform>();

            platformsLevel2.Add(new Platform(0, 800, 1920, 200)); //platformsLevel2[0]
            platformsLevel2.Add(new Platform(400, 500, 100, 50)); //platformsLevel2[1]

            Color startColor = Color.LIGHTGRAY;

            List<Item> itemsLevel2 = new List<Item>();

            itemsLevel2.Add(new Key(200, 200, 50, 50)); //key[0]
            itemsLevel2.Add(new Coin(800, 300, 50, 50)); //coin[1]
            itemsLevel2.Add(new Coin(1200, 500, 50, 50)); //coin[2]

            Door door = new Door(1850, 700, 50, 100);


            //RAYLIB INITIALIZATION
            Raylib.InitWindow(screenWidth, screenHeight, "5000 IQ GAME winter edition");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                if (gamestate == "level1")
                {
                    //LOGIC

                    level1P.Update();
                    level1L.Update();
                    level1A.Update();
                    level1Y.Update();


                    if (level1P.isPressed == true && level1L.isPressed == true && level1A.isPressed == true && level1Y.isPressed == true)
                    {
                        level1b.Update();
                        startColor = Color.BLACK;
                    }

                    if (level1b.isPressed == true)
                    {
                        gamestate = "level2";
                    }

                    //DRAW
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);



                    Raylib.DrawText("5000 IQ GAME", 250, 150, 200, Color.BLACK);
                    Raylib.DrawText("winter edition", 650, 320, 100, Color.BLACK);
                    Raylib.DrawText("Press PLAY to begin", 650, 900, 60, Color.BLACK);
                    Raylib.DrawRectangle(675, 500, 600, 210, startColor);
                    Raylib.DrawText("PLAY", 705, 525, 200, Color.WHITE);
                    Raylib.DrawText("YOU WILL FEEL STUPID", 1400, 550, 30, Color.BLACK);
                    Raylib.DrawText("AFTER PLAYING THIS GAME!", 1400, 580, 30, Color.BLACK);
                    Raylib.DrawText("-Game tester", 1400, 620, 20, Color.BLACK);
                    Raylib.DrawText("P", 650, 900, 60, Color.DARKBLUE);
                    Raylib.DrawText("L", 1510, 550, 30, Color.DARKBLUE);
                    Raylib.DrawText("A", 1250, 150, 200, Color.DARKBLUE);
                    Raylib.DrawText("Y", 1400, 550, 30, Color.DARKBLUE);

                    level1P.Draw();
                    level1L.Draw();
                    level1A.Draw();
                    level1Y.Draw();



                    Raylib.EndDrawing();
                }
                else if (gamestate == "level2")
                {
                    //LOGIK LEVEL2
                    snowman.Update();

                    foreach (Platform p in platformsLevel2)
                    {
                        if (Raylib.CheckCollisionRecs(snowman.rec, p.rec))
                        {
                            snowman.Collide(p.rec);
                        }
                    }

                    foreach (Item item in itemsLevel2)
                    {
                        if (Raylib.CheckCollisionRecs(snowman.rec, item.rec) && item.active)
                        {
                            snowman.Pickup(item);
                        }
                    }

                    if (Raylib.CheckCollisionRecs(snowman.rec, door.rec))
                    {
                        if (snowman.HasKey())
                        {
                            gamestate = "level3";
                        }
                    }



                    //DRAW LEVEL 2

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.SKYBLUE);

                    snowman.Draw();

                    foreach (Platform p in platformsLevel2)
                    {
                        p.Draw();
                    }

                    foreach (Item item in itemsLevel2)
                    {
                        item.Draw();
                    }

                    door.Draw();

                    Raylib.DrawText("Coins: " + snowman.coinCounter, 1600, 10, 50, Color.BLACK);


                    Raylib.EndDrawing();

                }
                else if (gamestate == "level3")
                {
                    //DRAW LEVEL 3

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.EndDrawing();
                }
            }
        }
    }
}
