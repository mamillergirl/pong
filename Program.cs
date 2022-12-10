using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Random = new Random();
            
            int Player1Points = 0;
            int Player2Points = 0;

           
            var PlayerRectangle = new Rectangle(ScreenWidth - (ScreenWidth - 50), ScreenHeight / 100, 5, 180);
            var PlayerRectangle2 = new Rectangle(ScreenWidth - 50, ScreenHeight / 100, 5, 180);
            var MovementSpeed = 5;
            var ballPosition = new Vector2(ScreenWidth / 2, ScreenHeight / 2);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Pong Game ft Teach");
            Raylib.SetTargetFPS(250); 
            var randomY = Random.Next(1, 2);
            var velocityx = new List<int>{-1, 1};
          
            int index = Random.Next(velocityx.Count);
            var randomX = velocityx[index];
            var picBall2 = new picball2();
            
            picBall2.Position = ballPosition;
            
            picBall2.Position = ballPosition;

            picBall2.Velocity = new Vector2(randomX, randomY);

            

            while (!Raylib.WindowShouldClose())
            {
            
                randomY = Random.Next(1, 2);
                velocityx = new List<int>{-1, 1};
                index = Random.Next(velocityx.Count);

                randomX = velocityx[index];

               
                
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                    PlayerRectangle.y -= MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                    PlayerRectangle.y += MovementSpeed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_I)) {
                    PlayerRectangle2.y -= MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_K)) {
                    PlayerRectangle2.y += MovementSpeed;
                }
                
                
               
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawRectangleRec(PlayerRectangle, Color.PINK);
                Raylib.DrawRectangleRec(PlayerRectangle2, Color.PINK);
                picBall2.Draw();
                picBall2.Move();



        
               
       
                Raylib.DrawText($"Points: {Player1Points}", ScreenWidth - (ScreenWidth - 20), ScreenHeight - 30, 20, Color.WHITE);
                 Raylib.DrawText($"Points: {Player2Points}", ScreenWidth - 100, ScreenHeight - 30, 20, Color.WHITE);
                // Draw all of the objects in their current location
               

                Raylib.EndDrawing();

               
                    
                var ballrectangle = new Rectangle(picBall2.Position.X, picBall2.Position.Y, 10, 10);
                if (Raylib.CheckCollisionRecs(PlayerRectangle, ballrectangle)) {
                picBall2.Velocity = new Vector2(1, randomY);}
                else if (Raylib.CheckCollisionRecs(PlayerRectangle2, ballrectangle)) {
                picBall2.Velocity = new Vector2(-1, randomY);}
                if (picBall2.Position.Y >= (ScreenHeight - 20)) {
                    picBall2.Velocity = new Vector2(randomX, -1);
                } else if (picBall2.Position.Y <= 0) {
                    picBall2.Velocity = new Vector2(randomX , 1);
                }
                if (picBall2.Position.X >= (ScreenWidth)) {
                    Player1Points += 1;
                    picBall2.Position = ballPosition;
                    picBall2.Velocity = new Vector2(randomX , randomY);
                } else if (picBall2.Position.X <= 0) {
                    Player2Points += 1;
                    picBall2.Position = ballPosition;
                    picBall2.Velocity = new Vector2(randomX , randomY);
                }
                   
                
                
            }

            Raylib.CloseWindow();
        }
    }
}
                                        