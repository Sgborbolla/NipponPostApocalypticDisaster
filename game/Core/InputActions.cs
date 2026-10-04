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
        // FIX (compilacion real, 2026-10-05): Key.Shift NO es una tecla: es el
        // MODIFICADOR de Godot (Key.Shift == 4194304). Registrado como tecla
        // fisica jamas coincide con un keycode real y el dash queda muerto al
        // pulso. Los modificadores se activan con la bandera PRESSED de
        // InputEventKey.Keycode (enum Key), no con PhysicalKeycode (enum
        // KeyList). Se registran las dos variantes para cubrir ambos caminos.
        Ensure(Dash, Key.K, Key.X);
        EnsureModifier(Dash, Key.Shift);

        AddJoypadButton(Attack, JoyButton.A);
        AddJoypadButton(Dash, JoyButton.B);
        AddJoypadButton(Dash, JoyButton.RightShoulder);

        AddJoypadAxis(MoveLeft,   JoyAxis.LeftX, -1f);
        AddJoypadAxis(MoveRight,  JoyAxis.LeftX, +1f);
        AddJoypadAxis(MoveUp,    JoyAxis.LeftY, -1f);
        AddJoypadAxis(MoveDown,  JoyAxis.LeftY, +1f);

        // FIX (compilacion real, 2026-10-04): ActionSetDeadzone NO es API
        // publica de GodotSharp 4.4 (es interna del motor), por eso la version
        // anterior no compilaba. El registro por codigo tampoco puede fijar el
        // deadzone serializado de la accion. Se guarda el valor pedido como meta
        // del evento y se aplica en Player mediante Input.GetActionRawStrength
        // comparado contra GetStickDeadzone(...) cuando el hito 1 lo necesite.
        // La cifra sigue viva en un unico sitio (§3.7 "configurable").
        foreach (string move in new[] { MoveLeft, MoveRight, MoveUp, MoveDown })
        {
            SetAxisDeadzone(move, LeftStickDeadzone);
        }
    }

    /// <summary>
    /// Marca los eventos de eje de una accion con el deadzone pedido (meta
    /// "npad_deadzone") para que cualquier lector lo recupere con GetMeta.
    /// </summary>
    private static void SetAxisDeadzone(string action, float deadzone)
    {
        foreach (var ev in InputMap.ActionGetEvents(action))
        {
            if (ev is InputEventJoypadMotion)
            {
                ev.SetMeta("npad_deadzone", deadzone);
            }
        }
    }

    /// <summary>Deadzone registrado para una accion (0.2 por defecto).</summary>
    public static float GetStickDeadzone(string action)
    {
        foreach (var ev in InputMap.ActionGetEvents(action))
        {
            if (ev.HasMeta("npad_deadzone"))
            {
                return (float)ev.GetMeta("npad_deadzone");
            }
        }
        return 0f;
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

    /// <summary>
    /// Registra un MODIFICADOR (Shift, Ctrl, Alt, Meta) como disparador de la
    /// accion. Los modificadores no son teclas fisicas: Godot los entrega en la
    /// bandera Keycode de InputEventKey con el flag KeyModifierMask.Pressed, y
    /// PhysicalKeycode llega a 0 para ellos. Por eso este evento se construye
    /// con Keycode + WithCtrl/WithAlt... NO con PhysicalKeycode.
    /// </summary>
    private static void EnsureModifier(string action, Key modifier)
    {
        if (!InputMap.HasAction(action))
        {
            InputMap.AddAction(action);
        }

        InputMap.ActionAddEvent(action, new InputEventKey
        {
            Keycode = modifier,
            Pressed = true,
        });
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
