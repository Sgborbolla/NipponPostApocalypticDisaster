using Godot;
using NPAD.Game.Entities;

namespace NPAD.Game;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        ConfigureInputActions();

        var background = new ColorRect
        {
            Name = "Background",
            Size = new Vector2(1920, 1080),
            Position = new Vector2(0, 0),
            Color = new Color(0.08f, 0.09f, 0.12f)
        };
        AddChild(background);

        var player = new Player
        {
            Name = "Player",
            Position = new Vector2(480, 270)
        };
        AddChild(player);

        var enemy = new Enemy
        {
            Name = "Enemy",
            Position = new Vector2(700, 270),
            Target = player
        };
        AddChild(enemy);
    }

    private static void ConfigureInputActions()
    {
        EnsureAction("move_left", Key.A);
        EnsureAction("move_right", Key.D);
        EnsureAction("move_up", Key.W);
        EnsureAction("move_down", Key.S);
        EnsureAction("dash", Key.Shift);
    }

    private static void EnsureAction(string action, Key key)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        InputMap.ActionEraseEvents(action);
        var ev = new InputEventKey { Keycode = key, PhysicalKeycode = key };
        InputMap.ActionAddEvent(action, ev);
    }
}
