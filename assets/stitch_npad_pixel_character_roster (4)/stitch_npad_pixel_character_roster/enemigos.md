# ENEMIGOS Y JEFES — NPAD

> Documento de construcción visual. Complementa a `DISEÑO.md` §4.2, §6, §10.
> **Objetivo:** definir los 5 arquetipos base, los 6 subjefes y los 6 jefes, con
> la misma ficha de construcción que `PERSONAJES.md` (proporciones, paleta,
> silueta, frames de animación).

---

## 0. La regla que gobierna todo este documento

> **En un juego de matanzas, el enemigo no puede ser un adorno. Es un sistema de
> advertencias.**

Cada enemigo tiene que comunicar tres cosas **sin texto, sin barras de vida y
en 200 ms** (§6.1):

1. **¿Qué es?** — por su silueta
2. **¿Me mata?** — por su color y su telegrafía
3. **¿Dónde va a golpear?** — por la **forma** del aviso (§6.2)

> La regla de oro de la paleta:
> - **`#ff2d6f`** → te va a matar. **Exclusivo de peligro.**
> - **`#ffc400`** → atención, algo bueno o premiable.
> - Los cuatro personajes **no** usan ninguno de los dos (§1 de `PERSONAJES.md`).
> - Ningún enemigo usa los colores de ropa del elenco.

---

## 1. Los 5 arquetipos base

Cada uno **introduce una idea** (§4.2) y todos se ven desde el primer frame.

### 1.1 CARRILERO (nivel 1)

> **Enseña:** el contacto hace daño y el dash tiene cooldown.

| Parámetro | Valor |
|---|---|
| Altura | 26 px |
| Anchura | 12 px |
| Silueta | **Vertical, piernas largas.** Un palo con hombros |
| Colores | `#3a3444` cuerpo, `#ff2d6f` pecho |
| Frames | idle 4, caminar 6, golpe 4, morir 5 |

- **Silueta:** la más simple del juego. Piernas disproportionately largas, sin
  brazos visibles. Se lee como "esto viene hacia mí".
- **Aviso:** no necesita telegrafía. El contacto es el aviso. Su brillo
  `#ff2d6f` hace el resto.
- **Animación:** 4 frames de idle, ciclo lento. Deliberadamente aburrido: es el
  enemigo con el que se aprende.

> **Proporción clave:** 26 px de alto, 12 de ancho. Es **más alto que ancho**
> como el Ren (personaje), pero **no tiene pelo ni ropa**. Contraste de forma,
> no de color.

---

### 1.2 EMBESTIDOR (nivel 2)

> **Enseña:** hay enemigos que no se pueden golpear mientras corren.

| Parámetro | Valor |
|---|---|
| Altura | 22 px |
| Anchura | 22 px (cuadrado) |
| Silueta | **Horizontal.** Se arrastra, no camina |
| Colores | `#4a3040` cuerpo, `#ff2d6f` lomo |
| Frames | idle 4, correr 8, embestida 4, morir 5 |

- **Silueta:** la **opuesta** al Carrilero. Ancha y baja en vez de alta y fina.
  Cuando aparecen los dos en la misma pantalla, se distinguen por proporciones,
  no por color.
- **Aviso:** se pone de pie y brilla `#ff2d6f` **1 frame** antes de embestir.
  Ese frame es todo su telegrafía.
- **Regla de combate:** **inmune mientras corre** (§4.2). El dash lo atraviesa
  sin hacerle daño; hay que golpearlo en el frame de aviso.

> Este es el primer enemigo que **obliga al jugador a leer** en vez de machacar.

---

### 1.3 LANZADOR (nivel 3)

> **Enseña:** el suelo deja de ser seguro.

| Parámetro | Valor |
|---|---|
| Altura | 30 px |
| Anchura | 14 px |
| Silueta | **Arco.** Se arquea sobre sus propias patas |
| Colores | `#5a4a3a` cuerpo, `#ff2d6f` boca |
| Frames | idle 6, cargar 3, disparar 4, morir 5 |

- **Silueta:** un arco-launcher alto, con las patas juntos. La única del juego
  cuya forma es **curva**. Nada más en pantalla se curva.
- **Aviso:** antes de disparar, la boca `#ff2d6f` se abre y queda **2 frames**.
  El proyectil es un círculo `#ff2d6f` con estela blanca.
- **Regla de combate:** dispara a **paradas**, nunca mientras se mueve. Obliga
  al jugador a usar las repisas y a leer el ritmo.

---

### 1.4 BLINDADO (nivel 4)

> **Enseña:** no todos mueren de un golpe.

| Parámetro | Valor |
|---|---|
| Altura | 32 px |
| Anchura | 20 px |
| Silueta | **Rectangular con placa frontal.** Bloque |
| Colores | `#6a6a72` placa, `#2a2434` hueco |
| Frames | idle 6, cargar placa 8, golpe 6, morir 8 |

- **Silueta:** **la más difícil de leer** a propósito. Un bloque. Obligado a
  mirar para ver qué es, que es justo lo contrario de los otros cuatro. El
  jugador tiene que aprenderlo.
- **Aviso:** cuando se le golpea, la placa `#6a6a72` **parpadea a blanco
  1 frame** y suena metal. Comunica "no ha sido suficiente" sin texto.
- **Regla de combate:** la placa frontal **bloquea el daño**. Solo entra por
  detrás. Esto **convierte el juego de lateral a espacial** en un solo
  enemigo: de repente hay que rodear.

> Este es el enemigo que mejor explica la verticalidad (§2.1): rodearlo obliga a
> subir, porque el pasillo es estrecho.

---

### 1.5 RESUCITADO (nivel 5)

> **Enseña:** soltar enemigos tiene castigo.

| Parámetro | Valor |
|---|---|
| Altura | 28 px |
| Anchura | 14 px |
| Silueta | **La del Carrilero, pero rota.** Hombros en escorzo |
| Colores | `#2a3444` cuerpo, `#9afaf2` grietas |
| Frames | idle 4, caminar 6, revivir 10, morir 5 |

- **Silueta:** **copia intencionada** del Carrilero pero con los hombros girados
  45°. Se parece lo justo para ser reconocido como "uno de los que ya mataste".
- **Aviso:** **grietas `#9afaf2`** que brillan antes de revivir. Es el único
  enemigo que usa cian, y solo en este momento. Cuando brilla, sabe que va a
  volver: hay **2 frames** para acabarlo.
- **Regla de combate:** revive una vez si no muere durante la oleada. Castiga
  al jugador que limpia rápido y deja cuerpos (§4.2).

> Este enemigo es una **regla, no un cuerpo**: va contra el instinto natural de
> "si ya está muerto, paso al siguiente". Esa incomodidad es intencionada.

---

## 2. Tabla resumen de arquetipos

| Enemigo | Nivel | Enseña | Altura | Anchura | Silueta | Aviso |
|---|---|---|---|---|---|---|
| Carrilero | 1 | Contacto = daño | 26 | 12 | Palo vertical | El propio contacto |
| Embestidor | 2 | No se pega en carrera | 22 | 22 | Cuadrado horizontal | 1 frame de pie |
| Lanzador | 3 | El suelo es peligroso | 30 | 14 | Arco curvo | 2 frames de boca |
| Blindado | 4 | Hay que rodear | 32 | 20 | Bloque | Placa que parpadea |
| Resucitado | 5 | Soltar tiene castigo | 28 | 14 | Carrilero roto | Grietas cian |

---

## 3. Los 6 subjefes

**Qué son (§4.2):** cada nivel tiene una **sala de penúltima**. No es un jefe
grande: es un **encuentro diseñado**, más pequeño y más rápido que el jefe. Su
trabajo es **enseñar la mecánica del jefe de su piso** en formato de prueba.

> Por qué existen: si el jefe final introduce una mecánica que el jugador no ha
> visto nunca, la muerte es injusta (§6.4, §8.1). El subjefe da el ensayo.

| Nivel | Subjefe | **Mecánica que enseña** | Forma | Tamaño |
|---|---|---|---|---|
| 1 | **EL PORTERO ENCABEZADO** | Contacto = daño. Un golpe y pierdes | Enorme y **lento** | 40 px, el más grande |
| 2 | **LOS GEMELOS** | **Rápido e inofensivo pero específico**: 2, uno copia al otro | 24 px ×2 | Medianos |
| 3 | **LA CALDERA** | **Zonas de daño en el suelo** | Cuadrada, 44x44 | Ancha y baja |
| 4 | **EL ESCRIBANO** | **Copia tu build.** Un rival con tu misma arma | 30 px | Mediano |
| 5 | **LA CIRUJANA** | **Elimina tus i-frames.** Ningún dash es seguro | 32 px, **flotante** | Sin piernas |
| 6 | **EL ECO** | **Todo junto**, pero más rápido | 26 px | Pequeño y rápido |

> **Todos son tirados a mano.** No hay ataques guionizados y complejos. El juego
> tiene dos botones (§3); un subjefe que exige 6 comandos contradice el diseño.

---

## 4. Los 6 jefes

Cada jefe **introduce una mecánica y la examina** (§10.1). Tres reglas duras:

1. **Toda la telegrafía es por forma** (§6.2): círculo = daño en zona, cono =
   daño en dirección, aro = daño radial.
2. **Nada de fases aleatorias.** Todo daño debe poder anticiparse (§10.1).
3. **Ninguna muerte gratuita.** El jugador siempre debe poder decir por qué
   murió (§6.4).

---

### 4.1 JEFE 1 — EL PORTERO

> **Nivel: Vestíbulo. Enseña:** que el contacto hace daño.

| Parámetro | Valor |
|---|---|
| Altura | 52 px |
| Silueta | **Una puerta con piernas.** Cuadrado arriba, disproporcionado abajo |
| Paleta | `#8a8a92` cuerpo, `#ff2d6f` ojo central |
| Fases | **1** (0-100% vida) |

- **Fase única, sin cambios.** Es el jefe de aprendizaje: mismo patrón, más rápido
  en la fase final.
- **Ataques:** embestida horizontal (**cono blanco** de aviso 1 s), pisotón
  (**círculo** en el suelo), y barrido con los brazos (**arco** de 180°).
- **Regla:** tras cada ataque queda **1.2 s quieto**. Es la ventana para atacar.
  Si el jugador no la ve, es que no está mirando (§6.1).

> **Diseño:** en el nivel 1 solo hay este jefe. Debe ser **fácil** y legible. Su
> único trabajo es enseñar que el dash tiene reglas.

---

### 4.2 JEFE 2 — LOS GEMELOS

> **Nivel: Market Roto. Enseña:** hay más de un enemigo que hacer.

| Parámetro | Valor |
|---|---|
| Altura | 30 px ×2 |
| Silueta | **Dos espejos.** Idénticos, uno **en espejo** del otro |
| Paleta | `#4a3444` y `#344a44` (tinte distinto cada uno) |
| Fases | **1** |

- **Fase única.** Dos, el mismo cuerpo exacto pero con tinte distinto.
- **Ataques:** cada uno embiste hacia el lado contrario. Cuando se cruzan, se
  crea un **cono doble** que cubre el centro. Ese es su momento peligroso.
- **Regla:** si matas a uno, el otro se vuelve **más rápido** pero más vulnerable.
  Premia la decisión de a cuál matar primero.

> **Diseño:** el único jefe con **decisión estratégica** en lugar de ejecución.

---

### 4.3 JEFE 3 — LA CALDERA

> **Nivel: Refinería. Enseña:** el suelo es peligroso.

| Parámetro | Valor |
|---|---|
| Altura | 44 px |
| Silueta | **Círculo perfecto.** No tiene forma reconocible, es una esfera |
| Paleta | `#6a4a3a` hierro, `#ff8a3d`Respiradero incandescente |
| Fases | **2** |

- **Fase 1 (100-50%):** deja **charcos de daño** en el suelo (círculos
  `#ff8a3d` con aviso de 1 s antes de activarse). El suelo deja de ser seguro.
- **Fase 2 (50-0%):** los charcos se quedan. Hay que **mantener el movimiento**.
- **Ataque:** Expansión radial de **aro** (#ff8a3d) que crece desde el centro.
- **Regla:** no tiene daño cuerpo a cuerpo. **Solo suelo y aro.** Quien intente
  acercarse, muere.

> **Diseño:** el primero que obliga a **jugar en vertical** (§2.1), porque los
> charcos no suben a las repisas altas.

---

### 4.4 JEFE 4 — EL ESCRIBANO

> **Nivel: Archivo. Enseña:** tu build no es solo tuya.

| Parámetro | Valor |
|---|---|
| Altura | 34 px |
| Silueta | **Igual que el personaje jugador**, pero en `#2a2434` |
| Paleta | `#2a2434` cuerpo, `#ff2d6f` tinta |
| Fases | **2** |

- **Fase 1:** pelea con una **réplica de tu arma actual**. Si llevas espada,
  tiene espada. **Cada vez que recoges un arma, él la cambia.**
- **Fase 2 (50%):** **duplica** los ataques. Dos de cada uno, en espejo.
- **Regla:** tiene **los mismos i-frames** que el jugador. No se puede golpear
  durante un dash suyo.
- **Ataques:** los mismos del arma, pero **con los timings distintos** (más
  lentos en la 1, más rápidos en la 2).

> **Diseño:** el meta-jefe. No introduce una mecánica: **quita la variable "yo
  controlo mi arma"**. El jugador deja de sentirse cómodo y tiene que volver a
  pensar. Lo hace el único de los seis que **se parece a ti**.

---

### 4.5 JEFE 5 — LA CIRUJANA

> **Nivel: Clínica. Enseña:** el dash deja de ser siempre seguro.

| Parámetro | Valor |
|---|---|
| Altura | 34 px |
| Silueta | **Flotante, sin piernas.** Flota sobre un charco |
| Paleta | `#c8c0d8` vendas, `#9afaf2` bisturí |
| Fases | **2** |

- **Fase 1 (100-40%):** lanzas **agujas** con aviso de 1 frame. Normales.
- **Fase 2 (40-0%):** lanza una **barrera de agujas** (**arco**) cada 8 s que
  **cruza la pantalla horizontalmente**.
- **Regla:** su segundo ataque **cancela la invulnerabilidad** del dash. Es
  decir: **durante la barrera, el dash no sirve**. El jugador tiene que *saber*,
  porque el dash es su salida.
- **Ataques:** agujas en abanico (**cono**), barrera (**arco horizontal**),
  y pulso radial (**aro**).

> **Diseño:** es el único jefe que **elimina la mecánica central del juego** un
  rato. La racha y la barra de poder siguen ahí, pero **sin dash no hay nada**.
> Es el jefe que más odiará la gente y el más honesto sobre lo difícil que es el
> nivel 5.

---

### 4.6 JEFE 6 — EL NÚCLEO

> **Nivel: Núcleo. Enseña:** nada nuevo. Solo todo junto.

| Parámetro | Valor |
|---|---|
| Altura | 56 px |
| Silueta | **Ojo vertical con patas.** Rectángulo alto, manos debajo |
| Paleta | `#2a2434` base, `#ff2d6f` ojo, `#ffc400` refractive |
| Fases | **3** |

- **Fase 1 (100-70%):** aro expansivo + conos en abanico.
- **Fase 2 (70-35%):** invoca **2 Embestidores**. Si no los mata, siguen
  atacando durante el resto del combate. **La sala se llena.**
- **Fase 3 (35-0%):** todos los ataques anteriores, **más rápido**, y el suelo
  se convierte en **charcos de daño** (como la Caldera).
- **Regla:** en la fase 2 los enemigos invocados **se quedan**. En la 3, el charco
  es permanente. No se puede "esperar a que se acabe".
- **Ataques:** aro radial, conos en abanico, invocación, y charcos de suelo.

> **Diseño:** no tiene un ataque nuevo. Su identidad es **la suma**: todo lo
> que aprendiste, **más rápido y sin descanso**. El jefe final de un roguelite
> no tiene que enseñar, tiene que **cobrar**.

---

## 5. Tabla resumen de jefes

| Nivel | Jefe | Fases | Enseña | Ataques | Amenaza principal |
|---|---|---|---|---|---|
| 1 | El Portero | 1 | Contacto = daño | Cono, círculo, arco | Su tamaño |
| 2 | Los Gemelos | 1 | Hay más de uno | Conos cruzados | El cruce doble |
| 3 | La Caldera | 2 | El suelo es peligroso | Aro, charcos | Sin suelo seguro |
| 4 | El Escribano | 2 | Tu build no es solo tuya | Copia tu arma | Se parece a ti |
| 5 | La Cirujana | 2 | El dash no siempre vale | Agujas, barrera | Cancela i-frames |
| 6 | El Núcleo | 3 | Nada nuevo | Aro, conos, charcos | Todo junto |

---

## 6. Reglas de color compartidas

> Sin esto, los enemigos se confunden con los personajes o entre sí (§6.3).

| Color | Uso exclusivo | Nunca en |
|---|---|---|
| `#ff2d6f` | **Amenaza / daño** | Personajes, enemigos que no sean peligrosos |
| `#ffc400` | **Alerta / recompensa** | Personajes, enemigos |
| `#ff8a3d` | **Zona de daño en el suelo** | Personajes, enemigos |
| `#9afaf2` | **Reanimación / Regeneración** | Personajes, enemigos normales |
| `#8a8296` | **Piel / Yui** | Enemigos |
| `#ffc400` (Ren) | **Solo Ren** | Cualquier otro |

> **Los enemigos de daño se distinguen entre sí por FORMA, no por color** (§6.2):
> todos usan `#ff2d6f` para amenazar. Lo que los hace distintos es su silueta y
> su aviso. Si se distinguieran por color, habría que memorizar cinco tonos
> distintos y la legibilidad caería (§6.1).

---

## 7. Checklist antes de programar

- [ ] Cada enemigo se reconoce a **24 px** por silueta sola
- [ ] Cada ataque enemigo tiene **al menos 1 frame** de aviso visible
- [ ] Los enemigos con los mismos colores se distinguen por **forma**
- [ ] Ningún enemigo se confunde con un personaje a 24 px
- [ ] Los personajes **nunca** están en la misma línea vertical que un enemigo
      (§7 de `PERSONAJES.md`)
- [ ] Los jefes 1-3 se matan **sin** usar las reliquias (§9)
- [ ] El jefe 5 (Cirujana) tiene su aviso **claro** aunque cancele el dash
- [ ] Cada jefe tiene **una** ventana clara para atacar, siempre la misma

---

## 8. Nota de scope

> **Estos 5 arquetipos + 6 subjefes + 6 jefes = 17 entidades.** Es mucho.

Prioridad de implementación si el tiempo aprieta:

1. **Arquetipos 1-2** y **Jefe 1** (hito 1-2 de `DISEÑO.md`). Sin esto no hay
   juego.
2. **Arquetipos 3-5** y **Jefes 2-3** (hito 4). Con esto ya se puede probar la
   curva de dificultad completa.
3. **Subjefes** y **jefes 4-6** (hito 5). **Lo último.** Son el techo del
   contenido, no el suelo del juego.

> La lección que repetimos desde el hito 0 (§15): **primero que el dash se sienta
> bien.** Un juego con 3 enemigos y un jefe mediocre se disfruta. Un juego con 17
> enemigos y un dash que no mola, no.
