
using System;
using Raylib_cs;

namespace Simple_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle player = new Rectangle(400, 300, 20, 20);
            Rectangle borderNorth = new Rectangle(0, 0, 800, 1);
            Rectangle borderWest = new Rectangle(0, 0, 1, 600);
            Rectangle borderSouth = new Rectangle(0, 599, 800, 1);
            Rectangle borderEast = new Rectangle(799, 0, 1, 600);
            Rectangle shot = new Rectangle(1000, 1000, 10, 10);
            Rectangle enemy = new Rectangle(0, 0, 20, 20);
            string direction = "up";
            string screen = "game";
            float shotX = 0;
            float shotY = 0;
            int shotCount = 0;
            int reload = 1;
            bool enemyAlive = true;
            bool shotAlive = false;


            Raylib.InitWindow(800, 600, "buck");
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                // if (screen == "intro")
                // {
                //     Raylib.ClearBackground(Color.GRAY);
                //     Raylib.DrawText("")
                // }

                if (screen == "game")
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !Raylib.CheckCollisionRecs(player, borderNorth))
                    {
                        player.y -= 2.5f;
                        direction = "up";
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !Raylib.CheckCollisionRecs(player, borderWest))
                    {
                        player.x -= 2.5f;
                        direction = "left";
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && !Raylib.CheckCollisionRecs(player, borderSouth))
                    {
                        player.y += 2.5f;
                        direction = "down";
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !Raylib.CheckCollisionRecs(player, borderEast))
                    {
                        player.x += 2.5f;
                        direction = "right";
                    }


                    if (enemy.x < player.x)
                    {
                        enemy.x += 2f;
                    }

                    if (enemy.x > player.x)
                    {
                        enemy.x -= 2f;
                    }

                    if (enemy.y < player.y)
                    {
                        enemy.y += 2f;
                    }

                    if (enemy.y > player.y)
                    {
                        enemy.y -= 2f;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy))
                    {
                        enemyAlive = false;
                        shotCount = 0;
                    }

                    reload--;
                    shot.x += shotX;
                    shot.y += shotY;

                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawRectangleRec(player, Color.RED);

                    if (enemyAlive == true)
                    {
                        Raylib.DrawRectangleRec(enemy, Color.BLUE);
                    }

                    if (shotAlive == true)
                    {
                        Raylib.DrawRectangleRec(shot, Color.GREEN);
                    }

                    if (Raylib.CheckCollisionRecs(shot, borderNorth) || Raylib.CheckCollisionRecs(shot, borderWest) || Raylib.CheckCollisionRecs(shot, borderSouth) || Raylib.CheckCollisionRecs(shot, borderEast) || Raylib.CheckCollisionRecs(shot, enemy))
                    {
                        shotCount = 0;
                        shotAlive = false;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "up")
                    {
                        shot.x = player.x + 5;
                        shot.y = player.y - 10;
                        shotX = 0;
                        shotY = -3.5f;
                        reload = 1;
                        shotCount = 1;
                        shotAlive = true;
                    }
                    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "left")
                    {
                        shot.x = player.x - 10;
                        shot.y = player.y + 5;
                        shotX = -3.5f;
                        shotY = 0;
                        reload = 1;
                        shotCount = 1;
                        shotAlive = true;
                    }
                    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "down")
                    {
                        shot.x = player.x + 5;
                        shot.y = player.y + 20;
                        shotX = 0;
                        shotY = 3.5f;
                        reload = 1;
                        shotCount = 1;
                        shotAlive = true;
                    }
                    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "right")
                    {
                        shot.x = player.x + 20;
                        shot.y = player.y + 5;
                        shotX = 3.5f;
                        shotY = 0;
                        reload = 1;
                        shotCount = 1;
                        shotAlive = true;
                    }
                }
                Raylib.EndDrawing();

            }
        }
    }
}
