// ============================================================================
//  PlayerTuning.cs - TODOS los numeros del jugador en un solo sitio.
//
//  Cada valor cites la seccion del documento de diseno que lo fija. Los que
//  el documento NO fija estan marcados como TUNABLE y hay que iterarlos:
//  son justamente los que deciden si el dash "se siente bien" (parrafo 15).
//
//  Si toca reequilibrar, se toca aqui. No hay numeros magicos en Player.cs.
// ============================================================================

namespace NPAD.Game.Player;

public static class PlayerTuning
{
    // ---------------------------------------------------------------- MOVIMIENTO
    // §3.4: "Libre en las 8 direcciones. Los niveles son verticales. Sin boton
    // de salto: el dash es el salto." Y "Aceleracion: ninguna".

    /// <summary>
    /// Velocidad de caminar en px/s.
    /// TUNABLE: el documento NO la especifica. Razon de partida: el dash son
    /// 1389 px/s, unas 6x esta cifra. Si al jugar el dash no se siente como un
    /// recurso escaso, la relacion entre ambos es lo que hay que mover.
    /// </summary>
    public const float WalkSpeed = 240f;

    /// <summary>
    /// §3.4 "Dash diagonal: distancia normalizada".
    /// Sin esto, el diagonal recorria raiz(2) ~= 1.41x la distancia y pasaria
    /// a ser la direccion dominante. La normalizacion convierte elegir
    /// direccion en una decision de coste real.
    /// </summary>
    public const bool NormalizeDashDiagonal = true;

    // -------------------------------------------------------------------- DASH
    // §3.2 tabla de especificacion. Estos si estan en el documento.

    /// <summary>§3.2 "Duracion de i-frames: 0.18 s - Ventana total".</summary>
    public const float DashDuration = 0.18f;

    /// <summary>
    /// §3.2 "Recuperacion post-dash: 0.12 s - VULNERABLE. El coste real".
    /// Los i-frames duran exactamente lo que el dash: fuera de aqui, el
    /// jugador esta expuesto.
    /// </summary>
    public const float DashRecovery = 0.12f;

    /// <summary>§3.2 "Cargas: 2".</summary>
    public const int MaxDashCharges = 2;

    /// <summary>
    /// §3.2 "Se regeneran pasivamente". El documento no da la tasa; se toma la
    /// unica cifra del doc que la cuantifica, §4.1.4: "~0.25 cargas/s".
    /// TUNABLE: es el numero que decide si las bajas importan (§3.2, "la
    /// agresividad es literalmente la fuente de recursos").
    /// </summary>
    public const float PassiveRegenPerSecond = 0.25f;

    /// <summary>
    /// Distancia que cubre el dash, en px. TUNABLE: el documento no la da.
    /// Partida: ~1/8 del ancho de los 1920 px de render (§13), para que una
    /// carga atraviese una repisa y dos crucen medio piso (§3.4).
    /// </summary>
    public const float DashDistance = 250f;

    /// <summary>
    /// Velocidad resultante del dash. Se DERIVA de la distancia y la duracion
    /// para que tocar la distancia no rompa en silencio la ventana de i-frames.
    /// 250 px / 0.18 s ~= 1389 px/s.
    /// </summary>
    public static float DashSpeed => DashDistance / DashDuration;

    // ------------------------------------------------------- RECARGA POR BAJAS
    // §3.2 "Regla de oro - las bajas recargan dash". Bloque literal del doc.

    /// <summary>§3.2 "Dash golpea enemigo -> +0.5 carga".</summary>
    public const float ChargePerDashHit = 0.5f;

    /// <summary>§3.2 "Dash-ataque -> +1.0 carga".</summary>
    public const float ChargePerDashAttack = 1.0f;

    /// <summary>§3.2 "Baja normal -> +0.15 carga".</summary>
    public const float ChargePerKill = 0.15f;

    // ------------------------------------------------------------- ATAQUE (§3.5)
    // El hito 0 no implementa ataque (§15: "rectangulo en pantalla, mover +
    // dash + i-frames"). El buffer se deja declarado porque §3.8 lo exige y
    // el hito 1 lo necesita; no se usa todavia.

    /// <summary>§3.8 "Buffer de 6 frames en el ataque".</summary>
    public const int AttackBufferFrames = 6;

    // -------------------------------------------------------------- PRESENTACION
    // §13: sprites de 48x48 de origen, 24 px de alto en pantalla.
    // §3.4: "Indicador de frente OBLIGATORIO en el sprite".

    public const int PlayerSpriteSourceSize = 48;
    public const float PlayerOnScreenHeight = 24f;

    public const int RenderWidth = 1920;   // §13
    public const int RenderHeight = 1080;  // §13
}