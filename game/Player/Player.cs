// ============================================================================
//  Player.cs - Hito 0 (§15): rectangulo en pantalla, mover + dash + i-frames.
//
//  §15 lo dice sin rodeos: "el hito 0 esta a medias. Si el dash no se siente
//  bien, no seguir." Y §3.2 avisa de lo mismo: "Iterar este numero hasta que
//  el jugador note el cambio de ritmo."
//
//  ESTE ARCHIVO ES LA VERDAD DEL DASH. Si algo del feel esta mal, se cambia
//  aqui o en PlayerTuning.cs, nunca en un objeto que lo llame.
// ============================================================================

using Godot;
using NPAD.Game.Core;

namespace NPAD.Game.Player;

public partial class Player : CharacterBody2D
{
    // Capas de colision. Se nombran aqui porque el dash atraviesa enemigos
    // (§3.2 "Colision durante el dash: el jugador ATRAVIESA enemigos. Fasear
    // horda"), y eso solo es posible si enemigos yScenario son capas distintas.
    private const int LayerWorld = 1;   // bit 1: paredes y repisas
    private const int LayerEnemy = 3;   // bit 3: enemigos

    // --- Estado de dash (§3.2) ------------------------------------------------
    private float _dashCharges;
    private float _dashTimer;
    private float _dashRecoveryTimer;
    private Vector2 _dashDirection = Vector2.Right;

    // §3.8 "Dash dirigido: sin entrada, hace dash en la ultima direccion."
    private Vector2 _lastMoveDirection = Vector2.Right;

    private bool _facingRight = true;

    // §7.1: paleta desaturada, saturado reservado al peligro. El jugador es
    // gris frio; el blanco saturado es su i-frame, no una decoracion.
    private static readonly Color BodyColor = new("b9b4c2");
    private static readonly Color OutlineColor = new("16121c");
    private static readonly Color InvulnerableColor = new("f2f6ff");

    // --- Consultas publicas ---------------------------------------------------

    public bool IsDashing => _dashTimer > 0f;

    /// <summary>
    /// Los i-frames duran exactamente lo que el dash (§3.2: 0.18 s de ventana
    /// total) y nada mas. Al acabar el dash empieza la recuperacion de 0.12 s,
    /// que §3.2 marca como VULNERABLE: ese es el coste real, no la cooldown.
    /// </summary>
    public bool IsInvulnerable => _dashTimer > 0f;

    public bool IsVulnerable => !IsInvulnerable;

    public float DashCharges => _dashCharges;

    /// <summary>
    /// §3.2 "Regla de oro - las bajas recargan dash". Lo invocan los enemigos
    /// a traves de GameEvents; vive aqui para que el valor siga siendo uno solo.
    /// </summary>
    public void AddDashCharge(float amount)
    {
        _dashCharges = Mathf.Min(PlayerTuning.MaxDashCharges, _dashCharges + amount);
    }

    public override void _Ready()
    {
        CollisionLayer = 1 << 1;                      // bit 2: jugador
        CollisionMask = (1 << LayerWorld) | (1 << LayerEnemy);

        var shape = new RectangleShape2D
        {
            // §13: sprites de 48x48 de origen, 24 px de alto en pantalla.
            Size = new Vector2(16f, PlayerTuning.PlayerOnScreenHeight),
        };
        AddChild(new CollisionShape2D { Shape = shape });

        _dashCharges = PlayerTuning.MaxDashCharges;
    }

    public override void _PhysicsProcess(double delta)
    {
        float dt = (float)delta;

        Vector2 raw = Input.GetVector(
            InputActions.MoveLeft, InputActions.MoveRight,
            InputActions.MoveUp, InputActions.MoveDown);
        Vector2 input = SnapTo8Directions(raw);

        if (input != Vector2.Zero)
        {
            _lastMoveDirection = input;
            _facingRight = input.X > 0f;
        }

        AdvanceDashState(dt);

        // §3.8 "Prioridad de dash sobre ataque: si llegan juntos, gana el dash."
        // Se comprueba el dash antes de cualquier otra cosa, y §3.8 "Cancelacion
        // cruzada: cualquier estado -> dash" hace que no haya estado que lo
        // bloquee. Por eso esto va sin condicion de estado.
        if (Input.IsActionJustPressed(InputActions.Dash) && CanDash())
        {
            StartDash(input);
        }

        if (_dashTimer > 0f)
        {
            Velocity = _dashDirection * PlayerTuning.DashSpeed;
        }
        else
        {
            // §3.4 "Aceleracion: ninguna." Digital y seco. Sin inercia, porque
            // la inercia pelea contra el dash: si el jugador tarda en frenar,
            // encadenar dash-attack se siente pegajoso.
            Velocity = input * PlayerTuning.WalkSpeed;
        }

        MoveAndSlide();
        UpdateEnemyPassThrough();
        QueueRedraw();
    }

    // -------------------------------------------------------------- DASH (§3.2)

    private bool CanDash()
    {
        return _dashCharges >= 1f
            && _dashTimer <= 0f
            && _dashRecoveryTimer <= 0f;
    }

    private void StartDash(Vector2 input)
    {
        // §3.8 "Dash dirigido: sin entrada, hace dash en la ultima direccion."
        Vector2 dir = input != Vector2.Zero ? input : _lastMoveDirection;

        // §3.4 "Dash diagonal: distancia normalizada. V2 ~ 1.41 haria del
        // diagonal una estrategia dominante." Sin esto, elegir diagonal seria
        // siempre la mejor opcion y la eleccion de direccion dejaria de existir.
        if (PlayerTuning.NormalizeDashDiagonal)
        {
            dir = dir.Normalized();
        }

        _dashDirection = dir;
        _dashCharges -= 1f;
        _dashTimer = PlayerTuning.DashDuration;

        // §3.2 "El dash cancela la recuperacion del ataque." El ataque no
        // existe todavia (hito 0), pero la regla se cumple por construccion:
        // no hay ningun estado de ataque que pueda retener al dash.
        GameEvents.EmitDash(DashKind.Normal);
    }

    private void AdvanceDashState(float dt)
    {
        if (_dashRecoveryTimer > 0f)
        {
            _dashRecoveryTimer -= dt;
        }

        if (_dashTimer > 0f)
        {
            _dashTimer -= dt;
            if (_dashTimer <= 0f)
            {
                _dashTimer = 0f;
                // §3.2 "Recuperacion post-dash: 0.12 s - VULNERABLE."
                _dashRecoveryTimer = PlayerTuning.DashRecovery;
                GameEvents.EmitDashEnd();
            }
        }

        // §3.2 "Se regeneran pasivamente". Sin condicion: el documento no la
        // impone. Regenerar tambien durante la recuperacion mantiene la
        // recuperacion como coste de RITMO, no como un castigo de recursos.
        if (_dashCharges < PlayerTuning.MaxDashCharges)
        {
            _dashCharges = Mathf.Min(
                PlayerTuning.MaxDashCharges,
                _dashCharges + PlayerTuning.PassiveRegenPerSecond * dt);
        }
    }

    /// <summary>
    /// §3.2 "Colision durante el dash: el jugador ATRAVIESA enemigos."
    ///
    /// Se hace quitando la capa de enemigos de la mascara SOLO durante el dash.
    /// El mundo (paredes, repisas) sigue bloqueando: atravesar una pared
    /// rompe la lectura del nivel, atravesar una horda es la tactica.
    /// </summary>
    private void UpdateEnemyPassThrough()
    {
        bool collideWithEnemies = !IsDashing;
        if (collideWithEnemies != GetCollisionMaskValue(LayerEnemy))
        {
            SetCollisionMaskValue(LayerEnemy, collideWithEnemies);
        }
    }

    // ------------------------------------------------------------- DIRECCIONES

    /// <summary>
    /// §3.4 "Direcciones: 8, digital." Cuantiza el vector al angulo multiple
    /// de 45 grados mas cercano. Sin esto, un mando analogo devuelve vectores
    /// intermedios y el jugador sentiria el movimiento como impreciso aunque
    /// el codigo sea correcto.
    /// </summary>
    private static Vector2 SnapTo8Directions(Vector2 v)
    {
        if (v.LengthSquared() < 0.0001f)
        {
            return Vector2.Zero;
        }

        const float Step = Mathf.Pi / 4f;
        float angle = Mathf.Round(v.Angle() / Step) * Step;
        return Vector2.FromAngle(angle);
    }

    // ---------------------------------------------------------------- DIBUJO

    public override void _Draw()
    {
        float h = PlayerTuning.PlayerOnScreenHeight;
        var size = new Vector2(h * 0.6f, h);
        var origin = size * 0.5f;

        // §3.4 "Indicador de frente OBLIGATORIO en el sprite." El rectangulo
        // es un hito 0, pero el indicador de frente ya tiene que estar porque
        // §6 exige que cada muerte sea legible y la orientacion es parte de eso.
        var facing = _facingRight ? new Vector2(size.X * 0.5f + 3f, 0f)
                                  : new Vector2(-size.X * 0.5f - 3f, 0f);

        DrawRect(new Rect2(-origin, size), OutlineColor, true);

        // Los i-frames se MUESTREN. Un dash invisible para el jugador es un
        // dash que parece que no funciona.
        Color body = IsInvulnerable ? InvulnerableColor : BodyColor;
        var inner = new Rect2(-origin + new Vector2(2f, 2f), size - new Vector2(4f, 4f));
        DrawRect(inner, body, true);
        DrawCircle(facing, 3f, OutlineColor);

        // Recuperacion vulnerable: el jugador tiene que VER que esta expuesto.
        // §6.4 "Ninguna muerte gratuita."
        if (_dashRecoveryTimer > 0f)
        {
            float t = _dashRecoveryTimer / Mathf.Max(0.001f, PlayerTuning.DashRecovery);
            float width = (size.X - 4f) * t;
            var barY = -origin.Y - 6f;
            DrawRect(new Rect2(-origin.X + 2f, barY, width, 2f), OutlineColor, true);
        }
    }
}
