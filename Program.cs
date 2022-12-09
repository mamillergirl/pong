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
            
            int TotalPoints = 300;

           
            var PlayerRectangle = new Rectangle(ScreenWidth - (ScreenWidth - 50), ScreenHeight / 2, 5, 180);
            var PlayerRectangle2 = new Rectangle(ScreenWidth - 50, ScreenHeight / 2, 5, 180);
            var MovementSpeed = 50;
            var ballPosition = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
            var ball = new Ball(Color.WHITE, 10);
            var randomY = Random.Next(1, 2);
    
            var randomX = Random.Next(-1, 1);
            ball.Position = ballPosition;

            ball.Velocity = new Vector2(randomX, randomY);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(50);

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
                ball.Draw();
                ball.Move();



        
               
       
                Raylib.DrawText($"Points: {TotalPoints}", 12, ScreenHeight - 30, 20, Color.WHITE);
                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                    
                    
                }

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    obj.Move();
                }
                foreach (var obj in Objects.ToList()){
                    var size = 20;
                    if (obj is DaddyRock){
                        size = 30;
                    }
                   else if (obj is BabyRock){
                        size = 15;
                    }
                    var rectangle = new Rectangle(obj.Position.X, obj.Position.Y, size, size);

                    if (Raylib.CheckCollisionRecs(PlayerRectangle, rectangle)) {
                    TotalPoints += obj.Points;
                    Objects.Remove(obj);}

                   
                }
                if (TotalPoints <= 0){
                        Raylib.ClearBackground(Color.BLACK);
                        Raylib.DrawText("Game Over", ScreenWidth / 2, ScreenHeight / 2, 20, Color.WHITE);

                        Raylib.CloseWindow();
                }
            }

            Raylib.CloseWindow();
        }
    }
}