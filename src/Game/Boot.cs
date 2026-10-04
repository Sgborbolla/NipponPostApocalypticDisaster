using Godot;

public partial class MainScene : Node2D
{
    public override void _Ready()
    {
        var camera = new Camera2D();
        AddChild(camera);

        var background = new ColorRect
        {
            Size = new Vector2(1920, 1080),
            Color = new Color(0.07f, 0.07f, 0.1f)
        };
        AddChild(background);

        // script preview; actual player created by Main.cs in code when needed
    }
}
