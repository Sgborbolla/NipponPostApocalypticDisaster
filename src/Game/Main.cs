using Godot;

namespace NPAD.Game.Entities;

public partial class Enemy : CharacterBody2D
{
    [Export] public float MoveSpeed { get; set; } = 80f;

    private Node2D _target;
    private ColorRect _sprite;

    public override void _Ready()
    {
        _target = GetNode<Node2D>("/root/Main/Player");

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
        if (_target == null)
        {
            return;
        }

        Vector2 toTarget = (_target.GlobalPosition - GlobalPosition);
        if (toTarget.LengthSquared() > 0.01f)
        {
            Vector2 direction = toTarget.Normalized();
            Velocity = direction * MoveSpeed;
            MoveAndSlide();
        }
    }
}
