using Raylib_cs;

class picball2:GameObject{
    Texture2D texture;
    int picball2size = 10;

    public picball2(){
        var image = Raylib.LoadImage("teach.png");
        Raylib.ImageResize(ref image, 50,53);
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

     public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, 50, 53);
    }

    public override void Draw() {
        Raylib.DrawTexture(this.texture, (int)Position.X, (int)Position.Y, Color.WHITE);
        // Raylib.DrawRectangle((int)Position.X, (int)Position.Y, picball2size, picball2size, Color.WHITE);
    }


}