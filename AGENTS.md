# AGENTS.md — NPAD

Contexto operativo para agentes de IA (y para quien siga trabajando aquí).
Fuente de verdad del proyecto: **`docs/diseño.md`** (2080 líneas). Este archivo solo
recuerda el *estado*, el *entorno* y las *decisiones cerradas*. No sustituye al diseño.

Motor: **Godot 4 (.NET/Mono) + C#**, 2D puro, sin 3D, sin motor físico (§7.0).

---

## 1. PRIMERA TAREA al abrir este repo en un PC

El proyecto **aún no tiene `project.godot` ni `.csproj`** — por eso nunca se ha
compilado. Si estás en el PC, haz esto antes de tocar código:

1. Descargar **Godot 4.x versión .NET** (la que dice *Mono*, NO la estándar):
   <https://godotengine.org/download/> — comprobar la versión vigente en la web,
   no asumirla.
2. Descomprimir en `C:\Godot\`.
3. Generar los ficheros importados de Godot (una vez):
   ```powershell
   Godot_v4.x-stable_mono_win64.exe --headless --import
   ```
4. Crear `project.godot` con `[dotnet] project/assembly_name="NPAD"`.
5. Crear `NPAD.csproj` usando el SDK `Godot.NET.Sdk/4.x` (verificar la versión
   estable en <https://api.nuget.org/v3-flatcontainer/godot.net.sdk/index.json>).
6. **Compilar y reportar los errores reales:**
   ```powershell
   dotnet build
   ```
7. Abrir el editor, cargar la escena de prueba y **hacer una captura** para
   comprobar el resultado visualmente.

> **Por qué el paso 7 importa:** el prototipo HTML anterior (`index.html`,
> `game.js`) quedó feo porque se escribió sin ninguna referencia visual que
> revisar. La sesión de PC es la primera vez que se puede *ver* el resultado.
> Ejecutar → capturar → mirar → corregir es el bucle que faltaba.

### Antes de escribir features: cumple el Hito 0

`docs/diseño.md` §15 y §13 marcan el Hito 0 así:

- Formas planas, **sin assets**, 960×540.
- Objetivo único: **«¿se siente bien el dash?»**
- Si el dash no convence, no seguir. Los assets se hacen en el **Hito 2**.

No producir sprites, música ni ambientes antes de validar esto.

---

## 2. Hardware del PC del usuario

Windows 10 · Intel i5 · ~6–8 GB RAM · **GPU probablemente integrada (sin NVIDIA)**.

| Tarea | Posible |
|---|---|
| Godot 4, `dotnet build`, ejecutar, capturas | Sí |
| Krita / Aseprite / ImageMagick / ffmpeg | Sí |
| Descargar SFX/BGM CC0 y medir audio | Sí |
| **Música generada con IA** (YuE/Hunyuan/ACE-Step) | **No** — exige VRAM NVIDIA |
| **VO japonés con CosyVoice** | Muy lento en CPU; Piper corre pero suena robótico |

Para audio generado por IA haría falta servicio en la nube (los tiers gratuitos de
Suno/Udio **no permiten venta comercial**, relevante para Steam) o GPU alquilada.
Esto **no bloquea el Hito 0**.

---

## 3. Restricciones del entorno móvil (Termux/Android)

Esto es lo que pasó cuando la sesión corrió en un móvil Android. No repetir los errores:

- **`ripgrep` está roto**: `unsupported platform for ripgrep: arm64-android`.
  Usar `grep` como alternativa. Varios modelos gratuitos intentarán `rg` primero.
- **No hay Godot ni SDK de Godot .NET**: imposible compilar desde el móvil.
- `dotnet` sí existe (SDK 8.0.131 y 10.0.112) pero no puede compilar el juego.
- `qwen` no está instalado y **no debe instalarse**: su tier gratuito terminó
  (15-abr-2026) y upstream da problemas de `node-pty`/`ripgrep` en Termux.

---

## 4. Decisiones CERRADAS — no re-litigar sin que el usuario las abra explícitamente

1. **`TimeService.cs` ya existía y se preservó.** Su lógica de racha (§11.3:
   knockdown de XP, 3 hits por debajo del umbral en 8 s) **no se toca**.
   Se le *añadieron* `SetTimeScale` / `ResetTimeScale` como pide §18.1.
   Sobrescribirlo era un error; ya está corregido.
2. **`Engine.TimeScale` se escribe en un único sitio**: `game/Core/TimeService.cs`.
   Nunca repartido por el sistema de combate (§11.1, §13).
3. `SaveManager.cs` usa `namespace NPAD.Game.Core;` (coherente con `Palette.cs`).
4. **Reliquias = hooks** (`OnDash`, `OnKill`, `OnDamageDealt`), nunca
   `if (tieneReliquiaX)` disperso (§13).
5. Render **1920×1080**, 60 fps, suelo GTX 960 / 4 GB. **480×270 está descartado**
   explícitamente (§13) — fue un error de la rev. 2.
6. Sprites de personaje: 48×48 de origen, **24 px de alto en pantalla**.
7. Arte: los renders de **Stitch** son la base gráfica canónica, **no siluetas**
   (§7.10). Exportar como spritesheets/atlas ajustando tileado, sin reestilizar.
8. El prólogo de cada personaje ya tiene las líneas JA escritas en §7.8, con sus
   `es`/`en`. Reutilizarlas, no inventar nuevas.
9. Voice-over **solo japonés**, subtítulos ES/EN opcionales. Vídeos **sin audio
   horneado** para poder re-temporizar subtítulos (§7.15, §7.12).
10. SFX y BGM **CC0** (Kenney / Pixabay / Freesound / OpenGameArt) para poder
    vender en Steam sin problemas de licencia.

---

## 5. Pendiente conocido

### 5.1 Contradicción en `docs/npad_tactical_hud_system/DESIGN.md`

La sección de paleta **prohíbe** `#00f0ff`, `#39ff14`, `#bd00ff`, pero el propio
documento los usa. Verificado por script:

- **6 usos reales en prosa**: líneas **199, 221, 228, 232, 239, 244**.
  - 199 `#00F0FF` · 221 `#00F0FF` · 228 `#39FF14` + `#00F0FF`
  - 232 `#00F0FF` · 239 `#39FF14` · 244 `#00F0FF`
  - 221 y 228 contienen **dos** prohibidos cada una → 8 ocurrencias en 6 líneas.
- **Línea 163** es la declaración `PROHIBIDO`, no cuenta.
- **Línea 21** (frontmatter): `primary-container: '#00f0ff'` — fuera de la sección.
- **Línea 203** usa `rgba(0, 240, 255, …)` = mismo cian, pero no es hex.
- **Línea 222** usa `#FF1744`, que **no** está en la lista de prohibidos → no cuenta.

Está pendiente decidir si se limpian los usos o se amplía la lista de prohibidos.
El usuario **no ha dado instrucción** en este punto. Preguntar antes de tocarlo.

### 5.2 Estructura de assets (solo a partir del Hito 2)

```
game/assets/audio/sfx/{dash,hit,parry,damage,death,ruptura,door}.ogg
game/assets/audio/bgm/floor_{1..6}_{a,b}.ogg
game/assets/audio/vo/prologue_{char}_ja.ogg  (+ _sub_es.json, _sub_en.json)
game/data/dialogue.json     (campos en §18.1)
```

Pendiente de escribir: `AudioBank.cs` (carga por nomenclatura) y
`DialogueService.cs` (lee `dialogue.json`). **Se pueden escribir ya** aunque los
assets no existan: no dependen de que haya ficheros de audio.

---

## 6. Reglas de trabajo

- Español en comunicación y en documentación.
- **No reescribir código existente sin motivo declarado.** Si algo parece
  contradictorio, señalar y preguntar; `TimeService` fue justo ese caso.
- **No inventar benchmarks ni datos.** Si no se ha medido, decirlo.
- **No prometer el juego completo.** Es un proyecto de meses: 30 ambientes
  (6 pisos × 5 fases), 6 jefes + 6 subjefes, 4 personajes con Ruptura única,
  cinemáticas y VO japonés. Un agente entrega sistemas; el *feel* lo juzga el
  usuario jugando.
- Verificar antes de afirmar: compilar, contar líneas, ejecutar scripts. Un análisis
  estático (contar llaves) **no es** una compilación.
- Cuando algo se mida, registrar el método para que sea repetible.

---

## 7. Historia reciente relevante

- `e4cfeb3` — paleta HUD corregida, docs reubicados, `SaveManager`/`TimeService`.
- `fd0ee93` — documentos de diseño movidos a `docs/`.
- Ambos pusheados a `main`; árbol limpio.

Prueba de razonamiento sobre modelos gratuitos (tarea: contar usos prohibidos en
`DESIGN.md`): `muse-spark-1.3-contributor` y `space-bunny-free` acertaron las
6 líneas; `nemotron-3-ultra-free` **inventó la línea 229** y falló por una. Nota
metodológica: el «ground truth» inicial estaba mal (incluía `#ff1744`/`#ffb800`,
que no están prohibidos) y se corrigió antes de puntuar.