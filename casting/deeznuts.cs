// this is the ball class
using Raylib_cs;
public class Balls{
    Texture2D texture;
    public Balls()
    {
        var image = Raylib.LoadImage("teach.jpg");
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

}
