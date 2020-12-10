
using System;
using Raylib_cs;

namespace Simple_game
{
    class Program
    {
        static void Main(string[] args)
        {
            string direction = "up";
            string screen = "intro";
            float shotX = 0;
            float shotY = 0;
            int shotCount = 0;
            int reload = 1;
            int wave = 0;
            int shotSizeY = 10;
            int shotSizeX = 10;
            int enemyBossHp = 5;
            bool enemy1Alive = true;
            bool enemy2Alive = true;
            bool enemy3Alive = true;
            bool enemy4Alive = true;
            bool enemy5Alive = true;
            bool enemy6Alive = true;
            bool enemy7Alive = true;
            bool enemyS1Alive = true;
            bool enemyS2Alive = true;
            bool enemyS3Alive = true;
            bool enemyBossAlive = true;
            bool shotAlive = false;
            bool powerUpAlive = true;
            int[] enemies = new int[9];
            Rectangle player = new Rectangle(400, 300, 20, 20);
            Rectangle borderNorth = new Rectangle(0, 0, 800, 1);
            Rectangle borderWest = new Rectangle(0, 0, 1, 600);
            Rectangle borderSouth = new Rectangle(0, 599, 800, 1);
            Rectangle borderEast = new Rectangle(799, 0, 1, 600);
            Rectangle shot = new Rectangle(1000, 1000, shotSizeX, shotSizeY);
            Rectangle enemy1 = new Rectangle(0, 0, 20, 20);
            Rectangle enemy2 = new Rectangle(0, 0, 20, 20);
            Rectangle enemy3 = new Rectangle(780, 580, 20, 20);
            Rectangle enemy4 = new Rectangle(0, 0, 20, 20);
            Rectangle enemy5 = new Rectangle(780, 580, 20, 20);
            Rectangle enemy6 = new Rectangle(0, 0, 20, 20);
            Rectangle enemy7 = new Rectangle(780, 585, 20, 20);
            Rectangle enemyS1 = new Rectangle(785, 0, 15, 15);
            Rectangle enemyS2 = new Rectangle(785, 0, 15, 15);
            Rectangle enemyS3 = new Rectangle(0, 585, 15, 15);
            Rectangle enemyBoss = new Rectangle(0, 0, 40, 40);
            Rectangle powerUp = new Rectangle(140, 450, 15, 15);

            Raylib.InitWindow(800, 600, "Game");
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                if (screen == "intro")
                {
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Press enter to start", 165, 200, 40, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        screen = "game";
                        wave = 1;
                    }
                }

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

                    if (enemy1.x < player.x)
                    {
                        enemy1.x += 2f;
                    }

                    if (enemy1.x > player.x)
                    {
                        enemy1.x -= 2f;
                    }

                    if (enemy1.y < player.y)
                    {
                        enemy1.y += 2f;
                    }

                    if (enemy1.y > player.y)
                    {
                        enemy1.y -= 2f;
                    }

                    if (enemy2.x < player.x)
                    {
                        enemy2.x += 2f;
                    }

                    if (enemy2.x > player.x)
                    {
                        enemy2.x -= 2f;
                    }

                    if (enemy2.y < player.y)
                    {
                        enemy2.y += 2f;
                    }

                    if (enemy2.y > player.y)
                    {
                        enemy2.y -= 2f;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy1))
                    {
                        enemy1Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy2))
                    {
                        enemy2Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy3))
                    {
                        enemy3Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy4))
                    {
                        enemy4Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy5))
                    {
                        enemy5Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy6))
                    {
                        enemy6Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemy7))
                    {
                        enemy7Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyS1))
                    {
                        enemyS1Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyS2))
                    {
                        enemyS2Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyS3))
                    {
                        enemyS3Alive = false;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyBoss))
                    {
                        enemyBossHp--;
                        shotCount = 0;
                    }

                    if (enemyBossHp == 0)
                    {
                        enemyBossAlive = false;
                    }

                    reload--;
                    shot.x += shotX;
                    shot.y += shotY;

                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawRectangleRec(player, Color.RED);

                    if (enemy1Alive == true && wave == 1)
                    {
                        Raylib.DrawRectangleRec(enemy1, Color.BLUE);
                    }

                    if (enemy2Alive == true && wave == 2)
                    {
                        Raylib.DrawRectangleRec(enemy2, Color.BLUE);
                    }

                    if (enemy3Alive == true && wave == 2)
                    {
                        Raylib.DrawRectangleRec(enemy3, Color.BLUE);
                    }

                    if (enemy4Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemy4, Color.BLUE);
                    }

                    if (enemy5Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemy5, Color.BLUE);
                    }

                    if (enemy6Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemy6, Color.BLUE);
                    }

                    if (enemy7Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemy7, Color.BLUE);
                    }

                    if (enemyS1Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemyS1, Color.BLUE);
                    }

                    if (enemyS2Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemyS2, Color.BLUE);
                    }

                    if (enemyS3Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemyS3, Color.BLUE);
                    }

                    if (enemyBossAlive == true && wave == 5)
                    {
                        Raylib.DrawRectangleRec(enemyBoss, Color.BLUE);
                    }

                    if (shotAlive == true)
                    {
                        Raylib.DrawRectangleRec(shot, Color.GREEN);
                    }

                    if (Raylib.CheckCollisionRecs(shot, borderNorth) || Raylib.CheckCollisionRecs(shot, borderWest) || Raylib.CheckCollisionRecs(shot, borderSouth) || Raylib.CheckCollisionRecs(shot, borderEast) || Raylib.CheckCollisionRecs(shot, enemy1))
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

                    if (enemy1Alive == false)
                    {
                        wave = 2;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false)
                    {
                        wave = 3;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false && enemy4Alive == false && enemy6Alive == false && enemyS1Alive == false)
                    {
                        wave = 4;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false && enemy4Alive == false && enemy6Alive == false && enemy7Alive == false && enemy7Alive == false && enemyS1Alive == false && enemyS2Alive == false && enemyS3Alive == false)
                    {
                        wave = 5;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false && enemy4Alive == false && enemy6Alive == false && enemy7Alive == false && enemy7Alive == false && enemyS1Alive == false && enemyS2Alive == false && enemyS3Alive == false && enemyBossAlive == false)
                    {
                        screen = "win";
                    }


                    if (wave > 1 && powerUpAlive == true)
                    {
                        Raylib.DrawRectangleRec(powerUp, Color.BLUE);
                    }

                }
                Raylib.EndDrawing();

            }
        }
    }
}
