// ============================================================================
//  TimeService.cs - El UNICO punto que decide la escala del tiempo.
//
//  §13: "El time-scale va en un unico servicio, no repartido por el sistema de
//  combate. Un unico punto que decide la escala del frame. Si cada sistema
//  puede pedir camara lenta, se desincronizan y el juego se siente roto."
//
//  §11.1 es el conflicto central del diseno: el jugador pidio slow-motion en
//  CADA golpe y eso convertiria un nivel de 40 bajas en un carrusel. La
//  respuesta es §11.3: la escala la decide la RACHA, no el impacto.
//
//  Nada fuera de este archivo debe escribir Engine.TimeScale.
// ============================================================================

using Godot;

namespace NPAD.Game.Core;

public partial class TimeService : Node
{
    // §11.3, tabla de escala de impacto. "Racha" = bajas encadenadas.
    private const float ScaleRacha0_9 = 1.00f;
    private const float ScaleRacha10_19 = 0.55f;
    private const float ScaleRacha20_39 = 0.40f;
    private const float ScaleRacha40_69 = 0.25f;
    private const float ScaleRacha70Plus = 0.15f;

    // §11.2 "Decae si dejas de matar durante 2.5 s".
    private const float StreakDecaySeconds = 2.5f;

    private float _staleTimer;
    private int _streak;
    private float _scaleTimer;
    private float _targetScale = 1.0f;

    // --- Estado del efecto manual de §18.1 (hitstop / slowmo explicito) ---
    // Vive aqui, y no en un segundo servicio, porque §13 exige que la escala
    // del frame se decida en UN punto. Dos servicios escribiendo
    // Engine.TimeScale es exactamente el fallo que §13 describe.
    private float _defaultTimeScale = 1.0f;
    private float _duration;
    private float _elapsed;
    private bool _isEffectActive;

    /// <summary>
    /// Peticiones de camara lenta pendientes. §11.3 define duraciones por
    /// escalon; el hito 0 no las dispara todavia (no hay impacto todavia),
    /// pero el servicio existe desde el principio para que anadirlo despues no
    /// obligue a rediseñar nada.
    /// </summary>
    public int Streak => _streak;

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Always;
        GameEvents.OnKill += HandleKill;
    }

    public override void _ExitTree()
    {
        GameEvents.OnKill -= HandleKill;
        ResetTimeScale();
    }

    /// <summary>
    /// §18.1, punto 3: "asegurar SetTimeScale(float scale, float duration)
    /// (unico punto para hitstop). Prohibido usar Engine.TimeScale fuera."
    ///
    /// Hitstop y slowmo EXPLICITOS (un golpe concreto, un dash, una muerte de
    /// jefe) entran por aqui. La racha de §11.3 NO pasa por aqui: la decide el
    /// servicio solo, porque §11.3 quiere que el tiempo se ralentice al SUBIR la
    /// racha y nunca por impacto. Una peticion manual puede pisar la racha
    /// durante su duracion; al expirar, la racha se reevalua.
    /// </summary>
    public void SetTimeScale(float scale, float duration)
    {
        _duration = duration;
        _elapsed = 0f;
        _isEffectActive = true;
        _targetScale = scale;
        _scaleTimer = duration;
    }

    /// <summary>
    /// Devuelve el reloj a 1.0 y cancela tanto el efecto manual como la racha.
    /// Se llama al cambiar de run, y en _ExitTree.
    /// </summary>
    public void ResetTimeScale()
    {
        _isEffectActive = false;
        _streak = 0;
        _staleTimer = 0f;
        _targetScale = _defaultTimeScale;
        _scaleTimer = 0f;
    }

    public override void _Process(double delta)
    {
        float dt = (float)delta;

        if (_staleTimer > 0f)
        {
            _staleTimer -= dt;
            if (_staleTimer <= 0f && _streak > 0)
            {
                _streak = 0;
            }
        }

        // §18.1: el efecto manual (hitstop/slowmo) manda sobre la racha mientras
        // dure. Al expirar, el servicio vuelve a derivar de la racha, que es el
        // unico estado que sobrevive entre peticiones.
        if (_isEffectActive)
        {
            _elapsed += dt;
            if (_elapsed >= _duration)
            {
                _isEffectActive = false;
                _targetScale = ScaleForStreak(_streak);
                _scaleTimer = 0f;
            }
        }
        else if (_scaleTimer > 0f)
        {
            _scaleTimer -= dt;
            if (_scaleTimer <= 0f)
            {
                _targetScale = ScaleForStreak(_streak);
            }
        }

        // Un unico punto que decide. Todo el mundo lee de aqui.
        Engine.TimeScale = _targetScale;
    }

    private void HandleKill()
    {
        _streak++;
        _staleTimer = StreakDecaySeconds;
        ApplyStreakScale(_streak);
    }

    /// <summary>
    /// §11.3. El tiempo se ralentiza al SUBIR la racha, nunca por impacto.
    /// Es lo que convierte el efecto en una recompensa y no en un ruido.
    /// </summary>
    private void ApplyStreakScale(int streak)
    {
        // §11.3 da tambien una duracion por escalon. El hito 0 no la usa
        // todavia; se deja el hook listo.
        _targetScale = ScaleForStreak(streak);
        _scaleTimer = 0f;
    }

    /// <summary>
    /// La tabla de §11.3, en un solo sitio. La comparten la racha y la
    /// expiracion de un efecto manual de §18.1: cuando un hitstop termina, el
    /// reloj tiene que volver al valor que le corresponde a la racha actual, no
    /// a 1.0, o el efecto se comeria la recompensa.
    /// </summary>
    private static float ScaleForStreak(int streak)
    {
        return streak switch
        {
            >= 70 => ScaleRacha70Plus,
            >= 40 => ScaleRacha40_69,
            >= 20 => ScaleRacha20_39,
            >= 10 => ScaleRacha10_19,
            _ => ScaleRacha0_9,
        };
    }
}