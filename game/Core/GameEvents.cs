// ============================================================================
//  GameEvents.cs - Los puntos de enganche del motor.
//
//  §13, principio de arquitectura: "las reliquias deben implementarse como
//  hooks en el motor (OnDash, OnKill, OnDamageDealt), nunca como
//  if (tieneReliquiaX) repartidos por el codigo. Si al final hay 40 reliquias,
//  el proyecto sigue legible."
//
//  Regla que hay que mantener: NADA de §9 debe meter un `if` dentro de Player,
//  Enemies o Feel. Si hace falta, se engancha aqui.
// ============================================================================

using System;

namespace NPAD.Game.Core;

/// <summary>
/// Enum del estado del dash, para que los hooks puedan differentiates.
/// §3.2 distingue "dash golpea" de "dash-ataque" y dan recargas distintas.
/// </summary>
public enum DashKind
{
    /// <summary>Dash normal, sin ataque.</summary>
    Normal,

    /// <summary>Dash con ataque: atraviesa Y daña (§3.2), recarga el doble.</summary>
    Attack,
}

public static class GameEvents
{
    // ------------------------------------------------------------------ DASH
    /// <summary>§3.2: el dash se dispara. Cancela la recuperacion del ataque.</summary>
    public static event Action<DashKind>? OnDash;

    /// <summary>§3.2 "Dash golpea enemigo". Recarga +0.5.</summary>
    public static event Action? OnDashHitEnemy;

    /// <summary>Fin de la ventana de i-frames. A partir de aqui se es vulnerable.</summary>
    public static event Action? OnDashEnd;

    // ----------------------------------------------------------------- BAJAS
    /// <summary>§3.2 "Baja normal". Recarga +0.15. Base de §11.2, la racha.</summary>
    public static event Action? OnKill;

    // ------------------------------------------------------------------ DAÑO
    /// <summary>§7.3. Se engancha la camara lenta por racha aqui, no dentro del combate.</summary>
    public static event Action<float>? OnDamageDealt;

    /// <summary>§6.4 "Muerte explicable". El HUD muestra por que se muere.</summary>
    public static event Action<float, string>? OnPlayerDamaged;

    // -------------------------------------------------------------- UTILIDADES
    /// <summary>
    /// Reinicia todos los hooks. Se llama al cambiar de run para que una
    /// reliquia de la run anterior no se quede colgada en la siguiente.
    /// </summary>
    public static void Clear()
    {
        OnDash = null;
        OnDashHitEnemy = null;
        OnDashEnd = null;
        OnKill = null;
        OnDamageDealt = null;
        OnPlayerDamaged = null;
    }

    internal static void EmitDash(DashKind kind) => OnDash?.Invoke(kind);
    internal static void EmitDashHitEnemy() => OnDashHitEnemy?.Invoke();
    internal static void EmitDashEnd() => OnDashEnd?.Invoke();
    internal static void EmitKill() => OnKill?.Invoke();
    internal static void EmitDamageDealt(float amount) => OnDamageDealt?.Invoke(amount);
    internal static void EmitPlayerDamaged(float amount, string source) =>
        OnPlayerDamaged?.Invoke(amount, source);
}