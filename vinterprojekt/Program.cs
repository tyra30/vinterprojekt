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
            string gamestate = "level2";

            //LEVEL 1
            Button level1P = new Button(650, 900, 150, 150, 60, "P");
            Button level1L = new Button(1510, 550, 50, 50, 30, "L");
            Button level1A = new Button(1250, 150, 200, 100, 200, "A");
            Button level1Y = new Button(1400, 550, 50, 50, 30, "Y");
            Button level1b = new Button(675, 500, 600, 210, 30, "");

            //LEVEL 2
            Player snowman = new Player(50, 50, 50, 50);

            Color startColor = Color.LIGHTGRAY;

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

                    //DRAW LEVEL 2

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    snowman.Draw();


                    Raylib.EndDrawing();

                }
            }
        }
    }
}
