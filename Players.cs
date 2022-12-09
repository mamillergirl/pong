using Raylib_cs;
using System.Numerics;

class Players: GameObject{

    public Players(){
    }
    
    // public override void Move(){

}

class Player1 : Players{

    public Player1(){

    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 2, 5, Color.PINK);

    }
}

class Player2: Players{
      public Player2(){

    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 2, 5, Color.PINK);

    }
}