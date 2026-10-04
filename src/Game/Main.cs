using Godot;
using System;

namespace NPAD.Game;

public partial class Main : Node2D
{
    private const int InitialEnemyCount = 5;
    private const float SpawnInterval = 3.0f;

    private Player? _player;
    private Label? _hud;
    private float _spawnTimer = 0f;

    public override void _Ready()
    {
        ConfigureInputActions();

        var bg = new ColorRect
        {
            Name = "Background",
            Size = new Vector2(960, 540),
            Position = new Vector2(0, 0),
            Color = new Color(0.08f, 0.09f, 0.12f)
        };
        AddChild(bg);

        _player = new Player
        {
            Name = "Player",
            Position = new Vector2(480, 270)
        };
        AddChild(_player);

        _hud = new Label
        {
            Name = "HUD",
            Position = new Vector2(20, 20),
            Text = "HP: 5 | Dash: 2/2",
            ZIndex = 10
        };
        _hud.AddThemeColorOverride("font_color", new Color(1, 1, 1));
        AddChild(_hud);

        for (int i = 0; i < InitialEnemyCount; i++)
        {
            SpawnEnemy(new Vector2(100 + i * 120, 120 + (i % 3) * 120));
        }
    }

    public override void _Process(double delta)
    {
        if (_player == null || _player.IsDead)
        {
            return;
        }

        _spawnTimer -= (float)delta;
        if (_spawnTimer <= 0f)
        {
            SpawnEnemy(GetRandomSpawnPosition());
            _spawnTimer = SpawnInterval;
        }

        if (_hud != null)
        {
            _hud.Text = $"HP: {_player.Health} | Dash: {_player.DashCharges}/{_player.MaxDashCharges} | Attack: {_player.AttackCooldown:F1}s";
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Random random = new Random();
        int side = random.Next(4);

        return side switch
        {
            0 => new Vector2(-30, random.Next(0, 540)),
            1 => new Vector2(990, random.Next(0, 540)),
            2 => new Vector2(random.Next(0, 960), -30),
            _ => new Vector2(random.Next(0, 960), 570),
        };
    }

    private void SpawnEnemy(Vector2 spawnPosition)
    {
        if (_player == null)
        {
            return;
        }

        var enemy = new Enemy
        {
            Name = "Enemy",
            Position = spawnPosition,
            Target = _player
        };

        AddChild(enemy);
    }

    private static void ConfigureInputActions()
    {
        EnsureAction("move_left", Key.A, Key.Left);
        EnsureAction("move_right", Key.D, Key.Right);
        EnsureAction("move_up", Key.W, Key.Up);
        EnsureAction("move_down", Key.S, Key.Down);
        EnsureAction("dash", Key.Shift, Key.Space);
        EnsureAction("attack", Key.J, Key.K, Key.Space);
    }

    private static void EnsureAction(string action, params Key[] keys)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        InputMap.ActionEraseEvents(action);
        foreach (var key in keys)
        {
            var ev = new InputEventKey { Keycode = key, PhysicalKeycode = key };
            InputMap.ActionAddEvent(action, ev);
        }
    }
}
