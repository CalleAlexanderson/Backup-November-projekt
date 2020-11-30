
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
            float shotX = 0;
            float shotY = 0;
            int shotCount = 0;
            int reload = 1;
            bool enemyAlive = true;


            Raylib.InitWindow(800, 600, "buck");
            while (!Raylib.WindowShouldClose())
            {

                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    player.y -= 0.1f;
                    direction = "up";
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    player.x -= 0.1f;
                    direction = "left";
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    player.y += 0.1f;
                    direction = "down";
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    player.x += 0.1f;
                    direction = "right";
                }


                if (enemy.x < player.x)
                {
                    enemy.x += enemy.x + 0.1f;
                }

                if (enemy.x > player.x)
                {
                    enemy.x -= enemy.x - 0.1f;
                }

                reload--;
                shot.x += shotX;
                shot.y += shotY;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.DrawRectangleRec(player, Color.RED);

                if (enemyAlive == true)
                {
                    Raylib.DrawRectangleRec(enemy, Color.BLUE);
                }

                if (!Raylib.CheckCollisionRecs(shot, borderNorth) && !Raylib.CheckCollisionRecs(shot, borderWest) && !Raylib.CheckCollisionRecs(shot, borderSouth) && !Raylib.CheckCollisionRecs(shot, borderEast))
                {
                    Raylib.DrawRectangleRec(shot, Color.GREEN);
                }

                if (Raylib.CheckCollisionRecs(shot, borderNorth) || Raylib.CheckCollisionRecs(shot, borderWest) || Raylib.CheckCollisionRecs(shot, borderSouth) || Raylib.CheckCollisionRecs(shot, borderEast))
                {
                    shotCount = 0;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "up")
                {
                    shot.x = player.x + 5;
                    shot.y = player.y - 10;
                    shotX = 0;
                    shotY = -0.15f;
                    reload = 1;
                    shotCount = 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "left")
                {
                    shot.x = player.x - 10;
                    shot.y = player.y + 5;
                    shotX = -0.15f;
                    shotY = 0;
                    reload = 1;
                    shotCount = 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "down")
                {
                    shot.x = player.x + 5;
                    shot.y = player.y + 20;
                    shotX = 0;
                    shotY = 0.15f;
                    reload = 1;
                    shotCount = 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && shotCount == 0 && reload < 0 && direction == "right")
                {
                    shot.x = player.x + 20;
                    shot.y = player.y + 5;
                    shotX = 0.15f;
                    shotY = 0;
                    reload = 1;
                    shotCount = 1;
                }
                Raylib.EndDrawing();

            }
        }
    }
}
