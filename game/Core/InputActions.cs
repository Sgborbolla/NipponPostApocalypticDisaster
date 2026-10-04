// ============================================================================
//  InputActions.cs - Mapa de controles de §3.7, registrado por codigo.
//
//  §3.7:
//      WASD / Flechas / stick izq.    Mover (8 direcciones)
//      Espacio / J / Z / stick der.↓  ATACAR
//      Shift  / K / X / stick der.↑  DASH
//
//  Gamepad: stick izquierdo mueve, A ataca, B o RB hace dash.
//
//  ¿Por que en codigo y no en project.godot? El bloque de input serializado de
//  Godot es largo y fragil de escribir a mano; registrarlo aqui es tipado,
//  sobrevive a que alguien regenere el project.godot, y deja el rebind de §3.7
//  ("intercambio de botones A/B desde ajustes") en un solo sitio.
// ============================================================================

using Godot;

namespace NPAD.Game.Core;

public partial class InputActions : Node
{
    // Solo dos botones de accion. §0/§1: no hay tercero, las reliquias y los
    // poderes se activan con el mismo dash (§9.4) o con pasivas (§9.2).
    public const string MoveLeft = "move_left";
    public const string MoveRight = "move_right";
    public const string MoveUp = "move_up";
    public const string MoveDown = "move_down";
    public const string Attack = "attack";
    public const string Dash = "dash";

    // §3.7 "Deadzone en stick CONFIGURABLE. Los sticks analogos muertos son la
    // causa numero uno de 'el juego va raro'."
    private const float LeftStickDeadzone = 0.20f;
    private const float RightStickDeadzone = 0.25f;

    public override void _Ready()
    {
        // Mover: teclado completo (§3.7 "sin rebind obligatorio en v1").
        Ensure(MoveLeft,   Key.A, Key.Left);
        Ensure(MoveRight,  Key.D, Key.Right);
        Ensure(MoveUp,    Key.W, Key.Up);
        Ensure(MoveDown,  Key.S, Key.Down);

        // ATACAR: Espacio / J / Z.
        Ensure(Attack, Key.Space, Key.J, Key.Z);

        // DASH: Shift / K / X.
        Ensure(Dash, Key.Shift, Key.K, Key.X);

        AddJoypadButton(Attack, JoyButton.A);
        AddJoypadButton(Dash, JoyButton.B);
        AddJoypadButton(Dash, JoyButton.RightShoulder);

        AddJoypadAxis(MoveLeft,   JoyAxis.LeftX, -1f);
        AddJoypadAxis(MoveRight,  JoyAxis.LeftX, +1f);
        AddJoypadAxis(MoveUp,    JoyAxis.LeftY, -1f);
        AddJoypadAxis(MoveDown,  JoyAxis.LeftY, +1f);

        InputMap.ActionSetDeadzone(MoveLeft, LeftStickDeadzone);
        InputMap.ActionSetDeadzone(MoveRight, LeftStickDeadzone);
        InputMap.ActionSetDeadzone(MoveUp, LeftStickDeadzone);
        InputMap.ActionSetDeadzone(MoveDown, LeftStickDeadzone);
        InputMap.ActionSetDeadzone(Attack, RightStickDeadzone);
        InputMap.ActionSetDeadzone(Dash, RightStickDeadzone);
    }

    private static void Ensure(string action, params Key[] keys)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        foreach (Key key in keys)
        {
            var ev = new InputEventKey { PhysicalKeycode = key };
            InputMap.ActionAddEvent(action, ev);
        }
    }

    private static void AddJoypadButton(string action, JoyButton button)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        InputMap.ActionAddEvent(action, new InputEventJoypadButton { ButtonIndex = button });
    }

    /// <summary>
    /// Eje con signo: axisValue * axis +1 en el positivo, -1 en el negativo.
    /// Asi el mismo eje alimenta Left y Right sin que se cancelen entre si.
    /// </summary>
    private static void AddJoypadAxis(string action, JoyAxis axis, float sign)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        InputMap.ActionAddEvent(action, new InputEventJoypadMotion
        {
            Axis = axis,
            AxisValue = sign,
        });
    }
}
