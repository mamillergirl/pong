using Raylib_cs;
using System.Numerics;

class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}
class ColoredObject: GameObject {
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}
class CollectibleObject: ColoredObject{
    public CollectibleObject(Color color):base(color){
        
    }
    public int Points = 0;
}

class DaddyRock: CollectibleObject {
    public int Size { get; set; }
    

    public DaddyRock(Color color, int size): base(color) {
        Size = size;
        Points = -50;
    }

    override public void Draw() {
        Raylib.DrawText("O",(int)Position.X, (int)Position.Y, Size, Color);
    
    }    }

class MiddleRock: CollectibleObject {
    public int Size { get; set; }
    

    public MiddleRock(Color color, int size): base(color) {
        Size = size;
        Points = -25;
    }

    override public void Draw() {
        Raylib.DrawText("o",(int)Position.X, (int)Position.Y, Size, Color);

    }   
}

class BabyRock: CollectibleObject {
    public int Size { get; set; }

    public BabyRock(Color color, int size): base(color) {
        Size = size;
        Points = -5;
    }

    override public void Draw() {
        Raylib.DrawText("o",(int)Position.X, (int)Position.Y, Size, Color);

    }   
}
class Gem: CollectibleObject {
    public int Size { get; set; }

    public Gem(Color color, int size): base(color) {
        Size = size;
        Points = 25;
    }

    override public void Draw() {
        Raylib.DrawText("*",(int)Position.X, (int)Position.Y, Size, Color);
    }   
}
class Ball: CollectibleObject{
    public int Radius { get; set; }
  

    public Ball(Color color, int radius): base(color){
        Radius = radius;
        
    }
    override public void Draw() {
        Raylib.DrawCircleV(Position, Radius, Color);
    
    }  
}



class Player: CollectibleObject {
    
    public int Width { get; set; }
    public int Height { get; set; }
    

    public Player(Color color, int width, int height): base(color) {
        Width = width;
        Height = height;
        

    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Width, Height, Color);
    
    }    }


