using Godot;

namespace NPAD.Game.Entities;

public partial class Enemy : CharacterBody2D
{
    [Export] public float MoveSpeed { get; set; } = 80f;
    [Export] public Node2D? Target { get; set; }

    private ColorRect _sprite;

    public override void _Ready()
    {
        if (Target == null)
        {
            var root = GetNodeOrNull<Node2D>("/root/Main");
            if (root != null)
            {
                Target = root.GetNodeOrNull<Node2D>("Player");
            }
        }

        _sprite = new ColorRect
        {
            Size = new Vector2(18, 18),
            Position = new Vector2(-9, -9),
            Color = new Color(0.9f, 0.3f, 0.3f)
        };

        AddChild(_sprite);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Target == null)
        {
            return;
        }

        Vector2 toTarget = Target.GlobalPosition - GlobalPosition;
        if (toTarget.LengthSquared() > 0.01f)
        {
            Vector2 direction = toTarget.Normalized();
            Velocity = direction * MoveSpeed;
            MoveAndSlide();
        }
    }
}
