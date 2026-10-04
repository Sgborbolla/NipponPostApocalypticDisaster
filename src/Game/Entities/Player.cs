using Godot;

namespace NPAD.Game.Entities;

public partial class Player : CharacterBody2D
{
    [Export] public float MoveSpeed { get; set; } = 220f;
    [Export] public float DashSpeed { get; set; } = 560f;
    [Export] public float DashDuration { get; set; } = 0.18f;
    [Export] public float DashCooldown { get; set; } = 0.35f;
    [Export] public float AttackRange { get; set; } = 56f;
    [Export] public float AttackCooldown { get; set; } = 0.35f;

    public int MaxHealth { get; private set; } = 5;
    public int Health { get; private set; }
    public int MaxDashCharges { get; private set; } = 2;
    public int DashCharges { get; private set; }
    public bool IsDead => Health <= 0;

    private Vector2 _moveDirection = Vector2.Zero;
    private Vector2 _dashDirection = Vector2.Zero;
    private float _dashTimer = 0f;
    private float _dashCooldownTimer = 0f;
    private float _attackCooldownTimer = 0f;
    private bool _isDashing = false;
    private ColorRect _sprite;

    public override void _Ready()
    {
        Health = MaxHealth;
        DashCharges = MaxDashCharges;

        _sprite = new ColorRect
        {
            Size = new Vector2(24, 24),
            Position = new Vector2(-12, -12),
            Color = new Color(1f, 1f, 1f, 1f)
        };

        AddChild(_sprite);
    }

    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;

        if (_dashCooldownTimer > 0f)
        {
            _dashCooldownTimer -= dt;
        }

        if (_attackCooldownTimer > 0f)
        {
            _attackCooldownTimer -= dt;
        }

        if (_isDashing)
        {
            _dashTimer -= dt;
            Velocity = _dashDirection * DashSpeed;
            MoveAndSlide();

            if (_dashTimer <= 0f)
            {
                _isDashing = false;
                Velocity = Vector2.Zero;
            }

            return;
        }

        Vector2 input = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        _moveDirection = input;

        if (input != Vector2.Zero)
        {
            input = input.Normalized();
            Velocity = input * MoveSpeed;
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        MoveAndSlide();

        if (Input.IsActionJustPressed("dash") && DashCharges > 0 && _dashCooldownTimer <= 0f)
        {
            StartDash();
        }

        if (Input.IsActionJustPressed("attack") && _attackCooldownTimer <= 0f)
        {
            TryAttack();
        }

        if (_dashCooldownTimer <= 0f && DashCharges < MaxDashCharges)
        {
            DashCharges++;
        }
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }

        Health = Mathf.Max(0, Health - amount);
    }

    public void Heal(int amount)
    {
        Health = Mathf.Min(MaxHealth, Health + amount);
    }

    private void StartDash()
    {
        Vector2 input = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        if (input == Vector2.Zero)
        {
            input = _moveDirection;
        }

        if (input == Vector2.Zero)
        {
            input = Vector2.Right;
        }

        DashCharges--;
        _dashDirection = input.Normalized();
        _dashTimer = DashDuration;
        _dashCooldownTimer = DashCooldown;
        _isDashing = true;
    }

    private void TryAttack()
    {
        _attackCooldownTimer = AttackCooldown;

        var parent = GetParent();
        if (parent == null)
        {
            return;
        }

        foreach (var child in parent.GetChildren())
        {
            if (child is not Enemy enemy)
            {
                continue;
            }

            float dist = GlobalPosition.DistanceTo(enemy.GlobalPosition);
            if (dist <= AttackRange)
            {
                enemy.TakeDamage(1);
            }
        }
    }
}
