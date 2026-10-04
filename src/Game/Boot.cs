using Godot;

namespace NPAD.Game;

public partial class Boot : Node
{
    public override void _Ready()
    {
        GetTree().ChangeSceneToFile("res://scenes/Main.tscn");
    }
}
