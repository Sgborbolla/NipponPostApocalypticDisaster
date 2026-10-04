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
        Engine.TimeScale = 1.0f;
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

        if (_scaleTimer > 0f)
        {
            _scaleTimer -= dt;
            if (_scaleTimer <= 0f)
            {
                _targetScale = 1.0f;
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
        float scale = streak switch
        {
            >= 70 => ScaleRacha70Plus,
            >= 40 => ScaleRacha40_69,
            >= 20 => ScaleRacha20_39,
            >= 10 => ScaleRacha10_19,
            _ => ScaleRacha0_9,
        };

        // §11.3 da tambien una duracion por escalon. El hito 0 no la usa
        // todavia; se deja el hook listo.
        _targetScale = scale;
        _scaleTimer = 0f;
    }
}