// ============================================================================
//  Palette.cs - LA paleta del juego. Un solo archivo, sin excepciones.
//
//  POR QUE ESTE ARCHIVO EXISTE
//
//  En la carpeta de Stitch hay DOS sistemas de color incompatibles, con CERO
//  hex coincidentes entre ellos:
//
//   A) personajes.md §1 + enemigos.md §6  -> 34 hex, apagados.
//      #1a1420 #2e2838 #4a4258 #7a7290 #c8c0d8 #f4f0ff
//      #ff2d6f (peligro) #ffc400 (alerta) #ff8a3d (suelo) #9afaf2 (revivir)
//
//   B) docs/npad_tactical_hud_system/DESIGN.md -> 50 hex, neon CRT.
//      #00f0ff #39ff14 #ff1744 #ffb800 #bd00ff
//
//  Los mockups HTML de Stitch (npad_in_game_combat_2_button_hud/code.html y
//  los otros 19) usan '#00f0ff' como color de las CARGAS DE DASH. Ese hex no
//  existe en el sistema A.
//
//  LA RESOLUCION ESTA EN EL DOCUMENTO, en §7.1, y es explicita:
//
//    "Decidido en rev. 3. Se conserva el GENERO cyberpunk -el que ya esta
//     explorado en los mockups de assets/stitch_npad_pixel_character_roster (4)-
//     y se cambia la PALETA: nada de neon por todas partes."
//
//  O sea: los mockups de Stitch exploraron el GENERO (CRT, telemetria
//  militar, scanlines, biselado). La rev. 3 mantuvo ese genero y cambio los
//  colores. Por eso:
//
//    - SE COPIA de Stitch: la arquitectura del HUD, las scanlines, la
//      vineta, los clip-path biselados, las barras segmentadas en LED, las
//      mayusculas de telemetria, la rejilla modular, los codigos [IDX].
//    - SE RECHAZA de Stitch: '#00f0ff', '#39ff14', '#ff1744', '#ffb800',
//      '#bd00ff' y todo lo demas saturado que no sea peligro o alerta.
//
//  Este archivo es la lista A. Si alguien cambia un color, se cambia aqui.
//
//  REGLA DURA de §7.1 y personajes.md §1:
//    '#ff2d6f' y '#ffc400' NUNCA se usan en un personaje. Si un enemigo brilla
//    en esos dos colores, el jugador sabe al instante que tiene que moverse.
//    Si el personaje los usara, ese sistema de aviso se rompe.
// ============================================================================

using Godot;

namespace NPAD.Game.Core;

public static class Palette
{
    // ------------------------------------------------- NEUTRALES (personajes.md §1)
    // Todos estos son de saturacion baja. Un jugador debe poder estar mirando
    // el suelo y aun asi ver el rojo de un enemigo en el limite del campo visual.

    /// <summary>Sombra profunda. Contornos de 1 px y fondo de pelo.</summary>
    public static readonly Color ShadowDeep = new("1a1420");

    /// <summary>Oscuro. Ropa secundaria.</summary>
    public static readonly Color Dark = new("2e2838");

    /// <summary>Medio. Ropa principal.</summary>
    public static readonly Color Medium = new("4a4258");

    /// <summary>Claro. Luces de ropa.</summary>
    public static readonly Color Light = new("7a7290");

    /// <summary>Hueso. Blancos y metales claros.</summary>
    public static readonly Color Bone = new("c8c0d8");

    /// <summary>Blanco puro. El unico blanco real del juego.</summary>
    public static readonly Color White = new("f4f0ff");

    // ------------------------------------------- SEMANTICOS (personajes.md §1, §7.1)
    // Los unicos colores saturados de toda la pantalla. Todo lo demas es gris.

    /// <summary>
    /// §7.1 "Peligro (daño, telegrafía, proyectil enemigo) - 100%.
    /// '#ff2d6f', '#ff8a3d'. Unico color saturado en pantalla."
    /// enemigos.md §6: exclusivo de amenaza. Nunca en personajes, nunca en
    /// enemigos que no sean peligrosos.
    /// </summary>
    public static readonly Color Danger = new("ff2d6f");

    /// <summary>
    /// §7.1 "Recompensa (reliquia, heads-up, oro de la Ruptura) - Alta.
    /// '#ffc400'. Solo aparece tras un logro."
    /// Excepcion documentada: Ren lo lleva en la ropa (personajes.md §4.2), y
    /// por eso es "el punto de referencia del elenco". No se usa en ningun otro.
    /// </summary>
    public static readonly Color Alert = new("ffc400");

    /// <summary>
    /// enemigos.md §6: "Zona de daño en el suelo". La Caldera y el Nucleo lo
    /// usan para los charcos (§4.3 jefe 3, §4.6 jefe 6).
    /// </summary>
    public static readonly Color GroundDamage = new("ff8a3d");

    /// <summary>
    /// enemigos.md §6: "Reanimación / Regeneración". El Resucitado brilla en
    /// este color los 2 frames antes de revivir (§1.5). Es el unico enemigo que
    /// usa cian, y solo en ese momento.
    /// </summary>
    public static readonly Color Revive = new("9afaf2");

    // ------------------------------------------------------- ARQUITECTURA (§7.1)
    // "Fondos y arquitectura - Muy baja - Grises, ocres, azul acero. Nunca
    // compiten (§6.3)."
    //
    // §6.3 es regla dura: "el fondo nunca compite en contraste con un enemigo.
    // Si un muro tiene el mismo valor que un enemigo, es un bug de legibilidad."
    // Por eso el fondo es SIEMPRE un valor por debajo del enemigo mas apagado.

    /// <summary>Fondo del mundo. El valor mas oscuro de la pantalla.</summary>
    public static readonly Color WorldBackground = new("0d0a12");

    /// <summary>Estructura del nivel: suelo, muros, repisas.</summary>
    public static readonly Color WorldSolid = new("2c2536");

    /// <summary>Borde superior de la estructura. Da lectura de superficie pisable.</summary>
    public static readonly Color WorldSolidEdge = new("4a4056");

    // --------------------------------------------------------------- JUGADORES
    // §7.1 "Jugables - Baja. Tonos de ropa apagados, una marca de color por
    // personaje." Los cuatro tienen su propia marca (personajes.md §0) y solo
    // se implementan a partir del hito 2.

    /// <summary>El jugador de hito 0 es un rectangulo. Este es su tono base.</summary>
    public static readonly Color PlayerBody = new("b9b4c2");

    /// <summary>
    /// Los i-frames se MUESTRAN (§6.4 "Ninguna muerte gratuita"). Es el blanco
    /// puro del juego, usado para el dash, no una decoracion.
    /// </summary>
    public static readonly Color PlayerInvulnerable = White;

    // -------------------------------------------------------------------- HUD
    // El HUD de Stitch aporta la ESTRUCTURA y la TIPOGRAFIA; los colores salen
    // de la lista de arriba. Ver docs/npad_tactical_hud_system/DESIGN.md.

    /// <summary>Fondo de panel. El "Cathode Pitch" de DESIGN.md, oscurecido.</summary>
    public static readonly Color HudPanel = new("16121c");

    /// <summary>Texto normal del HUD. No es blanco puro: Molestaria en 1920x1080.</summary>
    public static readonly Color HudText = Bone;

    /// <summary>Texto secundario y sub-etiquetas.</summary>
    public static readonly Color HudTextDim = Light;

    /// <summary>Lineas de la rejilla y bordes de panel.</summary>
    public static readonly Color HudGrid = new("3a3348");

    // ---------------------------------------------------------- JUEGO Y TURNO

    /// <summary>Maximo 2 voces simultaneas (§7.4.3), asi que el aviso es breve.</summary>
    public static readonly Color Streak = Danger;

    /// <summary>Escalon de racha alcanzado (§11.3).</summary>
    public static readonly Color StreakTier = Alert;
}
