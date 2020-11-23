
using System;
using Raylib_cs;

namespace Simple_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle player = new Rectangle(400, 300, 20, 20);
            int reload = 1;
            string direction = "up";

            Raylib.InitWindow(800, 600, "buck");
            while (!Raylib.WindowShouldClose())
            {
                Rectangle shotUp = new Rectangle(player.x + 5, player.y - 10, 10, 10);
                Rectangle shotLeft = new Rectangle(player.x - 10, player.y + 5, 10, 10);
                Rectangle shotDown = new Rectangle(player.x + 5, player.y + 20, 10, 10);
                Rectangle shotRight = new Rectangle(player.x + 20, player.y + 5, 10, 10);

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

                reload--;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Raylib.DrawRectangleRec(player, Color.RED);
                if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && reload < 0 && direction == "up")
                {
                    Raylib.DrawRectangleRec(shotUp, Color.GREEN);
                    reload = 1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && reload < 0 && direction == "left")
                {
                    Raylib.DrawRectangleRec(shotLeft, Color.GREEN);
                    reload = 1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && reload < 0 && direction == "down")
                {
                    Raylib.DrawRectangleRec(shotDown, Color.GREEN);
                    reload = 1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && reload < 0 && direction == "right")
                {
                    Raylib.DrawRectangleRec(shotRight, Color.GREEN);
                    reload = 1;
                }
                Raylib.EndDrawing();

            }
        }
    }
}
