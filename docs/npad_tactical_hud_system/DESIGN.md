---
name: NPAD Tactical HUD System
colors:
  surface: '#101319'
  surface-dim: '#101319'
  surface-bright: '#36393f'
  surface-container-lowest: '#0b0e13'
  surface-container-low: '#191c21'
  surface-container: '#1d2025'
  surface-container-high: '#272a30'
  surface-container-highest: '#32353b'
  on-surface: '#e1e2ea'
  on-surface-variant: '#b9cacb'
  inverse-surface: '#e1e2ea'
  inverse-on-surface: '#2d3036'
  outline: '#849495'
  outline-variant: '#3b494b'
  surface-tint: '#00dbe9'
  primary: '#dbfcff'
  on-primary: '#00363a'
  primary-container: '#00f0ff'
  on-primary-container: '#006970'
  inverse-primary: '#006970'
  secondary: '#d7ffc5'
  on-secondary: '#053900'
  secondary-container: '#2ff801'
  on-secondary-container: '#0f6d00'
  tertiary: '#fff4e8'
  on-tertiary: '#412d00'
  tertiary-container: '#ffd386'
  on-tertiary-container: '#7d5800'
  error: '#ffb4ab'
  on-error: '#690005'
  error-container: '#93000a'
  on-error-container: '#ffdad6'
  primary-fixed: '#7df4ff'
  primary-fixed-dim: '#00dbe9'
  on-primary-fixed: '#002022'
  on-primary-fixed-variant: '#004f54'
  secondary-fixed: '#79ff5b'
  secondary-fixed-dim: '#2ae500'
  on-secondary-fixed: '#022100'
  on-secondary-fixed-variant: '#095300'
  tertiary-fixed: '#ffdea8'
  tertiary-fixed-dim: '#ffba20'
  on-tertiary-fixed: '#271900'
  on-tertiary-fixed-variant: '#5e4200'
  background: '#101319'
  on-background: '#e1e2ea'
  surface-variant: '#32353b'
typography:
  headline-xl:
    fontFamily: Space Grotesk
    fontSize: 48px
    fontWeight: '700'
    lineHeight: 52px
    letterSpacing: 0.08em
  headline-xl-mobile:
    fontFamily: Space Grotesk
    fontSize: 32px
    fontWeight: '700'
    lineHeight: 36px
    letterSpacing: 0.06em
  headline-lg:
    fontFamily: Space Grotesk
    fontSize: 32px
    fontWeight: '700'
    lineHeight: 38px
    letterSpacing: 0.06em
  headline-lg-mobile:
    fontFamily: Space Grotesk
    fontSize: 24px
    fontWeight: '700'
    lineHeight: 28px
    letterSpacing: 0.05em
  headline-md:
    fontFamily: Space Grotesk
    fontSize: 22px
    fontWeight: '600'
    lineHeight: 28px
    letterSpacing: 0.04em
  headline-sm:
    fontFamily: Space Grotesk
    fontSize: 18px
    fontWeight: '600'
    lineHeight: 24px
    letterSpacing: 0.04em
  body-lg:
    fontFamily: Space Mono
    fontSize: 16px
    fontWeight: '400'
    lineHeight: 26px
    letterSpacing: 0.02em
  body-md:
    fontFamily: Space Mono
    fontSize: 14px
    fontWeight: '400'
    lineHeight: 22px
    letterSpacing: 0.01em
  body-sm:
    fontFamily: Space Mono
    fontSize: 12px
    fontWeight: '400'
    lineHeight: 18px
    letterSpacing: 0.01em
  label-lg:
    fontFamily: JetBrains Mono
    fontSize: 13px
    fontWeight: '700'
    lineHeight: 16px
    letterSpacing: 0.12em
  label-md:
    fontFamily: JetBrains Mono
    fontSize: 11px
    fontWeight: '600'
    lineHeight: 14px
    letterSpacing: 0.14em
  label-sm:
    fontFamily: JetBrains Mono
    fontSize: 9px
    fontWeight: '700'
    lineHeight: 12px
    letterSpacing: 0.18em
spacing:
  gutter: 1rem
  gutter-desktop: 1.5rem
  margin: 1rem
  margin-desktop: 2rem
  space-xs: 0.25rem
  space-sm: 0.5rem
  space-md: 1rem
  space-lg: 1.5rem
  space-xl: 2.5rem
---

## Brand & Style

This design system channels the gritty, dense, cathode-ray terminal aesthetics of late-80s to mid-90s military cyber-anime OVAs and tactical combat simulators. The visual posture is relentless, functional, and paranoid: a field-grade militarized operating system deployed in post-catastrophe Tokyo. 

### Target Atmosphere & Personality
- **Paranoid Military Tech:** Raw computational interfaces built for survival, telemetry, and combat telemetry under electronic warfare conditions.
- **90s Hard Sci-Fi OVA:** Heavy linework, dense metric readouts, scanline artifacts, clipped corners, and warning bands.
- **Sensory Overload & High Lethality:** Piercing phosphor hues set against deep cathode black, evoking radiation detectors, combat cyberware diagnostic logs, and unshielded monitors.

### Aesthetic Direction
A deliberate union of **Industrial Brutalism** and **Tactile Retro-Futurism**. The visual language rejects soft modern minimalism in favor of structured data ribbons, faceted chamfer borders, high-contrast segmented readouts, and monospace terminal feeds.

## Colors

The palette is engineered around luminous CRT phosphors over an ultra-deep charcoal vacuum. Colors indicate system criticality, weapon states, and bio-threat levels.

### Accent Applications
- **Neon Cyan (`#00F0FF`):** Primary UI state, targeted telemetry, system headers, active conduits, and functional controls.
- **Radioactive Green (`#39FF14`):** Secondary bio-vital status, network verification, sensor stability, and nominal readouts.
- **Toxic Amber (`#FFB800`):** Caution states, fuel/radiation metrics, active alerts, and auxiliary system subheads.
- **Bloody Crimson (`#FF1744`):** Critical hull damage, fatal diagnostics, emergency overrides, and armed ordnance warnings.
- **Laser Purple (`#BD00FF`):** Psychic/EMP interference, synthetic intelligence overlays, and cyberware sync channels.

### Neutral & Surface Matrix
- **Cathode Pitch (`#080B10`):** Base terminal canvas; absorbs all non-illuminated pixels.
- **Hard Shell (`#101622`):** Primary panel containment background.
- **Sub-Terminal Surface (`#172033`):** Elevated inner wells, stat gutters, and card containers.
- **Grid Trace Line (`#22324D`):** Low-light boundary wires, inactive graticules, and calibration ticks.
- **Glitch Text Neutral (`#8FA3BF`):** Standard data body, sub-labels, and non-critical metrics.
- **Phosphor White (`#E6F7FF`):** Overdrive highlights, maximized stat values, and focused button text.

## Typography

Typography prioritizes computational legibility, industrial telemetry standards, and aggressive military titling.

### Rules of Usage
- **All-Caps Telemetry:** All `label-*` and `headline-*` elements render strictly in uppercase (`text-transform: uppercase`).
- **Data Densities:** Body copy uses `Space Mono` to preserve tabular column alignment in vertical logs, status reports, and item inventories.
- **Prefix Identifiers:** Micro labels should prepend tactical bracket index tags (e.g., `[SYS.01]`, `//TARGET`, `RAD:0.44mSv`) set in `label-sm`.
- **Text Glow:** Critical headlines and alerts apply an inline CRT phosphor edge glow using a minimal single-pixel horizontal color bleed.

## Layout & Spacing

The layout is governed by a **Modular HUD Grid System** resembling military mission control panels and multi-channel tactical computers.

### Grid & Structure
- **Desktop (12 Columns):** Content panels lock to rigid 12-column layouts separated by visible grid axes, calibration crosshairs (`+`), and corner indexing markers (`L`, `¬`).
- **Tablet (8 Columns):** Tactical cards collapse to dual-column metrics; combat telemetry splits vertically.
- **Mobile (4 Columns):** Panels stack with high-density vertical accordion tabs, preserving critical stat readouts in persistent top/bottom HUD bars.

### Rhythmic Density
Negative space is treated as "inactive sensor spectrum." Spacing is deliberately compressed and structured:
- Margins and gutters remain consistent to maintain alignment with decorative technical rulers.
- Components use dense inner padding (`space-sm` to `space-md`) to emulate military hardware screens packed with maximum operational feedback.

## Elevation & Depth

This system avoids natural shadows or rounded organic blur tiers. Depth is simulated through **cathode layering, frame enclosures, and phosphor intensity**.

### 1. CRT Base Layer & Scanlines
The entire canvas sits behind a subtle repeating horizontal scanline overlay (`repeating-linear-gradient(0deg, rgba(0,0,0,0.4) 0px, rgba(0,0,0,0.4) 1px, transparent 1px, transparent 2px)`) with pointer-events disabled, capped with an edge vignette mimicking curved monitor glass.

### 2. Panel Framing (Bold Chamfer Borders)
Elevated UI segments use 1px to 2px crisp outlines in `#22324D` or `#00F0FF`. Panels gain depth not through drop shadows, but through multi-tier offset containment borders, decorative perimeter screw coordinates, and corner cutouts.

### 3. Phosphor Bloom (Active States)
Selected or firing elements pierce the dark through concentrated, high-saturation glows:
- **Cyan Bloom:** `box-shadow: 0 0 8px rgba(0, 240, 255, 0.45), inset 0 0 6px rgba(0, 240, 255, 0.2)`
- **Crimson Critical:** `box-shadow: 0 0 10px rgba(255, 23, 68, 0.6), inset 0 0 8px rgba(255, 23, 68, 0.25)`

### 4. Recessed Data Wells
Input areas, graph cavities, and character portraits sit recessed within the panel, marked by a darker background (`#080B10`) and a top/left 1px border highlight simulating an indented bezel.

## Shapes

Rounded geometries are strictly banned (`roundedness: 0`). The shape grammar is entirely hard-edged, angled, and faceted.

### Chamfered & Notched Angles
- UI containers, cards, and primary action buttons utilize 45-degree corner notches (clip-paths: `polygon(0 0, calc(100% - 10px) 0, 100% 10px, 100% 100%, 10px 100%, 0 calc(100% - 10px))`).
- Stat blocks, tags, and tabs use angular asymmetric cuts (such as top-right clipped corners) to evoke military flight checklists and physical chassis stampings.
- Separators use broken, segmented dash arrays, diagonal hazard cross-hatching, and tick marks rather than continuous flat lines.

## Components

### Buttons & Tactical Triggers
- **Primary Action (ENGAGE / FIRE):** Sharp, chamfered corner box with a solid `#00F0FF` background and `#080B10` bold monospace text. On hover, inverts to `#080B10` fill with a glowing `#00F0FF` border and cyan neon drop-shadow. Includes an index marker (e.g., `▶ EXEC_01`).
- **Hazard Trigger (PURGE / JETTISON):** Striped black-and-toxic-amber hazard diagonal header, crimson outline (`#FF1744`), flashing red cursor indicator.
- **Secondary / Ghost:** Transparent base, 1px `#22324D` frame, glowing cyan text on hover, flanked by bracket corners (`[ CANCEL ]`).

### Stat Cards & Character Dossiers
- **Structure:** Multi-layered HUD chassis with an angular top bar displaying dossier numbers (e.g., `SEC-77 // UNIT-04`), unit faction insignia, and scanline-treated portrait viewport.
- **Portrait Viewport:** Enclosed in a recessed 1px high-contrast border with CRT scanline flicker, corner crosshairs, and live status badges (`SYNC: 98.2%`, `BIO: CRITICAL`).
- **Data Ribbons:** Monospaced stat keys (`STR`, `AGI`, `CYB`, `RAD_TOL`) paired with segmented 10-bar LED gauges instead of smooth progress bars. Filled segments glow in active phosphor tones (`#39FF14` or `#00F0FF`); unfilled segments sit in `#172033`.

### Input Fields & Terminal Consoles
- **Appearance:** Recessed dark box (`#080B10`) flanked by a 1px border. Left side features a persistent blinking block prompt (`>`).
- **State Feedback:** Focused state turns the border `#00F0FF` with a subtle interior cyan bleed. Placeholder text appears as low-opacity glitch characters.

### Checkboxes, Toggles & Switches
- **Checkboxes:** Square boxes with hard 0px borders. Checked state renders a high-intensity neon `X` or solid inner neon block with crosshair gridlines.
- **Toggle Switches:** Replaced by two-position rocker sliders or stepped rocker segments tagged `[OFF / ON]` or `[DISARMED / HOT]`.

### Data Chips, Status Badges & Hazard Banners
- **Status Chips:** Clipped rectangular badges with monospaced text flanked by status pips. Green `#39FF14` for `CLEAR`, Amber `#FFB800` for `CAUTION: ELEVATED RAD`, Crimson `#FF1744` for `LETHAL THREAT`.
- **System Hazard Banners:** Full-width warning bars adorned with repeated yellow-and-black or crimson-and-black 45-degree diagonal warning striping, framed with technical warning codes (`ERR_CODE_909 // OVERHEAT`).

### Lists & Terminal Logs
- **Log Feeds:** Continuous vertical streams formatted as raw timecoded telemetry (`[03:44:12.89] // RAD_LEVEL SPIKE AT TOKYO-BAY SECTOR 3`).
- **List Items:** Separated by horizontal dotted raster lines, highlighted with an active left neon bar (`border-left: 3px solid #00F0FF`) on hover.