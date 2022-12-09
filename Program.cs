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
            var Objects = new List<CollectibleObject>();
            var Random = new Random();
            
            int Player1Points = 0;
            int Player2Points = 0;

           
            var player1 = new Player1(); //ScreenWidth - (ScreenWidth - 50), ScreenHeight / 2, 5, 180);
            var player2 = new Player2(); //ScreenWidth - 50, ScreenHeight / 2, 5, 180);


            var MovementSpeed = 50;
            var ballPosition = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
            var ball = new Ball(Color.WHITE, 10);
            var randomY = Random.Next(1, 2);    
            var randomX = Random.Next(-1, 1);
            ball.Position = ballPosition; 

            ball.Velocity = new Vector2(randomX, randomY);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(50);

            var picBall2 = new picball2();
            picBall2.Position = ballPosition;

            while (!Raylib.WindowShouldClose())
            {
                //Add a new random object to the screen every iteration of our game loop
                //List<int> numbers = new List<int>()
                //{
                //    0,1, 1, 1 ,1,2, 2, 2, 2, 2,3, 3, 3, 3, 3, 3, 3,4, 4, 4,5,6,7,8,9,10
                //};
                //int randIndex = Random.Next(numbers.Count);
                //var whichType = numbers[randIndex];
                var whichType = Random.Next(30);
                // Generate a random velocity for this object
                
                var randomXstart = Random.Next(ScreenWidth);

                // Each object will start about the center of the screen
                var position = new Vector2(randomXstart, 0);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                    player1.Position.Y -= MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                    player1.Position.Y += MovementSpeed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_I)) {
                    player2.Position.Y -= MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_K)) {
                    player2.Position.Y += MovementSpeed;
                }
                
                
               
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                //test
                picBall2.Draw();
                player1.Draw();
                player2.Draw();
                // Raylib.DrawRectangleRec(PlayerRectangle, Color.PINK);
                // Raylib.DrawRectangleRec(PlayerRectangle2, Color.PINK);
                ball.Draw();
                ball.Move();



        
               
       
               
                Raylib.DrawText($"Points: {Player1Points}", ScreenWidth - (ScreenWidth - 20), ScreenHeight - 30, 20, Color.WHITE);
                 Raylib.DrawText($"Points: {Player2Points}", ScreenWidth - 100, ScreenHeight - 30, 20, Color.WHITE);
                // Draw all of the objects in their current location
               

                Raylib.EndDrawing();

               
                    
                var ballrectangle = new Rectangle(ball.Position.X, ball.Position.Y, 10, 10);
                if (Raylib.CheckCollisionRecs(PlayerRectangle, ballrectangle)) {
                ball.Velocity = new Vector2(1, randomY);}
                else if (Raylib.CheckCollisionRecs(PlayerRectangle2, ballrectangle)) {
                ball.Velocity = new Vector2(1, randomY);}
                if (ball.Position.Y >= (ScreenHeight - 20)) {
                    ball.Velocity = new Vector2(randomX, -1);
                } else if (ball.Position.Y <= 0) {
                    ball.Velocity = new Vector2(randomX , 1);
                }
                   
            
            Raylib.CloseWindow();}
        }
    }
}