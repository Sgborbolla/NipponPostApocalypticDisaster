using Godot;

namespace NPAD.Game.Entities;

public partial class Player : CharacterBody2D
{
    [Export] public float MoveSpeed { get; set; } = 220f;
    [Export] public float DashSpeed { get; set; } = 560f;
    [Export] public float DashDuration { get; set; } = 0.18f;
    [Export] public float DashCooldown { get; set; } = 0.35f;

    private Vector2 _moveDirection = Vector2.Zero;
    private Vector2 _dashDirection = Vector2.Zero;
    private float _dashTimer = 0f;
    private float _dashCooldownTimer = 0f;
    private bool _isDashing = false;

    private ColorRect _sprite;

    public override void _Ready()
    {
        _sprite = new ColorRect
        {
            Size = new Vector2(24, 24),
            Position = new Vector2(-12, -12),
            Color = Colors.White
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

        if (Input.IsActionJustPressed("dash") && _dashCooldownTimer <= 0f)
        {
            StartDash();
        }
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

        _dashDirection = input.Normalized();
        _dashTimer = DashDuration;
        _dashCooldownTimer = DashCooldown;
        _isDashing = true;
    }
}
