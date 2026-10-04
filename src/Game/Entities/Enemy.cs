using Godot;

namespace NPAD.Game.Entities;

public partial class Enemy : CharacterBody2D
{
    [Export] public float MoveSpeed { get; set; } = 75f;
    [Export] public float AttackRange { get; set; } = 28f;
    [Export] public int MaxHealth { get; set; } = 2;
    [Export] public int Damage { get; set; } = 1;

    public Player? Target { get; set; }
    public int Health { get; private set; }

    private float _attackCooldown = 0f;
    private ColorRect _sprite;

    public override void _Ready()
    {
        Health = MaxHealth;

        _sprite = new ColorRect
        {
            Size = new Vector2(18, 18),
            Position = new Vector2(-9, -9),
            Color = new Color(0.88f, 0.32f, 0.32f)
        };

        AddChild(_sprite);
    }

    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;

        if (_attackCooldown > 0f)
        {
            _attackCooldown -= dt;
        }

        if (Target == null || Target.IsDead)
        {
            return;
        }

        Vector2 toTarget = Target.GlobalPosition - GlobalPosition;
        float dist = toTarget.Length();

        if (dist > 0.01f)
        {
            var direction = toTarget.Normalized();
            Velocity = direction * MoveSpeed;
            MoveAndSlide();
        }

        if (dist <= AttackRange)
        {
            if (_attackCooldown <= 0f)
            {
                Target.TakeDamage(Damage);
                _attackCooldown = 0.8f;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            QueueFree();
        }
    }
}
