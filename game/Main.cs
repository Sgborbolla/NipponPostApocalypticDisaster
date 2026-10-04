// ============================================================================
//  Main.cs - Arena de pruebas del Hito 0 (§15).
//
//  §15: "El hito 0 esta a medias. Si el dash no se siente bien, no seguir."
//
//  Esta arena existe para responder a una sola pregunta con las manos en el
//  teclado: ¿el dash recorre lo justo, cuesta lo justo y recobra lo justo?
//
//  No es un nivel. Es un banco de pruebas construido a partir de §4.1.3:
//  "la barra de carga es tambien la unica forma rapida de subir. Barra llena =
//  climb rapido. Barra seca = subir a paso de caminante."
//
//  Por eso hay DOS caminos deliberados:
//    - La rampa: se sube andando, siempre, sin importar la barra.
//    - Las repisas: solo se suben con dash.
//
//  Si solo hubiera repisas, el jugador con la barra seca quedaria atrapado y
//  estariamos midiendo el muro, no el dash. §4.1.4 llama a ese "el fallo real
//  de este diseño".
// ============================================================================

using Godot;
using NPAD.Game.Core;
// FIX (compilacion real, 2026-10-04): dentro del namespace NPAD.Game, "Player"
// resuelve al sub-namespace NPAD.Game.Player ANTES que a cualquier using alias
// (regla de resolucion C# 7.9: miembros del namespace contenedor ganan a los
// using). Por eso los tipos del jugador se importan CON NOMBRE COMPLETO aqui,
// sin aliases. La alternativa era renombrar el namespace, y §AGENTS.1 dice de
// no reescribir estructura existente sin motivo declarado.

namespace NPAD.Game;

public partial class Main : Node2D
{
    // Geometria de la arena. Nada de esto es canonico del juego: son las
    // magnitudes minimas para que el dash se pueda medir.
    private const int ShaftWidth = 720;
    private const int FloorTop = 2496;
    private const int ShaftBottom = 2560;

    // §4.1.3, el corolario del tower-dash. 220 px de subida entre repisas:
    // al alcance de un dash de 250 px, pero NO subiendo andando. Asi la
    // diferencia entre "subir" y "subir rapido" es exactamente la barra.
    private const float LedgeRise = 220f;

    private static readonly Color BgColor = new("0d0a12");
    private static readonly Color LedgeFill = new("2c2536");
    private static readonly Color LedgeEdge = new("4a4056");
    private static readonly Color RampFill = new("241e2e");
    private static readonly Color AccentRevive = new("9afaf2");
    private static readonly Color AccentAlert = new("ffc400");
    private static readonly Color TextColor = new("b9b4c2");

    private Label _chargesLabel = null!;
    private Label _hintLabel = null!;

    public override void _Ready()
    {
        BuildBackdrop();
        BuildShaft();
        BuildLedges();
        BuildRamp();

        var player = new NPAD.Game.Player.Player
        {
            Position = new Vector2(ShaftWidth * 0.5f, FloorTop - 24f),
        };
        AddChild(player);

        AddChild(new FollowCamera { Target = player });

        BuildHud();
    }

    // ------------------------------------------------------------------ ESCENA

    private void BuildBackdrop()
    {
        var bg = new ColorRect
        {
            Color = BgColor,
            Position = Vector2.Zero,
            Size = new Vector2(ShaftWidth, ShaftBottom),
        };
        // El fondo es PARTE DEL MUNDO, no una capa de pantalla: §4.1.1
        // dice que si el jugador se para, la pantalla se para con el.
        AddChild(bg);
    }

    private void BuildShaft()
    {
        // Suelo del pozo y muro derecho: dos limites duros para que el jugador
        // no se salga de la arena al testear el dash diagonal.
        AddBox(new Rect2(0, FloorTop, ShaftWidth, ShaftBottom - FloorTop));
        AddBox(new Rect2(ShaftWidth - 48, 0, 48, FloorTop));
    }

    /// <summary>
    /// Repisas en zigzag. El zigzag es deliberado: obliga a alternar direccion
    /// horizontal, que es donde se nota si el dash diagonal (§3.4) esta
    /// normalizado o no. Un dash mal normalizado atraviesa el pozo en diagonal
    /// y el jugador lo descubre enseguida.
    /// </summary>
    private void BuildLedges()
    {
        const int Count = 8;
        for (int i = 0; i < Count; i++)
        {
            float topY = FloorTop - LedgeRise * (i + 1);
            bool leftSide = i % 2 == 0;
            float x = leftSide ? 40f : ShaftWidth - 40f - 260f;

            AddBox(new Rect2(x, topY, 260f, 28f));
        }
    }

    /// <summary>
    /// La mitigacion 2 de §4.1.4: "Paso de caminante sin i-frames. Se puede
    /// subir sin barra, pero se come golpes. Castigo, no bloqueo."
    ///
    /// Se construye como cuña (no como escalera de cajas): sin boton de salto,
    /// una caja vertical es un muro, y el juego tiene que funcionar con rampas.
    /// Angulo de ~40 grados, por debajo del suelo_max de Godot (45 grados).
    /// </summary>
    private void BuildRamp()
    {
        const float BaseY = FloorTop;
        var body = new StaticBody2D { CollisionLayer = 1 << 1 };
        body.AddChild(new CollisionShape2D
        {
            Shape = new ConvexPolygonShape2D
            {
                Points = new[]
                {
                    new Vector2(0f, BaseY),
                    new Vector2(430f, BaseY),
                    new Vector2(0f, BaseY - 360f),
                },
            },
        });
        AddChild(body);
    }

    // ------------------------------------------------------------- PRIMITIVAS

    private void AddBox(Rect2 r)
    {
        var body = new StaticBody2D
        {
            CollisionLayer = 1 << 1,
            Position = r.Position + r.Size * 0.5f,
        };
        body.AddChild(new CollisionShape2D
        {
            Shape = new RectangleShape2D { Size = r.Size },
        });
        AddChild(body);
    }

    private void BuildHud()
    {
        var layer = new CanvasLayer();
        AddChild(layer);

        _chargesLabel = MakeLabel(28, AccentRevive);
        _chargesLabel.Position = new Vector2(28, 24);
        layer.AddChild(_chargesLabel);

        _hintLabel = MakeLabel(18, TextColor);
        _hintLabel.Position = new Vector2(28, 62);
        // §3.7, a mano: el mapa de controles tiene que estar visible durante
        // las pruebas de feel. Un tester que no encuentra el dash no puede
        // opinar sobre el dash.
        _hintLabel.Text = "WASD/flechas  mover (8 dirs)    Shift/K/X  DASH    Espacio/J/Z  atacar (hito 1)";
        layer.AddChild(_hintLabel);
    }

    private static Label MakeLabel(int size, Color color)
    {
        // FIX (compilacion real): los AddTheme* no son inicializadores de objeto;
        // se llaman despues de construir el Label.
        var label = new Label { Text = string.Empty };
        label.AddThemeFontSizeOverride("font_size", size);
        label.AddThemeColorOverride("font_color", color);
        return label;
    }

    public override void _Process(double delta)
    {
        var player = GetNodeOrNull<NPAD.Game.Player.Player>("Player");
        if (player == null)
        {
            foreach (Node child in GetChildren())
            {
                if (child is NPAD.Game.Player.Player p) { player = p; break; }
            }
        }

        if (player == null || _chargesLabel == null)
        {
            return;
        }

        // §4.1.3: la barra ES la velocidad de ascenso. El HUD tiene que mostrarla
        // con precision decimal, porque un jugador leyendo "1" cuando tiene
        // 1.6 no sabe si puede gastar.
        int full = Mathf.FloorToInt(player.DashCharges);
        float frac = player.DashCharges - full;
        string text = $"DASH  {new string('|', full)}{new string('.', NPAD.Game.Player.PlayerTuning.MaxDashCharges - full)}";
        if (frac > 0.02f)
        {
            text += $"  +{frac:0.00}";
        }

        if (player.IsDashing)
        {
            text += "   i-frames ON";
        }

        _chargesLabel.Text = text;
        _chargesLabel.AddThemeColorOverride(
            "font_color",
            player.DashCharges < 0.01f ? AccentAlert : AccentRevive);
    }
}

/// <summary>
/// Camara que sigue al jugador en vertical. §4.1.1 lo exige de forma literal:
/// "NPAD es vertical: si el jugador se para, la pantalla se para con el. No hay
/// movimiento de fondo que disimule la inaccion."
///
/// Se ancla al EJE VERTICAL de forma dura y al horizontal suave: un hud que
/// se desplaza lateralmente mas de leer que uno que no se desplaza.
/// </summary>
public partial class FollowCamera : Camera2D
{
    public Node2D? Target { get; set; }

    private Vector2 _lookahead;

    public override void _Process(double delta)
    {
        if (Target == null || !IsInstanceValid(Target))
        {
            return;
        }

        float dt = (float)delta;

        // Mirada anticipada hacia arriba: el juego es de ascenso, asi que el
        // jugador necesita ver lo que tiene ENCIMA antes de llegar.
        _lookahead = _lookahead.Lerp(new Vector2(0f, -90f), 1f - Mathf.Exp(-4f * dt));

        // FIX (compilacion real): Godot.Mathf no expone Expm1; se usa la funcion
        // canonica de suavizado frame-independent de Godot: exp(-k*dt).
        Vector2 wanted = Target.Position + _lookahead;
        Position = new Vector2(
            Position.X,
            Mathf.Lerp(Position.Y, wanted.Y, 1f - Mathf.Exp(-18f * dt)));
    }
}
