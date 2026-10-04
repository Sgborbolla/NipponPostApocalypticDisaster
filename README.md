# NPAD Prototype

Prototipo mínimo de un action roguelite con dos botones: ataque y dash.

## Controles
- Mover: WASD o flechas
- Atacar: Espacio
- Dash: Shift
- Empezar: Enter

## Objetivo
- Matar enemigos para llenar la oleada
- Sobrevivir el mayor tiempo posible
- Probar la sensación de ataque + dash

## Estructura
- `index.html`: entrada del juego
- `style.css`: estilo general
- `game.js`: lógica del juego

## Cómo ejecutar
Abre `index.html` en un navegador.

O en una terminal:

```bash
cd C:\NPAD_Prototype
python -m http.server 8000
```

Y luego abre:

```text
http://localhost:8000
```

---

## Documentación

- **`AGENTS.md`** — estado del proyecto, decisiones cerradas, y pasos para arrancar en PC.
  Leerlo primero si vienes de nuevo.
- **`docs/diseño.md`** — fuente de verdad del diseño (2080 líneas). Empieza aquí.
- `index.html` / `game.js` / `style.css` — prototipo web temporal del Hito 0.
  Según `docs/diseño.md` (sección 15) **no se conserva**: sirve solo para responder
  "¿se siente bien el dash?". El juego real es Godot 4 + C#.
