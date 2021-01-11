
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
            int enemyBoss1Hp = 3;
            int enemyBoss2Hp = 3;
            int enemyBoss3Hp = 3;
            int enemyBoss4Hp = 3;
            int powerTime = 200;
            int shotValue = 1;
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
            bool enemyBoss1Alive = false;
            bool enemyBoss2Alive = false;
            bool enemyBoss3Alive = false;
            bool enemyBoss4Alive = false;
            bool playerAlive = true;
            bool shotAlive = false;
            bool powerUpAlive = true;
            bool toggle1 = true;
            bool toggle2 = true;
            bool toggle3 = true;
            bool toggle4 = true;
            bool toggle5 = true;
            bool toggle6 = false;
            bool poweredUp = false;
            bool phase2 = false;
            Rectangle player = new Rectangle(400, 300, 20, 20);
            Rectangle borderNorth = new Rectangle(0, -1, 800, -1);
            Rectangle borderWest = new Rectangle(-1, 0, -1, 600);
            Rectangle borderSouth = new Rectangle(0, 600, 800, 0);
            Rectangle borderEast = new Rectangle(800, 0, 0, 600);
            Rectangle shot = new Rectangle(1000, 1000, shotSizeX, shotSizeY);
            Rectangle enemy1 = new Rectangle(0, 0, 20, 20);
            Rectangle enemy2 = new Rectangle(-100, 0, 20, 20);
            Rectangle enemy3 = new Rectangle(-100, 580, 20, 20);
            Rectangle enemy4 = new Rectangle(-100, 0, 20, 20);
            Rectangle enemy5 = new Rectangle(-100, 580, 20, 20);
            Rectangle enemy6 = new Rectangle(-100, 0, 20, 20);
            Rectangle enemy7 = new Rectangle(-100, 580, 20, 20);
            Rectangle enemyS1 = new Rectangle(-100, 0, 15, 15);
            Rectangle enemyS2 = new Rectangle(-100, 0, 15, 15);
            Rectangle enemyS3 = new Rectangle(-100, 585, 15, 15);
            Rectangle enemyBoss = new Rectangle(-150, 0, 40, 40);
            Rectangle powerUp = new Rectangle(140, 450, 15, 15);
            Rectangle enemyBoss1 = new Rectangle(-200, 0, 20, 20);
            Rectangle enemyBoss2 = new Rectangle(-200, 0, 20, 20);
            Rectangle enemyBoss3 = new Rectangle(-200, 0, 20, 20);
            Rectangle enemyBoss4 = new Rectangle(-200, 0, 20, 20);

            Raylib.InitWindow(800, 600, "Game");
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                if (screen == "intro")
                {
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Press enter to start", 165, 200, 40, Color.WHITE);
                    Raylib.DrawText("Press space for controls", 145, 300, 40, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        screen = "game";
                        wave = 1;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        screen = "controls";
                    }
                }

                if (screen == "controls")
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        screen = "game";
                        wave = 1;
                    }

                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Up = W", 100, 100, 30, Color.WHITE);
                    Raylib.DrawText("Left = A", 100, 150, 30, Color.WHITE);
                    Raylib.DrawText("Down = S", 100, 200, 30, Color.WHITE);
                    Raylib.DrawText("Right = D", 100, 250, 30, Color.WHITE);
                    Raylib.DrawText("space = Shoot", 100, 300, 30, Color.WHITE);
                    Raylib.DrawText("Press enter to start", 350, 200, 30, Color.WHITE);
                }

                if (screen == "game")
                {
                    //hur man rör på sig
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

                    if (Raylib.CheckCollisionRecs(shot, enemyBoss1))
                    {
                        enemyBoss1Hp--;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyBoss2))
                    {
                        enemyBoss2Hp--;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyBoss3))
                    {
                        enemyBoss3Hp--;
                        shotCount = 0;
                    }

                    if (Raylib.CheckCollisionRecs(shot, enemyBoss4))
                    {
                        enemyBoss4Hp--;
                        shotCount = 0;
                    }

                    if (toggle1 && enemyBossHp == 0) //togglar på bossens andra form
                    {
                        toggle1 = false;
                        phase2 = true;
                        enemyBossAlive = false;
                        enemyBoss1Alive = true;
                        enemyBoss2Alive = true;
                        enemyBoss3Alive = true;
                        enemyBoss4Alive = true;
                    }

                    if (enemyBoss1Hp == 0)
                    {
                        enemyBoss1Alive = false;
                    }

                    if (enemyBoss2Hp == 0)
                    {
                        enemyBoss2Alive = false;
                    }

                    if (enemyBoss3Hp == 0)
                    {
                        enemyBoss3Alive = false;
                    }

                    if (enemyBoss4Hp == 0)
                    {
                        enemyBoss4Alive = false;
                    }

                    if (Raylib.CheckCollisionRecs(player, enemy1) || Raylib.CheckCollisionRecs(player, enemy2) || Raylib.CheckCollisionRecs(player, enemy3) || Raylib.CheckCollisionRecs(player, enemy4) || Raylib.CheckCollisionRecs(player, enemy5) || Raylib.CheckCollisionRecs(player, enemy6) || Raylib.CheckCollisionRecs(player, enemy7) || Raylib.CheckCollisionRecs(player, enemyS1) || Raylib.CheckCollisionRecs(player, enemyS2) || Raylib.CheckCollisionRecs(player, enemyS3) || Raylib.CheckCollisionRecs(player, enemyBoss) || Raylib.CheckCollisionRecs(player, enemyBoss1) || Raylib.CheckCollisionRecs(player, enemyBoss2) || Raylib.CheckCollisionRecs(player, enemyBoss3) || Raylib.CheckCollisionRecs(player, enemyBoss4))
                    {
                        playerAlive = false;
                    }


                    reload--;
                    shot.x += shotX * shotValue;
                    shot.y += shotY * shotValue;

                    Raylib.ClearBackground(Color.WHITE);
                    if (playerAlive)
                    {
                        Raylib.DrawRectangleRec(player, Color.RED);
                    }
                    else
                    {
                        screen = "lose";
                    }

                    if (enemy1Alive == true && wave == 1) //en lång rad av hur fiendena följer efter dig
                    {
                        Raylib.DrawRectangleRec(enemy1, Color.BLUE);

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
                    }
                    else
                    {
                        enemy1.x = -100;
                    }

                    if (enemy2Alive == true && wave == 2)
                    {
                        Raylib.DrawRectangleRec(enemy2, Color.BLUE);
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
                    }
                    else
                    {
                        enemy2.x = -100;
                    }

                    if (enemy3Alive == true && wave == 2)
                    {
                        Raylib.DrawRectangleRec(enemy3, Color.BLUE);

                        if (enemy3.x < player.x)
                        {
                            enemy3.x += 2f;
                        }

                        if (enemy3.x > player.x)
                        {
                            enemy3.x -= 2f;
                        }

                        if (enemy3.y < player.y)
                        {
                            enemy3.y += 2f;
                        }

                        if (enemy3.y > player.y)
                        {
                            enemy3.y -= 2f;
                        }
                    }
                    else
                    {
                        enemy3.x = -100;
                    }

                    if (enemy4Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemy4, Color.BLUE);
                        if (enemy4.x < player.x)
                        {
                            enemy4.x += 2f;
                        }

                        if (enemy4.x > player.x)
                        {
                            enemy4.x -= 2f;
                        }

                        if (enemy4.y < player.y)
                        {
                            enemy4.y += 2f;
                        }

                        if (enemy4.y > player.y)
                        {
                            enemy4.y -= 2f;
                        }
                    }
                    else
                    {
                        enemy4.x = -100;
                    }

                    if (enemy5Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemy5, Color.BLUE);
                        if (enemy5.x < player.x)
                        {
                            enemy5.x += 2f;
                        }

                        if (enemy5.x > player.x)
                        {
                            enemy5.x -= 2f;
                        }

                        if (enemy5.y < player.y)
                        {
                            enemy5.y += 2f;
                        }

                        if (enemy5.y > player.y)
                        {
                            enemy5.y -= 2f;
                        }
                    }
                    else
                    {
                        enemy5.x = -100;
                    }

                    if (enemy6Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemy6, Color.BLUE);
                        if (enemy6.x < player.x)
                        {
                            enemy6.x += 2f;
                        }

                        if (enemy6.x > player.x)
                        {
                            enemy6.x -= 2f;
                        }

                        if (enemy6.y < player.y)
                        {
                            enemy6.y += 2f;
                        }

                        if (enemy6.y > player.y)
                        {
                            enemy6.y -= 2f;
                        }
                    }
                    else
                    {
                        enemy6.x = -100;
                    }

                    if (enemy7Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemy7, Color.BLUE);
                        if (enemy7.x < player.x)
                        {
                            enemy7.x += 2f;
                        }

                        if (enemy7.x > player.x)
                        {
                            enemy7.x -= 2f;
                        }

                        if (enemy7.y < player.y)
                        {
                            enemy7.y += 2f;
                        }

                        if (enemy7.y > player.y)
                        {
                            enemy7.y -= 2f;
                        }
                    }
                    else
                    {
                        enemy7.x = -100;
                    }

                    if (enemyS1Alive == true && wave == 3)
                    {
                        Raylib.DrawRectangleRec(enemyS1, Color.BLUE);

                        if (enemyS1.x < player.x)
                        {
                            enemyS1.x += 2.7f;
                        }

                        if (enemyS1.x > player.x)
                        {
                            enemyS1.x -= 2.7f;
                        }

                        if (enemyS1.y < player.y)
                        {
                            enemyS1.y += 2.7f;
                        }

                        if (enemyS1.y > player.y)
                        {
                            enemyS1.y -= 2.7f;
                        }
                    }
                    else
                    {
                        enemyS1.x = -100;
                    }

                    if (enemyS2Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemyS2, Color.BLUE);

                        if (enemyS2.x < player.x)
                        {
                            enemyS2.x += 2.7f;
                        }

                        if (enemyS2.x > player.x)
                        {
                            enemyS2.x -= 2.7f;
                        }

                        if (enemyS2.y < player.y)
                        {
                            enemyS2.y += 2.7f;
                        }

                        if (enemyS2.y > player.y)
                        {
                            enemyS2.y -= 2.7f;
                        }
                    }
                    else
                    {
                        enemyS2.x = -100;
                    }

                    if (enemyS3Alive == true && wave == 4)
                    {
                        Raylib.DrawRectangleRec(enemyS3, Color.BLUE);
                        if (enemyS3.x < player.x)
                        {
                            enemyS3.x += 2.7f;
                        }

                        if (enemyS3.x > player.x)
                        {
                            enemyS3.x -= 2.7f;
                        }

                        if (enemyS3.y < player.y)
                        {
                            enemyS3.y += 2.7f;
                        }

                        if (enemyS3.y > player.y)
                        {
                            enemyS3.y -= 2.7f;
                        }
                    }
                    else
                    {
                        enemyS3.x = -100;
                    }

                    if (enemyBossAlive == true && wave == 5)
                    {
                        Raylib.DrawRectangleRec(enemyBoss, Color.BLUE);
                        if (enemyBoss.x < player.x)
                        {
                            enemyBoss.x += 1.8f;
                        }

                        if (enemyBoss.x > player.x)
                        {
                            enemyBoss.x -= 1.8f;
                        }

                        if (enemyBoss.y < player.y)
                        {
                            enemyBoss.y += 1.8f;
                        }

                        if (enemyBoss.y > player.y)
                        {
                            enemyBoss.y -= 1.8f;
                        }

                        enemyBoss1.x = enemyBoss.x + 10;
                        enemyBoss1.y = enemyBoss.y + 10;
                        enemyBoss2.x = enemyBoss.x + 10;
                        enemyBoss2.y = enemyBoss.y + 10;
                        enemyBoss3.x = enemyBoss.x + 10;
                        enemyBoss3.y = enemyBoss.y + 10;
                        enemyBoss4.x = enemyBoss.x + 10;
                        enemyBoss4.y = enemyBoss.y + 10;
                    }
                    else
                    {
                        enemyBoss.x = -10000;
                    }

                    if (enemyBoss1Alive)
                    {
                        Raylib.DrawRectangleRec(enemyBoss1, Color.BLUE);
                    }

                    if (enemyBoss2Alive)
                    {
                        Raylib.DrawRectangleRec(enemyBoss2, Color.BLUE);
                    }

                    if (enemyBoss3Alive)
                    {
                        Raylib.DrawRectangleRec(enemyBoss3, Color.BLUE);
                    }

                    if (enemyBoss4Alive)
                    {
                        Raylib.DrawRectangleRec(enemyBoss4, Color.BLUE);
                    }

                    if (phase2) //bossens andra form
                    {
                        if (!Raylib.CheckCollisionRecs(enemyBoss1, borderWest))
                        {
                            enemyBoss1.x = enemyBoss1.x - 5;
                        }
                        else if (!Raylib.CheckCollisionRecs(enemyBoss1, borderNorth))
                        {
                            enemyBoss1.y = enemyBoss1.y - 5;
                        }

                        if (!Raylib.CheckCollisionRecs(enemyBoss2, borderEast))
                        {
                            enemyBoss2.x = enemyBoss2.x + 5;
                        }
                        else if (!Raylib.CheckCollisionRecs(enemyBoss2, borderNorth))
                        {
                            enemyBoss2.y = enemyBoss2.y - 5;
                        }

                        if (!Raylib.CheckCollisionRecs(enemyBoss3, borderWest))
                        {
                            enemyBoss3.x = enemyBoss3.x - 5;
                        }
                        else if (!Raylib.CheckCollisionRecs(enemyBoss3, borderSouth))
                        {
                            enemyBoss3.y = enemyBoss3.y + 5;
                        }

                        if (!Raylib.CheckCollisionRecs(enemyBoss4, borderEast))
                        {
                            enemyBoss4.x = enemyBoss4.x + 5;
                        }
                        else if (!Raylib.CheckCollisionRecs(enemyBoss4, borderSouth))
                        {
                            enemyBoss4.y = enemyBoss4.y + 5;
                        }

                        if (Raylib.CheckCollisionRecs(enemyBoss1, borderWest) && Raylib.CheckCollisionRecs(enemyBoss1, borderNorth) && Raylib.CheckCollisionRecs(enemyBoss2, borderEast) && Raylib.CheckCollisionRecs(enemyBoss2, borderNorth) && Raylib.CheckCollisionRecs(enemyBoss3, borderWest) && Raylib.CheckCollisionRecs(enemyBoss3, borderSouth) && Raylib.CheckCollisionRecs(enemyBoss4, borderEast) && Raylib.CheckCollisionRecs(enemyBoss4, borderSouth))
                        {
                            phase2 = false;
                            toggle6 = true;
                        }
                    }

                    if (toggle6) //bossarna i form 2 börjar röra på sig
                    {
                        if (enemyBoss1Alive)
                        {
                            if (enemyBoss1.x < player.x)
                            {
                                enemyBoss1.x += 2f;
                            }

                            if (enemyBoss1.x > player.x)
                            {
                                enemyBoss1.x -= 2f;
                            }

                            if (enemyBoss1.y < player.y)
                            {
                                enemyBoss1.y += 2f;
                            }

                            if (enemyBoss1.y > player.y)
                            {
                                enemyBoss1.y -= 2f;
                            }
                        }
                        else
                        {
                            enemyBoss1.x = -2000;
                        }

                        if (enemyBoss2Alive)
                        {
                            if (enemyBoss2.x < player.x)
                            {
                                enemyBoss2.x += 2f;
                            }

                            if (enemyBoss2.x > player.x)
                            {
                                enemyBoss2.x -= 2f;
                            }

                            if (enemyBoss2.y < player.y)
                            {
                                enemyBoss2.y += 2f;
                            }

                            if (enemyBoss2.y > player.y)
                            {
                                enemyBoss2.y -= 2f;
                            }
                        }
                        else
                        {
                            enemyBoss2.x = -2000;
                        }

                        if (enemyBoss3Alive)
                        {
                            if (enemyBoss3.x < player.x)
                            {
                                enemyBoss3.x += 2f;
                            }

                            if (enemyBoss3.x > player.x)
                            {
                                enemyBoss3.x -= 2f;
                            }

                            if (enemyBoss3.y < player.y)
                            {
                                enemyBoss3.y += 2f;
                            }

                            if (enemyBoss3.y > player.y)
                            {
                                enemyBoss3.y -= 2f;
                            }
                        }
                        else
                        {
                            enemyBoss3.x = -2000;
                        }

                        if (enemyBoss4Alive)
                        {
                            if (enemyBoss4.x < player.x)
                            {
                                enemyBoss4.x += 2f;
                            }

                            if (enemyBoss4.x > player.x)
                            {
                                enemyBoss4.x -= 2f;
                            }

                            if (enemyBoss4.y < player.y)
                            {
                                enemyBoss4.y += 2f;
                            }

                            if (enemyBoss4.y > player.y)
                            {
                                enemyBoss4.y -= 2f;
                            }
                        }
                        else
                        {
                            enemyBoss4.x = -2000;
                        }
                    }

                    if (wave == 2 && toggle2) //systemet för att spawna nya fiender
                    {
                        enemy2.x = 0;
                        enemy3.x = 780;
                        toggle2 = false;
                    }

                    if (wave == 3 && toggle3)
                    {
                        enemy4.x = 0;
                        enemy5.x = 780;
                        enemyS1.x = 785;
                        toggle3 = false;
                    }

                    if (wave == 4 && toggle4)
                    {
                        enemy6.x = 0;
                        enemy7.x = 780;
                        enemyS2.x = 785;
                        enemyS3.x = 0;
                        toggle4 = false;
                    }

                    if (wave == 5 && toggle5)
                    {
                        enemyBoss.x = 0;
                        toggle5 = false;
                    }

                    if (shotAlive == true)
                    {
                        Raylib.DrawRectangleRec(shot, Color.GREEN);
                    }
                    else
                    {
                        shot.x = -1000;
                        shot.y = -1000;
                    }

                    if (Raylib.CheckCollisionRecs(shot, borderNorth) || Raylib.CheckCollisionRecs(shot, borderWest) || Raylib.CheckCollisionRecs(shot, borderSouth) || Raylib.CheckCollisionRecs(shot, borderEast) || Raylib.CheckCollisionRecs(shot, enemy1) || Raylib.CheckCollisionRecs(shot, enemy2) || Raylib.CheckCollisionRecs(shot, enemy3) || Raylib.CheckCollisionRecs(shot, enemy4) || Raylib.CheckCollisionRecs(shot, enemy5) || Raylib.CheckCollisionRecs(shot, enemy6) || Raylib.CheckCollisionRecs(shot, enemy7) || Raylib.CheckCollisionRecs(shot, enemyS1) || Raylib.CheckCollisionRecs(shot, enemyS2) || Raylib.CheckCollisionRecs(shot, enemyS3) || Raylib.CheckCollisionRecs(shot, enemyBoss) || Raylib.CheckCollisionRecs(shot, enemyBoss1) || Raylib.CheckCollisionRecs(shot, enemyBoss2) || Raylib.CheckCollisionRecs(shot, enemyBoss3) || Raylib.CheckCollisionRecs(shot, enemyBoss4))
                    {
                        shotCount = 0; //ta bort skott om nuddar kanten
                        shotAlive = false;
                    }
                    //Skott beroende på vart man siktar
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

                    if (enemy1Alive == false) //wave byte
                    {
                        wave = 2;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false)
                    {
                        wave = 3;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false && enemy4Alive == false && enemy5Alive == false && enemyS1Alive == false)
                    {
                        wave = 4;
                    }

                    if (enemy1Alive == false && enemy2Alive == false && enemy3Alive == false && enemy4Alive == false && enemy5Alive == false && enemy6Alive == false && enemy7Alive == false && enemyS1Alive == false && enemyS2Alive == false && enemyS3Alive == false)
                    {
                        wave = 5;
                    }

                    if (enemyBossAlive == false && enemyBoss1Alive == false && enemyBoss2Alive == false && enemyBoss3Alive == false && enemyBoss4Alive == false)
                    {
                        screen = "win";
                    }



                    if (wave > 2 && powerUpAlive == true) //spawna power up
                    {
                        Raylib.DrawRectangleRec(powerUp, Color.YELLOW);
                    }

                    if (Raylib.CheckCollisionRecs(player, powerUp))
                    {
                        powerUpAlive = false;
                        poweredUp = true;
                    }

                    if (poweredUp) //effekt av powerup
                    {
                        powerTime--;
                        shotValue = 2;

                        if (powerTime < 0)
                        {
                            poweredUp = false;
                        }
                    }
                    else
                    {
                        shotValue = 1;
                    }
                }

                if (screen == "win") //Byte skärm när man vunnit
                {
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Victory", 300, 200, 40, Color.WHITE);
                    Raylib.DrawText("Press enter to play again", 250, 250, 20, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //kör igen
                    {
                        direction = "up";
                        screen = "game";
                        shotCount = 0;
                        reload = 1;
                        wave = 1;
                        shotSizeY = 10;
                        shotSizeX = 10;
                        enemyBossHp = 5;
                        powerTime = 200;
                        shotValue = 1;
                        enemy1Alive = true;
                        enemy2Alive = true;
                        enemy3Alive = true;
                        enemy4Alive = true;
                        enemy5Alive = true;
                        enemy6Alive = true;
                        enemy7Alive = true;
                        enemyS1Alive = true;
                        enemyS2Alive = true;
                        enemyS3Alive = true;
                        enemyBossAlive = true;
                        playerAlive = true;
                        shotAlive = false;
                        powerUpAlive = true;
                        toggle1 = true;
                        toggle2 = true;
                        toggle4 = true;
                        toggle3 = true;
                        toggle5 = true;
                        toggle6 = false;
                        poweredUp = false;
                        phase2 = false;
                        player.x = 400;
                        player.y = 300;
                        enemy1.x = 0;
                        enemy1.y = 0;
                        enemy2.y = 0;
                        enemy3.y = 580;
                        enemy4.y = 0;
                        enemy5.y = 580;
                        enemy6.y = 0;
                        enemy7.y = 580;
                        enemyS1.y = 0;
                        enemyS2.y = 0;
                        enemyS3.y = 585;
                        enemyBoss.y = 0;
                        enemyBoss1.y = 0;
                        enemyBoss2.y = 0;
                        enemyBoss3.y = 0;
                        enemyBoss4.y = 0;
                    }
                }

                if (screen == "lose") //VIsas om man dör
                {
                    Raylib.ClearBackground(Color.GRAY);
                    Raylib.DrawText("Game Over", 275, 200, 40, Color.WHITE);
                    Raylib.DrawText("Press enter to try again", 255, 250, 20, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //kör igen
                    {
                        direction = "up";
                        screen = "game";
                        shotCount = 0;
                        reload = 1;
                        wave = 1;
                        shotSizeY = 10;
                        shotSizeX = 10;
                        enemyBossHp = 5;
                        enemyBoss1Hp = 3;
                        enemyBoss2Hp = 3;
                        enemyBoss3Hp = 3;
                        enemyBoss4Hp = 3;
                        powerTime = 200;
                        shotValue = 1;
                        enemy1Alive = true;
                        enemy2Alive = true;
                        enemy3Alive = true;
                        enemy4Alive = true;
                        enemy5Alive = true;
                        enemy6Alive = true;
                        enemy7Alive = true;
                        enemyS1Alive = true;
                        enemyS2Alive = true;
                        enemyS3Alive = true;
                        enemyBossAlive = true;
                        enemyBoss1Alive = false;
                        enemyBoss2Alive = false;
                        enemyBoss3Alive = false;
                        enemyBoss4Alive = false;
                        playerAlive = true;
                        shotAlive = false;
                        powerUpAlive = true;
                        toggle1 = true;
                        toggle2 = true;
                        toggle4 = true;
                        toggle3 = true;
                        toggle5 = true;
                        toggle6 = false;
                        poweredUp = false;
                        phase2 = false;
                        player.x = 400;
                        player.y = 300;
                        enemy1.x = 0;
                        enemy1.y = 0;
                        enemy2.y = 0;
                        enemy3.y = 580;
                        enemy4.y = 0;
                        enemy5.y = 580;
                        enemy6.y = 0;
                        enemy7.y = 580;
                        enemyS1.y = 0;
                        enemyS2.y = 0;
                        enemyS3.y = 585;
                        enemyBoss.y = 0;
                        enemyBoss1.y = 0;
                        enemyBoss2.y = 0;
                        enemyBoss3.y = 0;
                        enemyBoss4.y = 0;
                    }
                }
                Raylib.EndDrawing();

            }
        }
    }
}

