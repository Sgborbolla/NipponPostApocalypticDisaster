# DISEÑO — Action roguelite de dos botones

> **Nombre:** **NPAD** — *Nippon Post-Apocalyptic Disaster* (§14, **decidido**)
> **Tema:** post-apocalipsis cyberpunk, personajes de estilo anime, paleta OVA
> desaturada (§7.1).
> **Estructura:** **vertical**, jugador siempre en ascenso (§4.1)
> **Alcance v0:** 6 niveles, 6 subjefes, 6 jefes, para probar.
> **Estado:** documento de diseño. El prototipo `assets/game.js` (vía
> `../../../game.js`) cubre solo el hito 0 **parcial** (§15).
> **Última actualización:** 2026-10-02 (**rev. 5** — nivel en ascenso con
> subjefe a mitad, nivel/cartas, Ruptura con cinemática)

---

## 0. El referente, verificado

(comprobado en la ficha de Steam, 2026-10-02):

| Dato | Valor |
|---|---|
| Estado | **Sin lanzar.** Q4 2026, **0 reseñas** |
| **Demo** | **Gratis y disponible** (appid **4991230**, publicada ~28 jul 2026) |
| Género / cámara | **Beat 'em up lateral**, etiquetas: *Beat 'em up*, *Side Scroller*, **2.5D** |
| Promesa | "the horde **closing in from every side**" |
| Sistemas | **Weapon Fusion** + **Relic Unlocks** |
| Arte | Sprite 2D dibujado frame a frame, "a touch of retro pixel soul" |
| Requisitos | Windows, i3-7100, 4 GB, **GTX 960** |
| Mando | Full controller (DualShock / DualSense) |
| Edad | DEJUS 12 · PEGI 16 · IGRS 15 (violencia) |
| IA | Declarada: música y material de partida para parte del sonido y el arte |

### 0.1 Qué se copia y qué no

La referencia se usa para **dos cosas**, y solo dos:

| Se toma de la referencia | No se toma |
|---|---|
| **El listón de sensación**: dos botones deben dar profundidad real | La cámara |
| **El listón de animación**: sprite frame a frame, con peso | La densidad y el ritmo de la horda |
| **La velocidad**: runs cortas, muévete, repite | La estructura de salas |
| Que un solo dev puede entregarlo | El tono visual (ver §7.1) |

> ⚠️ **NPAD es vertical, no lateral.** La referencia es un beat 'em up lateral y
> ese es precisamente el punto: NPAD se aparta de ahí a propósito, porque el
> argumento de §3.4 —que sin botón de salto la subida la hace el dash— solo
> funciona si el nivel es vertical. En lateral habría que añadir un tercer botón
> o un salto, y se pierde el motivo por el que se eligieron dos botones.
>
> La verticalidad **es** la diferencia propia de NPAD. Es lo que convierte la
> torre en el Ward (los pisos como capas de tiempo congelado, §2.1) en una
> mecánica y no en un decorado.

**Tres datos verificados que sí corrigen este documento:**

1. **La resolución interna no es 480×270.** La referencia entrega capturas a
   1920×1080 con objetivo GTX 960. §13 está corregido.
2. **La demo existe y es gratuita** (appid 4991230). Cualquier afirmación sobre
   "qué se siente bien en este género" debería comprobarse contra ella antes de
   programarse. Es la fuente más barata de información del proyecto.
3. **La referencia es 2.5D y el sistema de fusionado de armas funciona.** Ni lo
   uno ni lo otro obliga a NPAD: §7.0 mantiene 2D, y §5.1 ya define la fusión
   como sistema propio.

---

## 1. Pitch

Un action roguelite en **vertical** en el que **solo pulsas dos botones** y
subes por una torre arrastrando hordas. No hay combos memorizados: el juego
entero se decide en **dónde te pones y cuándo te mueves**. Cada partida cambia
tu arma y tus reliquias, así que el mismo nivel se juega distinto cada vez.

**En una frase:** matas para poder moverte, te mueves para poder matar.

---

## 2. La fantasía

No es "tener la mejor build". Es **sentirse dueña de la horda**. El jugador
debería salir de un nivel pensando que podría haber aguantado cinco más.

Tres pilares, en orden de prioridad:

1. **Poder** — las bajas estallan, son abundantes y se encadenan.
2. **Legibilidad** — en ningún momento hay que adivinar qué va a pasar.
3. **Variedad** — dos partidas distintas se sienten distintas.

### 2.1 El mundo — El Silencio

**Japón, costa de Kantō. 39 años después del Silencio.**

El **Ward Noveno** no era un distrito: era una arcología de investigación. Un
bloque urbano cerrado, autónomo, con cuarenta mil personas dentro. El único
sitio del país donde se investigaba algo que nadie quería nombrar.

Hace treinta y nueve años dejó de emitir cualquier señal. **Catorce minutos de
nada.** Cuando volvió la luz, el Ward había cambiado de forma.

**El tiempo se había separado en capas.** Cada piso corría a una velocidad
distinta, y quien quedó dentro quedó atrapado en su propio instante,
repitiendo el mismo segundo para siempre. Cuarenta mil personas que siguen
ahí arriba, todavía repetiendo.

Hoy el Ward es una ruina vertical que nadie cruza. Los asentamientos de fuera
lo llaman por lo que es: un pozo de gente que no se muere.

**Los Instantes** son quienes pueden entrar en la fractura entre capas y moverse
donde los relojes no llegan. La mayoría enloquece: atrapados repitiendo un
instante hasta que ya no saben qué selves son ellos. Pero hay cuatro que no han
perdido el hilo.

Su única forma de cerrar la fractura es llegar al **núcleo**, en lo alto de la
torre. Nadie ha subido y ha vuelto con la misma cara.

> **Por qué el juego es vertical:** el tiempo está apilado en capas, una por
> piso. El Ward es literalmente una torre de momentos congelados. Para llegar
> al núcleo **hay que subir**. La dirección vertical no es una preferencia
> estética: es lo que la historia obliga.

**Tono:** post-apocalipsis **institucional**, cyberpunk. Carteles en fachadas,
números de edificio, DEFCON, satélites de reconocimiento: el Estado que sigue
funcionando aunque ya no haya nadie a quien proteja. La catástrofe ya pasó; lo que
queda es la burocracia de un mundo que no se ha dado por muerto, con los dientes
puestos.

> La textura es administrativa, el aparato es militar. Son cosas distintas: el
> aparato del Estado **no** es lo que hace único al juego. Lo único es que sigue
> emitiendo señales al vacío y alguien las lee (§2.1). El horror es
> administrativo, no militar.

#### La misión

Subir el Ward hasta el núcleo y cerrar la fractura. Cuatro Instantes, una
torre, y cuarenta mil personas que llevan treinta y nueve años esperando.

> ⚠️ Estos tres entran en conflicto directo. Casi todo fallo de diseño en este
> género nace de ganar dos y perder el tercero. Ver §6 y §8.

---

## 3. Verbo técnico: Atacar + Dash

### 3.1 Por qué este par

| Criterio | Atacar + Dash | Atacar + Golpe de rango |
|---|---|---|
| Legibilidad del peligro | **Alta** — i-frames visibles y telegrafiables | Media — el rango hay que deducirlo |
| No necesita apuntar | **Sí** | No (en lateral, apuntar = 3 botones) |
| Escala a hordas | **Sí** — dash para reposicionarse y atravesar | Regular — sin evasión real |
| Genera skill legible | **Sí** — frames de esquiva contables | Difícil de verbalizar |

Se elige **Atacar + Dash**.

### 3.2 El dash — el verbo firma

Es el sistema más importante del juego. Especificación inicial:

| Parámetro | Valor | Nota |
|---|---|---|
| Duración de i-frames | 0.18 s | Ventana total |
| Recuperación post-dash | 0.12 s | **Vulnerable.** El coste real |
| Cargas | 2 | Se regeneran passively |
| Cancelación | El dash cancela la recuperación del ataque | Permite jugar agresivo |
| Dash-ataque | Atacar durante el dash atraviesa y daña | **Mantiene las i-frames** |
| Colisión durante el dash | El jugador **atraviesa** enemigos | Fasear horda |

**Regla de oro — las bajas recargan dash.**

```
Dash golpea enemigo  → +0.5 carga
Dash-ataque         → +1.0 carga
Baja normal         → +0.15 carga
```

Consecuencia de diseño: un jugador que **revela a una horda para destrozarla y
recargar** tiene movilidad infinita. Un jugador que huye al rincón se queda
seco. La agresividad es literalmente la fuente de recursos.

> ⚠️ Iterar este número hasta que el jugador *nota* el cambio de ritmo. Si nadie
> lo menciona nunca, el sistema no se está comunicando.

### 3.3 El ataque — deliberadamente genérico

El botón de ataque **no tiene identidad propia**. La pone el arma equipada:

- Tipo de arco (frontal, circular, detrás)
- Número de impactos, área, knockback
- Si admite carga (mantener)
- Si es cancelable en dash

El ataque solo define el **vocabulario de espaciado**: dónde puedes estar segura
con el arma actual. Cambia el arma → cambia el mapa mental del jugador.

### 3.4 Movimiento — 8 direcciones, vertical, y el dash es el salto

> **Libre en las 8 direcciones. Los niveles son verticales. Sin botón de salto:
> el dash es el salto.**

Esta es la decisión que hace que el nivel vertical funcione **sin romper los dos
botones**. Un nivel vertical sin salto necesitaría un tercer botón; en cambio,
si **el dash es omnidireccional y también te eleva**, la subida se hace con el
mismo recurso que la esquiva.

De hecho mejora el diseño: el dash deja de ser solo "no morir" y se convierte
en **el verbo de movimiento**. Con 2 cargas, subir tiene coste real.

| Regla | Valor | Por qué |
|---|---|---|
| Direcciones | 8, digital | Sin ambigüedad de "¿voy al 70%?" en un juego de timing |
| Aceleración | Ninguna | Respuesta instantánea al input |
| Salto | **No** | El dash cubre ese papel |
| Dash vertical | **Sí**, mismo coste y distancia | Es el salto |
| Repisas | Sí, se alcanzan con **dash** | Sin salto no hay doble herramienta |
| Dash diagonal | **Distancia normalizada** | √2 ≈ 1.41 haría del diagonal una estrategia dominante |

> Normalizar el dash no es cosmético: convierte elegir dirección en una decisión
> de coste real.

**Consecuencia de diseño:** con 2 cargas, subir un tramo de 3 repisas obliga a
matar para recargar. El nivel vertical **fuerza** el bucle agresivo en lugar de
dejarlo como opción. Eso es exactamente lo que queremos.

El personaje mira siempre a la última dirección horizontal pulsada. Indicador de
frente **obligatorio** en el sprite: en un juego de hordas, no saber hacia dónde
atacas es inaceptable.

> ⚠️ **Riesgo añadido por la vertical:** la legibilidad (§6) es más difícil en
> vertical que en horizontal. La cámara ve más alto y más bajo, pero el jugador
> pierde la noción de "cuánto me falta". Mitigación en §6.5.

### 3.5 Ataque — una cadena, no un botón

```
Toque 1  →  Toque 2  →  Toque 3  →  [mantener]  RUPTURA
```

| Regla | Valor |
|---|---|
| Pulsaciones | Una por golpe. **Sostener no repite** |
| Ventana de encadenado | ~0.30 s tras el fin de animación |
| Cancelación en dash | **Desde el frame 1**, incluso a mitad de animación |
| Autoavance | Cada golpe empuja al personaje hacia delante |

> El **autoavance** es lo que hace que un tajo corto se sienta agresivo. Sin
> él, atacar y moverse son dos verbos separados y el combate se siente plano.

El arma decide la forma de la cadena. Aquí es donde vive la build:

| Arma | 1 | 2 | 3 | Ruptura |
|---|---|---|---|---|
| **Espada** | Tajo horizontal rápido | Revés | Arco amplio que empuja | Corte en cruz + onda de choque |
| **Daga** | Dos pinchazos veloces | Patada baja | Remate giratorio | Tormenta de cuchillas, **arrastra** enemigos |
| **Escopeta** | Disparo | Retroceso (te empuja atrás) | Disparo doble | Descarga total, tiembla pantalla |

> El retroceso de la escopeta es un rasgo, no un efecto secundario: convierte la
> distancia en un recurso. Cerca es cómodo, lejos tiene coste.

### 3.6 Poderes — no hay tercer botón

> **La barra de dash ES la barra de poder.** Un solo recurso, dos funciones.

Los poderes son tres capas y ninguna es un botón nuevo:

1. **La Ruptura** — el especial (§11.5). Consume una carga de dash completa.
   Como el dash lo recargan las bajas, **solo puedes hacer cinemáticas si has
   sido agresivo antes**. El espectáculo tiene precio.
2. **Las reliquias** — pasivas que cambian reglas, no números (§9).
3. **La fusión de armas** — poderes activos: cada fusión añade un movimiento
   nuevo a la cadena (§5).

El bucle completo queda así:

```
matar → recarga dash → moverte → matar más → Ruptura → más bajas
```

Un único recurso alimenta movimiento, supervivencia y espectáculo. Esa es la
razón por la que **dos botones** dan profundidad de verdad: no hay que añadir
controles, hay que cerrar el bucle.

### 3.7 Mapa de controles

```
WASD / Flechas / stick izq.    Mover (8 direcciones)
Espacio / J / Z / stick der.↓  ATACAR
Shift  / K / X / stick der.↑  DASH
```

Gamepad: stick izquierdo mueve, **A** ataca, **B** o **RB** hace dash.

- Sin rebind obligatorio en v1, pero **intercambio de botones A/B** sí, desde
  ajustes. Es la primera queja habitual.
- Deadzone en stick **configurable**. Los sticks analógicos muertos son la causa
  número uno de "el juego va raro".

### 3.8 Anti-frustración

- **Cancelación cruzada:** cualquier estado → dash. Nunca estás atrapado.
- **Dash dirigido:** sin entrada, hace dash en la última dirección.
- **Buffer de 6 frames** en el ataque: el timing humano imperfecto no castiga.
- **Prioridad de dash sobre ataque:** si llegan juntos, gana el dash.
- **Ninguna muerte gratuita.** Cada muerte debe ser legible (§6.4).
- **Nada de bloqueo de input durante cut-ins.** Un cut-in que te quita el control
  es un cut-in que mata la run. Los cut-ins son no-mortales y no pausan el input.

---

### 3.9 Los cuatro Instantes

Se elige personaje **fuera de la run**, en la pantalla previa. Cada uno cambia
cómo se siente el mismo nivel; ninguno es "el mejor", todos ganan y pierden cosas.

> **Los cuatro tienen diseño original** (§7.2). Los nombres son japoneses a
> propósito, pero ningún personaje está tomado de ninguna serie.

| # | Personaje | Arma | Dash | Dificultad | Fantasía |
|---|---|---|---|---|---|
| 1 | **Rika Tsukimi** | Katana | 2 cargas, **daña al atravesar** | Fácil | Precisión |
| 2 | **Goro Arashi** | Maza + escudo | 1 carga, **larga** | Fácil | Aguante |
| 3 | **Ren Hayashi** | Dagas gemelas | **3 cargas, se recargan solas** | Media | Velocidad |
| 4 | **Yui Nakamura** | Rifle de cerrojo | 2 cargas, **teletransporte** | Media | Distancia |

> ⚠️ **Los cuatro son iguales de fuertes.** No hay personaje trampa ni personaje
> de reserva. Ver §3.9.5: se equilibra el *techo*, no los números.

#### 3.9.1 Rika Tsukimi — *La que lleva entrenando desde los quince*

- **Físico:** 24 años. Baja y fina, 158 cm, hombros estrechos. Ojos hundidos y muy abiertos, una cicatriz vieja en la ceja izquierda de cuando se cortó entrenando sola.
- **Ropa:** yukata gris oscuro con **haori** corto color hueso — la única prenda clara de los cuatro. Vendas blancas en antebrazos, sandalia de rejilla. Pelo rojo largo en coleta alta.
- **Lectoría:** su silueta se lee a contraluz gracias al **haori**, que ondea con ella. Es la marca que la hace reconocible en un fotograma.
- **Historia:** tenía quince el día del Silencio. Estaba fuera del Ward, evacuando a los que salían por la única puerta que quedaba abierta. Vio a su hermana entrar en un edificio que ya no volvió a abrirse. Ha dedicado nueve años a subir en secreto, esperando el momento correcto. Nunca lo encontró. Ahora sube porque ya no puede seguir esperando.
- **Poder — *Fractura Activa*:** su dash **atraviesa a los enemigos y los daña**. Un dash agresivo, no defensivo. Cada enemigo atravesado le devuelve carga de dash.
- **Por qué es fuerte:** es el único que **se alimenta de la actividad**.
  Cuantas más bajas hace, más móvil es. En una sala larga de 40 enemigos,
  Rika termina con la barra llena y los demás a la mitad. Nadie más aguanta así.

#### 3.9.2 Goro Arashi — *El que cerró la puerta*

- **Físico:** 41 años. 195 cm, enorme, espalda ancha, manos grandes, cabeza hundida entre los hombros. Mandíbula cuadrada, una quemadura vieja en medio cuello.
- **Ropa:** armadura de guardia reensamblada, con un **escudo industrial** atado a la espalda. Casco de obra sin visor. Todo oxidado, color tierra y gris. **El único que no lleva pelo.**
- **Lectoría:** silueta **ancha y baja**, la única masa sólida del elenco. Se lee como "esto no se muere rápido" solo por el tamaño.
- **Historia:** era uno de los que cerraron el Ward. El día del Silencio estaba en la puerta de servicio con la orden de **no dejar salir a nadie**. Obedeció. Pasaron catorce minutos y nadie salió. Treinta y nueve años después sigue recordando la última cara que vio por la mirilla. Sube porque cree que arriba está el hombre que le dio la orden, y que todavía le debe una respuesta.
- **Poder — *Paso de Carga*:** una carga de dash, pero **tres veces más larga** que los demás. Atraviesa una repisa entera de un movimiento y **empuja a los enemigos** que toca.
- **Por qué es fuerte:** su escudo le deja **aguantar golpes que a los otros
  los matan**, y su dash largo es el mejor para ganar altura. Es el único que
  puede abrir un hueco en una sala llena y atravesarla sin esquivar.

#### 3.9.3 Ren Hayashi — *El que no envejeció*

- **Físico:** 19 años aparentes. Delgado, nervioso, manos que no paran quietas. Ojos muy grandes, expresión de sorpresa permanente.
- **Ropa:** agujero de escuela en manga, cinta blanca, vendas atadas en las muñecas. Zapatillas de running gastadas. Amarillo chillón y negro: la paleta más saturada del elenco, **se le ve de lejos**.
- **Lectoría:** el de **mayor contraste**. Es el punto de referencia: cuando haya que encontrar al personaje en pantalla, se busca el amarillo.
- **Historia:** tenía dieciséis cuando el tiempo se rompió dentro del Ward. Todo el mundo quedó atrapado repitiendo un instante. Él salió. Caminó por dentro de la fractura durante años sin saber muy bien por dónde, y cuando volvió a salir tenía diecinueve. No recuerda ese tiempo: entró con dieciséis y el mundo siguió sin él.
- **Poder — *Deslizamiento de Tiempo*:** tres cargas de dash, y **el dash no gasta carga**: se recarga solo, más lento. Ren **nunca se queda sin dash**.
- **Por qué es fuerte:** es el **rey de las hordas apretadas**. Su arma es la más
  débil, pero como nunca se queda sin dash, acumula golpes sin recibir ninguno.
  En una sala llena es el único que no toca el suelo.

#### 3.9.4 Yui Nakamura — *La que llegó tarde*

- **Físico:** 31 años. 172 cm, hombros rectos de quien carga equipo pesado. Se mantiene muy erguida, casi rígida.
- **Ropa:** uniforme militar de guardia con chaleco portaplacas, pelo en moño alto, guantes. Azul basta y gris: la paleta más apagada.
- **Lectoría:** la **más apagada a propósito**, porque su arma tiene un **trazador rojo** que sí se ve. La excepción a la regla: el contraste lo pone el arma, no el cuerpo.
- **Historia:** era médica en el hospital de la frontera, la que decidía a quién se dejaba pasar al Ward para buscar a su familia y a quién se le negaba la entrada porque no quedaba sitio. Cuando el tiempo se rompió estaba fuera. Lleva treinta y nueve años pensando en el hombre al que le dijo que no, y nunca supo si tenía razón.
- **Poder — *Fase de Pocos Metros*:** su dash es un **teletransporte corto** (2-3 casillas) en vez de un desplazamiento, y es la única con **alcance** en el arma.
- **Por qué es fuerte:** **controla el espacio a distancia**. Teletransportarse + pegar de lejos significa que la horda nunca la toca. Es la mejor con las salas abiertas y los enemigos en fila.

#### 3.9.5 Todos son fuertes — regla de equilibrio

> **Ningún personaje puede hacer perder una run por ser peor que otro.**

Ren no es "el rápido y flojo": es **el más rápido y el que mejor esquiva**, y eso
lo convierte en el Rey de las hordas densas. Goro no es "el lento": es el único
que aguanta cuatro segundos dentro de un cerco sin moverse.

El equilibrio correcto **no es igualar números, es igualar techo**. Cada uno
brilla en un escenario distinto, y en su escenario es el **mejor** del elenco:

| Personaje | Su escenario | Por qué gana ahí |
|---|---|---|
| **Rika** | Hordas mixtas, media distancia | El dash que daña: recupera vida de cada ataque |
| **Goro** | Cerco cerrado, pasillos sin salida | Aguanta donde los otros ya han muerto |
| **Ren** | Hordas apretadas, espacio mínimo | Nadie le toca: 3 cargas gratis |
| **Yui** | Salas abiertas, enemigos en fila | Teletransporte + alcance: no la alcanzan |

**Criterio de diseño:** si un personaje solo funciona cuando el jugador juega
"bien", es un personaje malo. Si funciona cuando el jugador juega **a su
manera**, es un personaje bueno.

> Por eso los cuatro siguen teniendo restricciones, pero **ninguna los hace
> inferiores** — son la *condición* bajo la que su poder brilla, no un castigo.

#### 3.9.6 Cómo encajan con la build

Los cuatro se juegan con los mismos dos botones (§3). Lo que cambia es **qué
hace el dash con ellos**, y eso es justo lo que hace que elegir personaje sea
una decisión de build, no de gusto:

| Si quieres... | Elige |
|---|---|
| Dominar los dos botones desde el día 1 | Rika |
| Sobrevivir sacando a la gente de la horda | Goro |
| Sentirte idiota y aun así ir rápido | Ren |
| Quedarte fuera del alcance de todo | Yui |

---

## 4. Estructura de run

```
Inicio de run
   │
   ├─→ NIVEL 1 ─┬─→ Tramo de avance (sin combate, tensión)
   │            ├─→ Sala de oleadas → limpiar RECUENTO → se abre la puerta
   │            ├─→ [opcional] Arena libre con bonus
   │            ├─→ Puerta → jefe de nivel
   │            └─→ ¿Superado? → NIVEL 2 ...
   │
   └─→ Muerte → fin de run → meta-progresión (§9) → run siguiente
```

**Duración objetivo de run:** 15-20 minutos hasta el jefe final.
**Duración de nivel:** 2-3 minutos. Corto, para que el fallo sea barato.

### 4.1 Bucle de nivel — el jugador **sube**, no se planta

**Decidido (rev. 5).** Estructura de **cinco tiempos**: ascenso → umbral →
**subjefe** → ascenso → **jefe**.

#### 4.1.1 Por qué cambió

La rev. 4-era era `avance (sin combate) → sala cerrada → jefe`. Tenía dos
fallos que el usuario detectó de primera:

| Fallo | Consecuencia |
|---|---|
| El corredor de avance **no tenía contenido** | Tiempo muerto. El jugador camina 40 s sin decidir nada |
| La sala cerrada era **el grueso del nivel** | El jugador pasa más tiempo parado que moviéndose. Se siente como un reproach de tuyo |

> Un beat 'em up lateral puede permitirse eso porque **la cámara se mueve sola**
> y el jugador avanza siempre por el decorado del fondo. NPAD es **vertical**: si el
> jugador se para, la pantalla **se para con él**. No hay movimiento de fondo que
> disimule la inacción. Por eso aquí quedarse quieto se ve.

#### 4.1.2 La estructura

| # | Tiempo | Beat | Qué hace el jugador |
|---|---|---|---|
| 1 | ~0:00-0:40 | **Ascenso** | Sube el corredor. Emboscadas cortas. **Sin recuento.** Enseña la mecánica nueva del piso (§4.2) |
| 2 | ~0:40-1:05 | **Umbral** | La puerta se cierra. Contador `N` bajo. Combate **mientras sigue subiendo** |
| 3 | ~1:05-1:25 | **SUBJEFE** | Rellano amplio. Aquí muere la mitad del nivel |
| 4 | ~1:25-2:05 | **Ascenso alto** | Más estrecho, más presión. El espacio ya no es del jugador |
| 5 | ~2:05-2:35 | **JEFE** | **Única sala totalmente sellada del nivel** |

**El subjefe va a mitad, no al final.** Tres razones:

1. **Parte el nivel en dos con karakter distinto.** Antes es escalada; después
   es examen. El jugador sube sabiendo lo que su build hace contra la mecánica
   del piso.
2. **Es el punto de guardado natural.** Morir en el jefe final no obliga a
   repetir los 2 minutos de ascenso. Cumple "el fallo es barato" (§4).
3. **Deja subir la presión en el tramo 4** con un objetivo que no es "llegar":
   el jugador ya sabe qué viene y va hacia él con miedo, que es lo que quiere.

#### 4.1.3 ⚠️ La regla que hace que esto funcione

> **El recuento nunca se cumple cultivando. Se cumple subiendo.**

Este es el punto entero del cambio. El contador de §4.1 sigue ahí, pero:

| Regla | Por qué |
|---|---|
| El contador **bloquea la puerta**, no el movimiento | El jugador **siempre puede subir**. El recuento es lo que le frena, no el juego |
| La puerta abre con el **recuento cumplido Y haber llegado** | Evita poder farmear lejos de la puerta |
| **La horda viene de abajo y es más rápida que el jugador** | **Estarse quieto las alcanza.** La presión de "sigue moviéndote" no es una preferencia del jugador, es la geometría |
| La cuenta **no se pausa** si el jugador retrocede | Retroceder cuesta, pero no borra progreso |

> Por qué importa: si el jugador puede quedarse en un rincón a matar, **va a
> hacerlo**. Todo jugador va a hacerlo. Por eso la horda tiene que llegar por
> detrás: convierte "avanzar" de preferencia estética en requisito de
> supervivencia. La torre deja de ser un sitio donde se aparcan enemigos.

**Corolario del tower-dash (§3.4):** como el dash **es** el salto, y el dash se
recarga con las bajas (§3.2), la barra de carga es **también** la única forma
rápida de subir. Barra llena = climb rápido. Barra seca = subir a paso de
caminante. La economía de combate y la geometría del nivel son **el mismo
sistema**, y por eso subir tiene peso.

#### 4.1.4 ⚠️ Riesgo: la espiral de la barra seca

> **Este es el fallo real de este diseño y hay que cubrirlo antes de programar.**

Si el jugador llega al tramo 4 con la barra seca: no sube rápido → tarda más →
los enemigos lo alcanzan → pero **matar recarga la barra** (§3.2) → entonces sí
puede. La espiral se rompe... salvo que el jugador esté **sin enemigos cerca** en
un tramo tranquilo. Ahí se queda atascado: sin enemigos no recarga, sin recarga
no sube rápido.

| Mitigación | Decisión |
|---|---|
| **Regeneración pasiva baja en los tramos de ascenso** | ~0.25 cargas/s. Nunca llega a acabar una oleada, pero garantiza que el nivel siempre se puede terminar |
| **Paso de caminante sin i-frames** | Se puede subir sin barra, pero se come golpes. Castigo, no bloqueo |
| **El recuento nunca exige más bajas de las que da el tramo** | Si el tramo 4 tiene enemigos suficientes para el `N`, la barra se llena sola por la vía normal |

> Ninguna de las tres convierte la barra seca en cómoda. Las tres solo cierran el
> caso en el que el jugador **se queda atrapado**, que es lo inaceptable.

> **El **recuento de bajas** sigue siendo el contrato del jugador. Le da un
> objetivo numérico claro ("me faltan 14"), que es lo que sostiene el ritmo de un
> arcade de acción. No se puede eliminar sin quitarle esa estructura — pero
> ahora se cumple **en movimiento**, no de pie.

### 4.2 Los 6 niveles — la torre completa

Cada nivel **introduce exactamente una idea nueva** y termina examinándola en el
jefe. Nunca dos cosas nuevas a la vez. Subes, piso a piso (§2.1).

| # | Piso | Idea nueva | Enemigo nuevo | **Subjefe (mitad)** | Jefe (final) | Recuento |
|---|---|---|---|---|---|---|
| **1** | **Vestíbulo** | Contacto = daño. El dash tiene cooldown real | Caminante | **El Portero Encapuchado** | **El Portero**, lento y telegrafiado | 24 |
| **2** | **Market Roto** | Los corredores no se pueden golpear mientras corren | Corredor | **Los Gemelos** | **Los Gemelos II**: dos, uno copia al otro | 32 |
| **3** | **Refinería** | El suelo deja de ser seguro: hay zonas que dañan | Lanzador | **La Caldera** | **La Caldera Madre**, explota el espacio donde pisas | 40 |
| **4** | **Archivo** | Hay enemigos que **no mueren de un golpe** | Blindado | **El Escribano** | **El Escribano Mayor**: te copia tu build, no tu cuerpo | 48 |
| **5** | **Clínica** | Los enemigos **resucitan** una vez si no mueren en la oleada | Resucitado | **La Cirujana** | **La Cirujana defuncta**: corta tus i-frames | 56 |
| **6** | **Núcleo** | Todo junto, sin margen de error | — | **El Eco** | **El Núcleo**, 3 fases | 70 |

> **El subjefe enseña la mecánica del jefe, no al revés.** Por eso comparten
> familia y forma (`enemigos.md` §3). El par no es decorativo: es el ensayo
> (§6.4, §8.1). El jugador llega al jefe final tras verse esa mecánica una vez
> en formato de prueba: **muere en el ensayo, no en el examen.**

**Notas de diseño:**

- Los recuentos suben porque cada nivel añade un arquetipo. **270 bajas** en
  total ≈ 12-15 minutos.
- El **nivel 5** rompe la regla de "matar es suficiente": los Resucitados te
  castigan por dejar enemigos tirados. Es el nivel que más gente odiará, y por eso
  es el penúltimo.

> 6 pisos son **v0 de prueba**. Suficiente para que las builds diverjan de verdad
> y para que la curva de dificultad se sienta. No más.

### 4.3 La curva de dificultad

**Regla dura: la dificultad sube por presión, nunca por cifras.**

| Nivel | Presión | Espacio | Enemigos simultáneos | Menor tiempo entre oleadas |
|---|---|---|---|---|
| 1 | Didáctica | Amplio | 4-6 | Sin límite |
| 2 | Velocidad | Amplio | 5-8 | 25 s |
| 3 | Terreno | Medio | 6-9 | 22 s |
| 4 | Resistencia | Medio | 8-11 | 20 s |
| 5 | Agresividad | Estrecho | 9-13 | 18 s |
| 6 | Todo a la vez | Estrecho | 12-16 | 15 s |

**Prohibido subir la vida de los enemigos.** Los puntos de vida no suben: sube
la cantidad, la velocidad de aparición y lo estrecho del espacio. Un enemigo con
más vida deja de ser una cuenta pendiente.

- El jugador muere más, no porque los enemigos peguen más, sino porque **la
  espiral de refilamiento** (§8.2). Cada nivel reduce el espacio y sube la
  cantidad de enemigos simultáneos, no su fuerza individual.
- **La espiral no sube en ningún sitio:** un nivel 3 debe ser tan fácil para un
  experto como para un novato. Lo que cambia es el **margen de error**, no la
  probabilidad de fallar un ataque.

### 4.4 Geometría compartida, rutas distintas

**Decidido (rev. 5).** Los **6 mapas son los mismos para los 4 héroes**. No hay
niveles por personaje.

> Esto es una decisión de producción buena (6 mapas, no 24) y de diseño mejor de
> lo que parece. Un mapa compartido obliga a que el héroe cambie **la ruta**, no
> los números.

#### 4.4.1 Por qué un mismo mapa no es el mismo nivel

El mapa es el mismo dibujo, pero **el tramo que se recorre es distinto**,
porque el dash **es** el salto (§3.4) y las cuatro físicas de dash son
distintas (`personajes.md`):

| Héroe | Cómo sube el mismo mapa |
|---|---|
| **Rika** | Atraviesa y daña. Sube **dentro** del grupo, es la ruta cara |
| **Goro** | Aguanta y cruza. El único que aguanta un rellano mientras pelea |
| **Ren** | **Nunca sin dash.** La más dependiente de tener barra |
| **Yui** | Alcance y teletransporte. El único que **salta** la ruta larga |

Es decir: el jugador con Yui sube el mismo rellano por arriba, en dos
teletransportes, sin tocar suelo. Con Ren sube por abajo, encadenando dashes, y
si se le acaba la barra se queda sin suelo. **Mismo mapa, otra partida.**

#### 4.4.2 La regla de construcción que esto obliga

> **Cada tramo vertical tiene mínimo 2 rutas, y reconvergen antes del subjefe.**

Sin esto, "mismo mapa para todos" degenera en "el mapa está hecho para el héroe
más limitado y los otros tres lo hacen por inercia". Con esto, el mapa es un
**laberinto con atajos**, y cambiar de héroe cambia el recorrido.

| Regla de nivel | Motivo |
|---|---|
| **Ruta baja** (larga, con horda) | La que puede hacer cualquiera, incluso con barra seca (§4.1.4) |
| **Ruta alta** (corta, expuesta, sin suelo) | Atajo. Solo para dash alto o teletransporte |
| **Reconvergen antes del umbral** | El subjefe y el jefe **no** se pueden saltar. El ritmo del nivel es el mismo para los 4 |
| La ruta alta da **recompensa** (cargas, oro de Ruptura) | El atajo se paga |

#### 4.4.3 Regla de test, no de gusto

> **La geometría se verifica contra el héroe *peor* en salto, no contra el
> promedio.**

| Test | Cómo |
|---|---|
| **El que define la ruta obligatoria** | El héroe con el dash **más corto** (Ren, "nunca sin dash") |
| **El que verifica que los atajos son reales** | El héroe con el dash **más alto** + Yui |
| **Requisito de fondo** | Si Ren no puede llegar al umbral siguiendo solo la ruta baja, el piso **no está terminado**. No es un bug de Ren: es un piso roto |

> Consecuencia incómoda: los atajos pueden romper la presión. Si la ruta alta es
> más rápida **y** más segura, todo el mundo la usa y la ruta baja es decorado.
> Por eso la ruta alta es más corta pero **está expuesta** (§4.4.2).

### 4.5 La puerta entre pisos

**Decidido (rev. 5).** Al matar al jefe, el jugador **cruza una puerta** y se
reproduce una **cinemática** antes del siguiente piso.

```
Jefe derrotado → Sala del jefe vacía → PUERTA (toca el espacio) →
   cinemática de transición (~6-10 s) → Guarda el estado (§15) →
   Título del piso siguiente → Ascenso (§4.1.2)
```

#### 4.5.1 Qué categoría de cinemática es esta

> **No es un cut-in de combate. Es una recompensa.**

Esta distinción es la que hace que §11.4 no entre en conflicto: el presupuesto de
0.35 s existe para que el feedback de impacto no canse (§11.4). Aquí **no hay
impacto, no hay enemigos y el jugador está a salvo**. Puede durar lo que tenga
que durar. De hecho tiene que durar: es lo que compensa haber matado al jefe.

| | Ruptura (§11.5) | Transición de piso (aquí) |
|---|---|---|
| Gatillo | Barra llena + mantener el golpe | Matar al jefe y tocar la puerta |
| Dónde | Dentro del combate | Fuera, sala vacía |
| Duración | 1-2 s | 6-10 s |
| Tensión | Máxima | Nula |
| Interruptor | No (§11.4) | **Sí, siempre disponible** |

#### 4.5.2 Por qué es contenido, no decoración

Resuelve un hueco que §4.1 dejaba abierto: el tramo de ascenso sin combate eran
tiempo muerto. **La transición va justo en la puerta**, que es donde el jugador
ya está parado por obligación. Convierte una espera en un momento.

#### 4.5.3 La regla que evita que sea un tramo muerto

> **La puerta es siempre el mismo marco. Lo que cambia es lo que hay al otro
> lado.**

Si las 6 transiciones son "andar hacia una puerta", la cuarta ya es un trámite.
Por eso el contenido es **el piso siguiente**, no la puerta:

| Transición | Qué muestra |
|---|---|
| Vestíbulo → Market Roto | El segundo piso visto desde abajo, todavía sin enemigos |
| Market Roto → Refinería | Las zonas de daño del piso 3, mostradas **en el sitio donde van a estar** |
| Refinería → Archivo | Los Blindados, quietos, mirándote |
| Archivo → Clínica | Los Resucitados en pie, sin moverse todavía |
| Clínica → Núcleo | El Núcleo. Sin música. Es el aviso de que esto se acaba |
| Núcleo → final | El epílogo. **La única que no enseña un piso siguiente** |

> La cinemática es **spoiler del piso que viene**, y por eso el jugador la ve con
> miedo. Eso es exactamente lo que §2.1 quiere de la torre: el piso 6 debería
> verse desde el 2.

#### 4.5.4 El salto

> **El botón de saltar existe desde la primera transición, sin pedir permiso.**

Una cinemática que se pide a la 4ª vez es una cinemática que se odia. Reglas:

| Regla | Motivo |
|---|---|
| **Saltar disponible siempre**, desde el piso 1 | Anticipa la molestia antes de que exista |
| **Mantener `Escape` 0.6 s**, no un clic | Un clic accidental no debe saltarla |
| **La primera vez, un texto de una línea**: "Mantén Escape para saltar" | Se informa una vez y desaparece para siempre |
| **Nunca saltar obligatorio para avanzar** | El piso siguiente no depende de verla |
| **La transición del Núcleo no se salta** | Es el final de la run. Saltar el final es raro y **se guarda** (§9.1) |

> **Lo que se guarda:** las cinemáticas **no repeatidas** (Piso X visto) son un
> dato de meta-progresión barato y gratis. No dan poder (§9), solo información,
> y eso alimenta el "quiero ver el final" del jugador sin tocar el balance.

### 4.6 Cinemáticas de subjefe y jefe

**Decidido (rev. 5).** Cada subjefe y cada jefe tienen **antes** y **después**.

| Momento | Qué es | Dónde |
|---|---|---|
| **Pre-combate** | El enemigo aparece, **habla en japonés**, se prepara | En la sala, antes de que el jugador pueda actuar |
| **Post-combate** | Cae, dice su última línea, y el mundo reacciona | Al morir, antes de devolver el control |

#### 4.6.1 ⚠️ La cuenta, antes que nada

> **Son 25 secuencias. Es el mayor coste del proyecto y compite directamente con
> las 12 rutas de nivel de §4.4.**

| Tipo | Cantidad | Longitud | Total |
|---|---|---|---|
| Intro de subjefe | 6 | 2-3 s | ~15 s |
| Outro de subjefe | 6 | 2 s | ~12 s |
| Intro de jefe | 6 | 3-4 s | ~21 s |
| **Outro de jefe + transición de piso** | 6 | 8-12 s | ~60 s |
| Epílogo tras el Núcleo | 1 | 20-30 s | ~25 s |
| **TOTAL** | **25** | | **~2.3 min de vídeo** |

Sobre una run de 15-20 min (§4), eso es **el 12-15% del juego sin control**, y en
v0 son 25 piezas de animación **antes** de que el juego sea jugable.

#### 4.6.2 La consolidación que hace esto viable

> **El outro del jefe **es** la transición de piso. No son dos cosas.**

§4.5 ya definía cruzar la puerta. Si el jefe muere, dice su última línea y esa
misma secuencia continúa hasta la puerta, son **una** pieza, no dos. Eso baja de
30 a 25 sin quitar ni un solo momento que el usuario pidió.

```
Jefe muere → [V.O. + última línea del jefe] → silencio → se levanta →
   cruza la puerta → [el piso siguiente se revela] → título del piso → juego
```

Lo mismo aplica al **pre-combate**: no necesita ser una cinemática propia. Puede
ser **un momento jugable** — el enemigo entra en pantalla, dice su línea en
tiempo real con la cámara en él, y **el jugador ya puede moverse durante ello**.
Eso es 25% más barato que un vídeo, y encima tiene más tensión.

#### 4.6.3 El problema serio: la matemática del roguelite

> Esto es lo que hay que entender antes de comprometer producción.

| Run | Secuencias que ve el jugador |
|---|---|
| **1ª** | 25 |
| **5ª** | **125** |
| **20ª** | **500** |

Un roguelite vive de repetir. **Un juego que obliga a ver 25 cinemáticas por
run de 20 minutos es un juego que se borra en la segunda semana.** Y no es una
hipótesis: es exactamente lo que mata a los roguelites con intro de cada nivel.

Por eso el salto de §4.5.4 sube de una cinemática a **el sistema entero**:

| Regla | Detalle |
|---|---|
| **Saltar disponible siempre**, sin excepciones | Ya no es "la transición". Es cada secuencia |
| **Primera vez: se ve entera, sin interruptor** | El jugador no debe tropezar con el botón: lo que encuentra es el dato de "ya la viste" |
| **Repeticiones: 1.2 s de resumen o auto-salto** | Un montaje corto con el esbozo del momento, o nada |
| **Opción "Saltar cinemáticas"** en el menú, activable en cualquier momento | Un jugador que odia las cinemáticas las odia desde la run 1 |
| **La intro de jefe, nunca menos de 3 s** | Es lasetup del examen (§4.1.2). El spoil es barato; el boss fight, no |

#### 4.6.4 El orden de producción, que no es el lógico

> **Primero el diálogo, después el vídeo.**

Todo momento de §4.6 puede existir como **sprite estático + VO japonesa +
texto** sin vídeo. Eso permite escribir, grabar, temporizar y testear la run
completa **antes** de que exista un solo frame de animación.

| Hito | Qué se produce | Dependencia |
|---|---|---|
| **A** | Guiones de los 25 momentos, en japonés, **con texto ES/EN** | Nadie. Se puede hacer ya |
| **B** | Sprite estático + VO por momento | Solo arte y audio |
| **C** | Gameplay completo del run (§15, hito 4) | — |
| **D** | Los vídeos, uno a uno, empezando por el Núcleo | Ya se sabe si funcionan |

> Este orden salva el proyecto. Si los vídeos se hacen primero, se gasta el
> presupuesto en 25 cinemáticas de un juego que todavía no se sabe si es divertido.
> Si van al final, se hace con el run funcionando y se puede **cortar** el que
> sobre sin haber roto nada.

#### 4.6.5 La honestidad del coste

Si hubiera que elegir entre esto y las **2 rutas por tramo** de §4.4:

| | Ganancia | Coste |
|---|---|---|
| **12 rutas de nivel** | Cada héroe juega distinto. Es la mecánica, no el contenido | Geometría |
| **25 cinemáticas** | Carácter y ritmo. Es la ropa, no el esqueleto | **Vídeo + VO + 25 guiones** |

**Yo construiría las rutas primero.** Un juego con las mismas 6 salas y 4 rutas
es un juego; un juego con 25 cinemáticas sobre 6 salas iguales es una demo
bonita. Las cinemáticas se pueden añadir después sin tocar el diseño. Las rutas
no, porque son el nivel.

---

## 5. Sistema de armas y fusión

Las armas **son** la build. El dash no cambia; el ataque sí.

### 5.1 Fusión

Encontrar un arma nueva **ofrece una fusión** con la que llevas. Ejemplos de
prototipo:

| Base + Base | Fusión | Efecto |
|---|---|---|
| Espada | *Hoja Ancha* | Arco 180°, más ancho, menos rango |
| Espada + Bomba | *Estallido de arco* | El arco detona al cerrar |
| Escopeta + Espada | *Cañón de carne* | Un disparo, empuja, tiembla pantalla |
| Daga + Daga | *Remolino* | Giro continuo, daño por tick, cuerpo a cuerpo |

Reglas:
- Máximo **3 armas equipadas** a la vez (2 verticales, 1 pasiva).
- Las fusiones **no se pueden deshacer** dentro de la run.
- Cada fusión tiene un **coste** además de un beneficio (§8.3).

> Por qué importa: la fusión hace que *encontrar* un arma tenga peso. Sin
> fusión, un arma nueva es solo un número más grande y no da decisión.

### 5.2 Nivel y cartas — cómo llega la fusión al jugador

**Decidido (rev. 4).** Las bajas dan experiencia. El nivel **no** sube
estadísticas: da **cartas**.

> Antes de la rev. 4, §5.1 definía la fusión pero **no decía cómo llegaba al
> jugador**. Esto lo cierra.

#### 5.2.1 La regla que lo gobierna todo

> **El nivel no sube números. Cambia qué puedes hacer.**

Es la misma regla de §9 ("las reliquias cambian reglas, no dan números"),
aplicada al interior de la run. Una carta que dé `+15% de daño` está
prohibida: hace que el jugador ganeFacilidad mientras le quita
exactamente el trabajo de decidir. Las cartas tocan **reglas**, no **cifras**.

**Prohibido en cualquier carta:**

| Prohibido | Por qué |
|---|---|
| `+X% de daño`, `+X de vida`, `+X% de velocidad de ataque` | §9 y §8.1. No hay build en un multiplicador |
| **`+cargas máximas de dash`** | **Rompe el núcleo.** §3.2 hace del dash el recurso escaso. Si una carta lo llena, el jugador deja de ser agresivo y aun así tiene todo |
| Quitar un arma o slot | §5.1: las fusiones no se deshacen en la run |
| Cualquier carta que ignoré al enemigo cercano | La tirada tiene que importar siempre |

#### 5.2.2 La economía

| Parámetro | Valor | Razón |
|---|---|---|
| **XP por baja** | Normal 1, Blindado 3, Resucitado 5 | El Resucitado cuesta tiempo (§10); que suba más nivel compensa el coste |
| **Niveles por run** | **5-8**, no 30 | Ver §5.2.3 |
| **XP para el siguiente** | Escalar ×1.35 por nivel | Curva suave, sin mesetas largas |
| **Cartas por nivel** | **1 de 3**, nunca más | Una decisión es una decisión |
| **Repartir puntos sin subir** | Sí, si el jugador **pierde** una run | Antifragilidad: no obligar a un uso de puntos que no quería |

#### 5.2.3 ⚠️ El riesgo: cadencia

> **El sistema no es el problema. El momento de la pausa sí.**

§11.1 ya avisa: *"un juego de masacre se compra con ritmo continuo.
Congelarlo lo mata."* Con 270 bajas (§4.3), un `+1 XP por baja` produce **treinta
y pico interrupciones por run**. A 2 segundos cada una, son dos minutos de
menú sobre doce minutos de combate. El juego deja de ser un flujo de
violencia y pasa a ser un formulario.

**Por eso el nivel es infrequent a propósito.** 5-8 por run significa una carta
cada 90 segundos: lo bastante raro para que la pausa **sea** un evento, no una
costura.

#### 5.2.4 Cómo se comunica sin cortar el flujo

**Decidido: no hay modal.** Al subir de nivel:

| | Solución |
|---|---|
| Pantalla | **El juego no se congela.** La cámara sigue |
| Carta | Un **anillo de 3 opciones alrededor del personaje**, en el mundo |
| Tiempo | 2.5 s, luego se cierra sola. **No hay "confirmar"** |
| Selection | El dash a la carta la elige. Sin ratón, sin pausa |
| UI | Solo el número de nivel en la esquina. El anillo es la feedback |

> Por qué: §3.4 dice que el dash es la única dirección que el jugador controla.
> Usarlo para elegir carta hace que **elegir la build sea otro dash**. El gesto
> que te salva es el gesto que te da el poder. Si el jugador pierde una carta
> por no elegir a tiempo, se queda sin ella — no hay undo.

#### 5.2.5 Catálogo inicial (prototipo)

Cada carta debe cumplir: **cambia una regla**, se lee en menos de 3 segundos,
y tiene un coste (§8.3).

| Carta | Regla que cambia | Coste |
|---|---|---|
| **Rebote** | El arco rebounds a un enemigo más | −15% de daño del arco |
| **Sanguento** | Cada baja deja una poción | Las bajas lentas no la dejan |
| **Explosivo** | Las armas tienen splash | −10% de rango |
| **Ráfaga** | +1 golpe en la cadena de ataque | −20% de daño por golpe |
| **Ancla** | El dash no gasta carga, pero recarga 2× más lento | — |
| **Sed de Sangre** | Bajas curan, pero la vida no se regenera nunca | — |
| **Ruptura II** | La Ruptura se puede lanzar en el aire | Consume 2 cargas en vez de 1 |
| **Crítico de Racha** | A 10 de racha el siguiente golpe es crítico | La racha no se bonifica por encima de 10 |

> **Ruptura II** y **Ancla** son las dos cartas que más tensión de identidad
> crean, y por eso están en la lista: obligan a elegir entre usar el dash para
> sobrevivir (Ancla) o para cargar el especial (Ruptura II). Ninguna de las dos
> es estrictamente mejor.

---

## 6. Legibilidad — el problema difícil

Es la prioridad técnica. Un juego de masacre vive o muere aquí.

### 6.1 Identificación en 200 ms

Un enemigo debe reconocerse por **silueta + color**, nunca por detalle.

- **Silueta distinta por arquetipo.** Un enemigo con embestida tiene hombro.
- **Color = amenaza**, pero **nunca como único canal** (accesibilidad):
  cada peligro lleva además **forma**.
- Máximo **3 arquetipos activos** a la vez en pantalla.

### 6.2 Telegrafía por forma

Cada ataque enemigo tiene un precursor visible antes de ser dañino:

| Forma | Significado |
|---|---|
| Círculo en el suelo | Daño en esa zona |
| Línea / cono | Daño en esa dirección |
| Aro expansivo | Daño radial |
| Parpadeo blanco | Está cargando (prepara) |

### 6.3 Jerarquía visual

1. Enemigos cercanos (en rango de daño) — **máximo contraste**
2. Enemigos lejanos
3. Peligros telegrafiados
4. Fondo — siempre un valor tonal más apagado que cualquier elemento jugable

> Regla dura: **el fondo nunca compite en contraste con un enemigo.** Si un muro
> tiene el mismo valor que un enemigo, es un bug de legibilidad.

### 6.4 Muerte explicable

Al morir, registrar por qué: `(enemigo, skill usada, tiempo expuesto)`.
Un jugador debe poder decir *"me agarró ese mientras estaba en el dash"*. Si un
10% de las muertes son inexplicables, la dificultad es **puta**, no difícil.

---

## 7. Dirección de arte — post-apocalipsis anime

### 7.0 Decisión: 2D, no 3D

> **El juego es 2D pixel art con cut-ins pre-renderizados.** Cerrado.

decisión correcta. El argumento es §6 — legibilidad de silueta en 200 ms. En
2D la silueta es exactamente la que dibujas. En 3D aparece la **oclusión**: un
enemigo se esconde detrás de otro y el jugador no puede leer la amenaza, que es
precisamente el problema que este género no puede permitirse.

Ventajas secundarias: el estilo anime que se busca es 2D por naturaleza, el
coste de animación es 3-5x menor, y las hordes son baratas.

**Camino a 3D si algún día hace falta:** mundo 3D con cámara fija bloqueada y
sprites en billboard, renderizado cel-shaded (estilo *Octopath Traveler* /
*Dead Cells*). Los cut-ins gana mucho en 3D — cámara real volando — así que es
la vía de upgrade natural.

> ⚠️ Empezar en 3D y volver a 2D después tira el 60% del trabajo. Empezar en 2D
> siempre deja la puerta abierta.

### 7.1 Estética objetivo — **HÍBRIDO: cyberpunk con paleta OVA apagada**

> **Decidido en rev. 3.** Se conserva el *género* cyberpunk —el que ya está
> explorado en los mockups de `assets/stitch_npad_pixel_character_roster (4)/`— y
> se cambia la **paleta**: nada de neón por todas partes.

El error que había que evitar: si el HUD y los fondos van saturados, la pantalla
se llena de color y **el jugador deja de ver dónde está el peligro** (§6.1). La
solución no es apagar el cyberpunk, es **gastar la saturación como recurso**.

| Capa | Saturación | Regla |
|---|---|---|
| **Peligro** (daño, telegrafía, proyectil enemigo) | **100%** | `#ff2d6f`, `#ff8a3d`. Único color saturado en pantalla |
| **Recompensa** (relicia, heads-up, oro de la Ruptura) | **Alta** | `#ffc400`. Solo aparece tras un logro |
| **Jugables** (los cuatro Instantes) | **Baja** | Tonos de ropa apagados, una marca de color por personaje |
| **Fondos y arquitectura** | **Muy baja** | Grises, ocres, azul acero. Nunca compiten (§6.3) |

- **Base:** sol apagado y ceniza, cielo siempre cargado, desaturado en ocres,
  grises y azul acero.
- **Contraste:** fondos un valor tonal más apagados que cualquier elemento
  jugable. Sin excepción (§6.3).
- **Cian y magenta solo como aviso.** Nada de "estética cyberpunk" difusa: si
  brilla, es porque mata.
- **Pixel art / sprite 2D** con animación fluida, 6-12 frames por acción.
- **Animación con peso:** anticipación antes de atacar, *squash* al impactar,
  asentimiento (settle) al terminar. El arranque es lo que da peso.

#### 7.1.1 Frecuencia de animación — 60 fps juego, 12 fps cut-in

> **Decidido en rev. 3.** Antes era una pregunta abierta (§17) y los mockups
> asumían las dos cosas a la vez.

| Contexto | Frecuencia | Por qué |
|---|---|---|
| **Combate y movimiento** | **60 fps** | Es lo que hace el timing legible. Un input a 12 fps es medio segundo de latencia |
| **Cut-ins y cinemáticas** | **12 fps escalonado** | Es el look OVA. stepped, no interpolado — y es decorativo, no jugable |

> El error a evitar es correr los dos a 12 fps: se pierde la sensation de
> responsividad y §6.4 se rompe, porque las muertes dejan de ser explicables
> cuando el control va a medio frame. El look OVA va en los **recortes**, no en
> el juego.

### 7.2 Personajes — todos originales

> ⚠️ **Los personajes tienen que ser diseño original.** Referencias de *estética*
> están bien; copiar personajes de una serie existente no. Los juegos con
> personajes "inspirados en" salen de Steam con reclamaciones de una semana, y es una
> pérdida de tiempo evitable.

Objetivo: silueta de protagonista reconocible **en negro puro**, en 3 segundos,
incluso a 8x8 píxeles de prueba.

| Elemento | Requisito |
|---|---|
| Silueta | Una forma inconfundible (arma, pelo, capa) |
| Paleta | 3 colores como máximo en el personaje |
| Lectura | A **1920×1080**, 24 px de alto debe reconocerse |

**Los cuatro personajes sí existen en el diseño** (§3.9), cada uno con un poder
que cambia la física del dash. Las fichas de construcción están en
`personajes.md`. Lo que no existe todavía es la pantalla de selección y el
prototipo actual dibuja una figura genérica.

### 7.3 Efectos (gobernados por §11)

- **Screen shake** con presupuesto: máx. 4 px, decae en ~0.2 s.
- Partículas y estelas: colores limitados a la paleta de peligro.
- Todo el impacto grande va en **shader de pantalla completa**, no en sprites.

### 7.4 Idioma y audio — **Japonés, subtítulos a elegir**

> **Decidido en rev. 3.**

| Elemento | Idioma |
|---|---|
| **Voces** | **Japonés, y solo japonés.** Sin doblaje al español ni al inglés |
| **Subtítulos e interfaz** | **Español o inglés**, a elegir en el menú de inicio |
| Música y efectos | Sin voz, universales |

**Dónde se elige:** en la pantalla de título, antes de la selección de personaje.
Una sola decisión, sin submenús. Cambiarlo después se permite, pero no es
obligatorio que se pueda: si el jugador elige mal, tiene que poder seguir
jugando.

```
TÍTULO
  ├─ JUGAR
  ├─ OPCIONES
  │    └─ IDIOMA DE TEXTO   [ Español · English ]
  └─ SALIR
```

#### 7.4.1 Por qué esta combinación

- El japonés **es** la dirección OVA que ya se eligió (§7.1). Una voz japonesa con
  subtítulo español es exactamente el formato en el que se consumía el material
  de referencia de los 90. Es coherente, no es un adorno.
- Doblaje a dos idiomas es el doble de trabajo de grabación **y** el doble de
  sincronización labial que este juego no necesita (no hay("--" cutscenes de
  conversación, sino cinemáticas de acción con voz en off).
- Un solo idioma de voz hace que **la traducción no dependa de la voz**. Eso hace
  que añadir un tercer idioma de texto sea barato: solo falta la tabla, no la
  regrabación.

> Referencia: la referencia de §0 hace lo inverso — voz inglesa con 7 idiomas de
> subtítulo. NPAD invierte la relación. Es una diferencia real y defendible.

#### 7.4.2 Voz en combate — **SÍ, decided en rev. 3**

Hay voz japonesa ocasional durante el combate y al usar poderes. Es parte del
tono, no un adorno: en un juego de horda el sonido es lo que hace que el
personaje esté ahí en vez de ser un rectángulo.

**La regla que hace que esto funcione:**

> **Si una línea necesita traducción para entenderse, no pertenece al combate.**
> En combate solo entra lo que se entiende sin traducir.

Esto resuelve de raíz el problema de subtítulo: **en combate no hay nada que
subtitular**, porque nada de lo que se dice aporta información que el jugador no
pueda ver ya en pantalla.

| Tipo | Duración | Ejemplo | Subtítulo |
|---|---|---|---|
| **Grito de ataque** | 0.3–0.5 s | Respiración, grito corto, siseo | No |
| **Grito de daño recibido** | 0.4–0.7 s | Nombre propio o sonido de impacto | No |
| **Bark de dash** | 0.3–0.5 s | Esfuerzo, raspado | No |
| **Bark de poder** (Ruptura) | 0.6–1.0 s | Un nombre o una sola palabra en jap. | **Sí** |
| **Bark de habilidad nueva** (primera vez) | 0.8–1.2 s | Frase corta | **Sí** |

> **La excepción son las dos últimas filas.** El nombre de la Ruptura sí merece
> un rótulo, porque es un momento de la cadena de ataque que el jugador está
> aprendiendo (§3.5). Y la **primera vez** que aparece una mecánica nueva, la
> voz sí se subtitula: ese es un momento docente, no un momento de presión
> (§4.1, un piso = una idea). A partir de la segunda vez, silencio.

#### 7.4.3 Presupuesto de audio — sin esto es ruido

Una horda son muchos enemigos, muchos eventos y pocas voces. Sin reglas duras,
30 barks simultáneos se convierten en una sopa y el efecto es exactamente el
opuesto al buscado.

| Regla | Valor |
|---|---|
| **Máx. voces simultáneas** | **2.** Una tercera corta a la anterior |
| **Cooldown por tipo de bark** | 1.2 s (ataque), 2.0 s (daño), 0.8 s (dash) |
| **Prioridad** | Poder > Habilidad nueva > Daño > Ataque > Dash |
| **Volumen en combate** | Los barks se mezclan **por debajo** de la música |
| **Pitch por racha** | Sube con la racha (§11.3), como el resto del audio |
| **Nunca en pantalla de muerte** | El bark de run fallida sí, a volumen completo |

> Un bark que se corta a mitad de palabra es peor que no tener bark. El cooldown
> por tipo es lo que lo evita.

#### 7.4.4 Coste de producción — la parte incómoda

1. **El diálogo de historia** necesita tres cosas por línea: japonés original,
   traducción al español y traducción al inglés. Si falta una, el subtítulo se
   queda mudo.
2. **Los barks de combate no necesitan traducción**, solo japonés. Son un único
   archivo de audio por personaje y se reutilizan. Son la parte barata.
3. **El timing del subtítulo manda** en el diálogo: tiene que caber en la
   duración de la línea japonesa. Si la traducción es un 30% más larga, hay que
   subir la velocidad de lectura o acortar el original.
4. **Escribir en japonés** (o comisionarlo) es una dependencia externa. Si no hay
   quien lo haga, esta decisión bloquea las cinemáticas.
5. **El historial de traducción tiene que ser fuente única.** La tabla
   `linea_id | ja | es | en` es el activo del proyecto. No se escribe el
   subtítulo a mano en el motor.

#### 7.4.5 Reglas de subtítulo

- **Activados por defecto**, siempre. Desactivarlos requiere pasar por un aviso.
- Máx. **2 líneas** de 42 caracteres. Más de eso nadie lo lee durante una pelea.
- Los nombres propios van en **katakana o romaji, no traducidos**. Goro sigue
  siendo Goro en los tres idiomas.
- Los términos de lore (el Silencio, los Instantes, el Ward) se traducen, pero la
  primera aparición incluye el término en japonés entre paréntesis.
- Los rótulos en pantalla sin voz **se subtitulan igualmente**, porque el jugador
  tiene que saber que existen aunque no oiga nada.
- En combate, subtítulo **solo** en los dos casos de la tabla de §7.4.2.

---

## 8. Balance — principios

### 8.1 Dificultad

**El objetivo NO es morir mucho.** El jugador debe sentirse desafiado, no castigado. Death→retry < 3 segundos, pero la curva busca aprender, no frustrar.

- Sin puntos de guardado a mitad de oleada.
- Daño = golpe de contacto o telegrafiado. Nunca por empujón.
- El jugador pierde vida **por decisiones**, nunca por RNG oculto.

### 8.2 Comunicación de números

Si un jugador no puede predecir el resultado de su decisión, el juego es
injusto. Cada sistema debe tener al menos un indicador previo.

### 8.3 Coste-beneficio

Toda fusión y toda reliquia tiene un precio. Una build "todo gratis" mata la
variedad y vuelve la run trivial.

---

## 9. Meta-progresión (entre runs)

**Reliquias** — permanentes, se desbloquean y se recogen al empezar cada run.
La regla: **cambian reglas, no dan números.**

| ❌ No hacer | ✅ Hacer |
|---|---|
| +10% de daño | El dash a través de un enemigo te cura |
| +1 de vida máxima | El dash deja estela que daña |
| Ataque más rápido | Si no atacas en 3 s, el siguiente golpe es crítico |
| Menos enemigos | Los enemigos curados dan dash |

Criterio de aceptación: una reliquia debe **cambiar cómo juegas**, no cuánto
pegas.

> **Durante la run.** Además de las cartas (§5.2), los enemigos pueden soltar
> **reliquias temporales** al morir. Estas se recogen en 0.15 s (no se parpadean
> durante combate) y se **pierden al terminar la run**. Nunca son permanentes.

### 9.1 Currencies (a validar)

- **Núcleos:** obtenidos al morir, convertidos en reliquias. Sin grinding.
- **Progresión horizontal primero:** más builds disponibles antes que builds más
  fuertes. Un jugador sin nada desbloqueado debe poder pasarse el nivel 1.

---

## 10. Estructura de enemigos (arranque)

**5 arquetipos base**, uno por piso del 1 al 5. Cada uno **introduce exactamente
una idea** (§4.2) y las fichas completas de construcción están en `enemigos.md`.

| # | Arquetipo | Enseña | Aparece |
|---|---|---|---|
| 1 | **Carrilero** | Contacto = daño | Nivel 1 |
| 2 | **Embestidor** | Hay enemigos que no se pueden golpear mientras corren | Nivel 2 |
| 3 | **Lanzador** | El suelo deja de ser seguro; telegrafía por forma | Nivel 3 |
| 4 | **Blindado** | No muere de un golpe; hay que rodearlo | Nivel 4 |
| 5 | **Resucitado** | Soltar enemigos tiene castigo | Nivel 5 |

> ⚠️ Esta tabla **sustituye** a la de la rev. 2, que listaba 4 arquetipos con los
> nombres *Caminante* y *Corredor* y un escalonado de aparición desplazado una
> planta. Si algo del código o de los mockups usa los nombres viejos, están
> desactualizados.

**Regla de presentación:** un arquetipo nuevo por sala. Nunca dos a la vez
en su primera aparición.

### 10.1 Jefes

- **1 por nivel.** 2-3 fases.
- Cada jefe **enseña una mecánica y luego la examina**: la fase 1 es
  telegrafiada y legible, la fase 3 es la misma mecánica con presión extra.
- Sin fases aleatorias. Todo el daño debe poder anticiparse.

---

## 11. Game feel — el sistema de impacto

Este es el sistema que define las sensaciones del juego. Va primero porque es lo
que más se nota y lo más fácil de arruinar.

### 11.1 ⚠️ El conflicto central — leer esto antes de implementar

Pides **slow-motion en cada golpe**. Eso choca de frente con la fantasía del
juego, y hay que entender por qué antes de escribir código:

- Un nivel pide **matar ~40 enemigos**. Si cada impacto congela 0.3 s a cámara
  lenta, los 40 matan se convierten en 20 segundos de diapositivas.
- **La cámara lenta es un estado global.** Ralentiza también la IA enemiga, el
  movimiento del jugador y tu propio *input buffer*. Es de las pocas cosas que
  se sienten *peor* cuanto más se usa.
- Un juego de masacre se compra con **ritmo continuo**. Congelarlo lo mata.

**La solución — y la regla del proyecto:**

> El impacto **escala con la racha**. Un golpe normal es impacto seco. Un golpe
> con la racha alta es un **tableau a cámara lenta**. El jugador **se gana** el spectacle.

El slow-mo no se quita: **se gana**. Eso convierte el efecto en una recompensa y
además resuelve el problema de pacing de un plumazo.

### 11.2 La racha

**Racha** = bajas consecutivas sin recibir daño.

- Se rompe al **recibir daño** (no al fallar: fallar tiene que ser barato).
- Decae si dejas de matar durante **2.5 s** (para que la racha no se mantenga
  haciendo campana en la última esquina de la sala).

### 11.3 Escala de impacto

| Racha | Hitstop | Time-scale | Cut-in | Sensación |
|---|---|---|---|---|
| 0-9 | 2 frames | 1.0x | — | Seco, limpio |
| 10-19 | 3 frames | 0.55x por 0.08 s | — | "Algo está pasando" |
| 20-39 | 4 frames | 0.40x por 0.12 s | flash frame | Impacto |
| 40-69 | 5 frames | 0.25x por 0.18 s | flash + líneas de velocidad | Violento |
| 70+ | 6 frames | 0.15x por 0.25 s | cut-in completo | Cinematográfico |

> **Regla dura: nunca dos niveles de escala en el mismo golpe.** El jugador
> puede ver *un* destello, nunca una Lawyer comercial dentro del combate.

### 11.4 Cut-ins (los "videoframes")

Estética anime de impacto: fotogramas still, alto contraste, no movimiento.

| Tipo | Duración | Cuándo |
|---|---|---|
| **Flash frame** | 1 frame | Umbral de racha. Silueta blanca sobre fondo negro |
| **Líneas de velocidad** | 2-3 frames | Racha 40+. Fondo de líneas radiales |
| **Frame invertido** | 1 frame | Racha 40+. Colores invertidos |
| **Cut-in de rostro** | 3-4 frames | Combo finalizador. Viñeta del personaje |
| **Cut-in completo** | 12-18 frames | Solo el **Ataque Especial** (§11.5) |

**Presupuesto, sin excepción:**
- Máximo **1 cut-in completo cada 5 segundos**.
- Máximo **1 flash cada 0.4 s**.
- Ningún cut-in puede superar **0.35 s**. Más que eso y el combate deja de fluir.
- Todos los cut-ins son **saltables** desde ajustes (ver §11.7).

### 11.5 El Ataque Especial — "Ruptura"

No hay tercer botón. **La Ruptura es el 4º golpe de la cadena de ataque**, y es
lo que el jugador merece ver en cámara lenta.

```
Toque → Toque → Toque → (mantener) → RUPTURA
 Tajo    Barrido  Remate    Cut-in      Cinemático
```

Especificación:

- A partir del **3er golpe**, mantener el botón **0.18 s** carga la Ruptura.
- Ruptura: **invulnerable de principio a fin**. Cuesta un dash, no vida.
- **Consume una carga de dash** completa.
- Cut-in completo (12-18 frames) → onda expansiva que daña todo lo que toca.
- Empuja a los enemigos: **es la herramienta contra la horda acumulada**.

> **Por qué consume dash:** cierra el bucle. Tu recurso de supervivencia es
> también tu recurso de espectáculo. No puedes encadenar cinemáticas porque sí:
> tienes que haber sido agresivo para tener carga. La spectacularidad tiene precio
> (§8.3) sin que sea un número aburrido.

### 11.6 Checklist de impacto

- [ ] **Hitstop** por nivel de racha (§11.3). Congela actor + víctima + partículas, **no** la cámara
- [ ] **Knockback** siempre. Marca dónde pasó el golpe sin necesidad de UI
- [ ] Flash **blanco** de 1 frame al conectar
- [ ] Muerte: destello → fragmentos → partículas → disolución
- [ ] **Screen shake** con presupuesto (máx. 4 px, decae rápido)
- [ ] Trails de color en el dash, más largas con más carga
- [ ] Sonido **en capas**, el pitch sube con la racha
- [ ] **Barks en japonés** (§7.4.2): ataque, daño, dash y Ruptura, con el
      presupuesto de 2 voces simultáneas y cooldowns por tipo
- [ ] Contador de racha en pantalla, **grande y pulsante** en umbrales
- [ ] Slow-mo breve al **romper el objetivo de oleada**
- [ ] Números de daño: **desactivados por defecto** (rompen el pixel art)

### 11.7 Accesibilidad — obligatorio

Los cut-ins con destellos y cámara lenta son un problema real de
fotosensibilidad y de sensibilidad al movimiento.

- Ajuste **"Reducir destellos"**: quita los frames invertidos y blancos, deja
  las líneas de velocidad.
- Ajuste **"Sin cámara lenta"**: el impacto se mantiene, el *time-scale* no.
- Ambos deben funcionar **sin** romper la legibilidad ni los cut-ins.

> Un juego de impacto no puede exigir cláusula de visión. Los cut-ins son
> decoración sobre un sistema que ya funciona sin ellos.

### 11.8 Cinemáticas: **dos categoría, dos tecnología**

> ⚠️ **Rev. 5 — esta sección estaba mal.** Decía "nada de ficheros de vídeo" en
> plano absoluto. Esos cut-ins **son** vídeos, y ya existen generados: 4 en
> `assets/`, uno por personaje (`..._cut_in_for_npad_goro`, `_ren`, `_yui`,
> `_ruptura`, ~1.5 MB cada uno). La regla correcta no era "nada de vídeo", era
> **distinguir qué animación va en vídeo y cuál no**.

#### 11.8.1 La regla

> **Vídeo para lo que cuenta una historia. Sprites para lo que es feedback.**

El argumento de la rev. 2 ("el vídeo se desincroniza") es **certaino para el
feedback de impacto y falso para una secuencia lineal**. No es que el vídeo no
sincronice: es que el vídeo **necesita** un reloj propio, y el feedback de impacto
necesita el reloj del juego. Son relojes distintos.

| | **Ruptura** (§11.5) | **Feedback de golpe** (§11.6) | **Transición de piso** (§4.5) |
|---|---|---|---|
| Qué es | Cinemática de 1-2 s | Flash de 3-6 frames | Secuencia de 6-10 s |
| ¿Reloj propio? | **Sí**, y correcto | **No**, atado al frame del juego | **Sí**, y correcto |
| ¿Se nota un frame de más? | **No importa** | **Mata la ilusión** | No importa |
| ¿Se nota un frame de menos? | Se ve glitcheado | **Mata la ilusión** | Se ve glitcheado |
| Tecnología | **Vídeo** (`.webm` VP9) | **Sprites + shader** | **Vídeo** |
| Archivos | 4 (uno por héroe) | Atlas compartido | 7 |

**El criterio, en una frase:** si el ojo está mirando al **personaje** y el
resultado depende del frame exacto, son sprites. Si el ojo está mirando la
**escena** y espera un final, es vídeo.

#### 11.8.2 Por qué la Ruptura sí aguanta vídeo

La objeción original era la sincronía, y aquí no aplica por una razón concreta:
**durante la Ruptura no hay nada que sincronizar.** Está en cámara lenta
extrema, es invulnerable de principio a fin (§11.5) y el impacto se aplica en el
frame que el jugador ve. No hay estado de juego al que el vídeo pueda "~ir tarde":
el juego está pausado por diseño.

#### 11.8.3 El coste real, que no era el de la rev. 2

| Coste | Detalle | Decisión |
|---|---|---|
| **Audio dentro del vídeo** | Si el diálogo va horneado en el `.webm`, **el subtítulo no se puede re-temporizar por idioma** (§7.4) | **El vídeo va mudo.** La VO japonesa y el SFX van **fuera**, como pistas separadas. Así el subtítulo ES/EN se ajusta por línea (§7.4.1) |
| **Fotosensibilidad** | Un vídeo con destellos rompe el ajuste de §11.7 | Cada cinemática tiene una **versión reducida de destellos** en sprites. obliged por el ajuste, no opcional |
| **Peso** | 4 vídeos × 1080p ≈ 6 MB, más 7 de transición | Comprimir a **12 fps escalonado** (§7.1.1) → baja a ~1 MB cada uno. La estética OVA **es** la compresión |
| **Decodificación en el peor frame** | Un tirón al disparar el especial se nota más que un tirón en un impacto | Convertir en **stream**, no en `VideoStream` de library: precargar el siguiente frame |

#### 11.8.4 Lo que sigue siendo sprite

Aunque ahora haya vídeo, **no se abandona el sistema de sprites**:

- Los flashes de impacto de §11.6 (los que se repiten 300 veces por run).
- Las líneas de velocidad y la distorsión, que van en **shader de pantalla
  completa**, no en el vídeo.
- La versión de accesibilidad sin destellos.

> **Los vídeos no reemplazan el sistema de game feel, lo rematan.** Si se
> intenta meter en el vídeo el impacto de un golpe normal, se pierde el control
> fino de frame y §11 entero deja de funcionar.

### 11.9 Cuándo quitar los cut-ins

Los cut-ins son el efecto **más fácil de detestar** y el más fácil de caer en la
tentación de usar siempre. Señales de que hay que podarlos:

- El jugador deja de **mirar** el cut-in porque ya lo conoce.
- El combate se siente **interrumpido** en lugar de intenso.
- El jugador **no muere** durante un cut-in y lo nota (deja de tener tensión).

Prioridad si hay que elegir: **el juego sin cut-ins tiene que ser divertido.**
Los cut-ins son la cereza, nunca el pastel.

---

## 12. Controles de diseño (anti-feature-creep)

Decisiones tomadas para cerrar puertas:

- ❌ **Sin tienda entre niveles.** Rompe el ritmo de una run.
- ❌ **Sin más de 3 armas.** La elección debe ser real.
- ❌ **Sin metroidvania / mapa libre.** Es un arcade de avance, no exploración.
- ⚠️ **Modo: Single Player (1P) O Co-op local (2P) — PENDIENTE DE DECIDIR.** 
  Posibles: 1P solo, o 2P co-op pantalla compartida. 4P descartado por alcance de demo. Ver §12.1
- ❌ **Sin guardado a mitad de nivel.**
- ❌ **Sin subida de dificultad por repetición.** La dificultad es fija y se
  aprende; el jugador progresa en *habilidad*, no en un multiplicador.

### 12.1 Modo de juego — Single Player vs Co-op 2P

**Propuesta (para discusión):**

| Opción | Ventajas | Desventajas |
|---|---|---|
| **A) Solo Single Player** | Enfoque puro, ritmo controlado, fácil para demo, menos balance | Menor rejugabilidad social, pierde potencial arcade |
| **B) Co-op local 2P (pantalla compartida)** | Arcade clásico tipo *X-Men*, *Shadows of the Damned* estilo beat'em up, más divertido para mostrar | Balance de horda (doble daño, doble salud efectiva), cámara vertical complica compartir, 2 rutas deben ajustarse (§4.4) |
| **C) Ambos** | Máxima flexibilidad | Más scope |

**Recomendación:** **B) Co-op 2P local + modo 1P**. Justificación:

- **Arcade de salón.** NPAD es beat 'em up de dos botones; co-op 2P le da carácter.
- **Pantalla compartida vertical.** En vertical el jugador sube (§4.1). Cámara fija con margen amplia, zoom ligero cuando se separan (máx 1.5x de distancia).
- **Balance simple:** multiplicar horda por 1.5x, vida jefes +25%, sin multiplicadores exponenciales.
- **4 personajes + 2P = rejugabilidad.** Eligen personajes distintos, builds distintas.

**Restricciones:**

- **Máx 2 jugadores.** 3-4 complica vertical y HUD. Demo: 1P o 2P.
- **Local (WiFi/compartido no online)**: "por WiFi se conecten" pero para v0 **local** primero.
- **Misma run, mismo mapa compartido (§4.4).** Sin niveles separados.
- **Sin PvP.** Solo co-op.

> Decisión pendiente: empezar 1P, añadir 2P tras hito 4.

---

## 13. Técnica

**Motor: Godot 4 + C#**

- Aprovecha el C#/.NET del programador.
- Iteración rápida con F5, debugger decente, exporta a Windows/web/móvil.
- **2D puro**, decisión cerrada (§7.0). Sin 3D, sin motor físico.

Estructura propuesta:

```
/game
  /player        movimiento, dash, daño, i-frames
  /weapons       cadenas de ataque, fusión, aplicación de stats
  /relics        hooks de pasiva (sin ifs en el código base)
  /enemies       arquetipos, IA, telegrafía
  /waves         generador de recuento, puertas
  /bosses        máquina de estados y fases
  /feel          hitstop, timescale, shake, flashes, audio
  /cutins        secuencias de cut-in + shader de pantalla
  /ui            HUD, menús, run summary
```

**Principio de arquitectura importante:** las reliquias deben implementarse como
**hooks** en el motor (`OnDash`, `OnKill`, `OnDamageDealt`), nunca como
`if (tieneReliquiaX)` repartidos por el código. Si al final hay 40 reliquias,
el proyecto sigue legible.

**El `time-scale` va en un único servicio**, no repartido por el sistema de
combate (§11.1). Un único punto que decide la escala del frame. Si cada sistema
puede pedir cámara lenta, se desincronizan y el juego se siente roto.

**Resolución y target — corregido en rev. 3**

> La rev. 2 fijaba 480×270 y justificaba la decisión con "854x480 de la
> referencia". **Era inventado.** La referencia entrega capturas a 1920×1080 y
> su requisito declarado es GTX 960 (§0).

| Parámetro | Valor |
|---|---|
| **Resolución de render** | **1920×1080**, escalado a ventana |
| **Target de frame** | **60 fps** estables (§7.1.1) |
| **Suelo de hardware** | **GTX 960 / 4 GB** — el mismo listón que la referencia |
| Sprites de personaje | 48×48 de origen, **24 px de alto en pantalla** (§7.2) |
| Canvas 2D o GPU | A decidir en el hito 2; no bloquea el hito 0 |

**Por qué importa y no es un detalle:** 480×270 habría significado pixel art
grueso y un presupuesto de relleno imposible para la densidad de horda que pide
§4.3. El error no era cosmético: cambiaba el tipo de juego que se podía hacer.

> **Hito 0 se mide en `assets/game.js`** (960×540, formas planas, sin assets) y
> solo sirve para responder "¿se siente bien el dash?" (§15). Su resolución no
> dice nada sobre el juego final.

---

## 14. Nombre — DECIDIDO

> # Nippon Post-Apocalyptic Disaster
> ### N.P.A.D.

**Decidido y cerrado (rev. 3, 2026-10-02).** No se vuelve a abrir.

Título corto (**NPAD**) para logo, splash screen y nombre de archivo. El largo
para la ficha de Steam y la caja.

**Nota sobre la grafía:** el nombre ha pasado por *Disaster* y ahora es
***Disaster***. En un nombre propio esto importa y hay que decirlo claro: se
busca en tiendas, se registra como marca y aparece escrito en la calle. Un
nombre mal escrito no se encuentra. La forma que se imprime es
**Post-Apocalyptic Disaster**, con una sola "p" en *Apocalyptic* y
**Disaster** completo.

### 14.1 Por qué "Nippon" — riesgo aceptado

> **Decisión tomada, riesgo anotado.** El juego **ocurre en Japón** (Kantō, §2.1),
> así que el nombre es coherente con el mundo y no es una etiqueta pegada encima.
> La consecuencia es que el mundo tiene que ser japonés de verdad, no decorado:
> nombres, Señalética, idioma en los carteles, la estructura administrativa de un
> desastre que sigue teniendo número de edificio.

Se acepta el riesgo siguiente y queda documentado para no perderlo de vista:

- "Nippon" en el **título** es marketing, y marca el producto como contenido
  exótico antes de que nadie lo haya jugado. Dentro de la ambientación suma; en
  la portada cuesta. Se asume.
- Las políticas de contenido por región de la tienda destino pueden cambiar. Hay
  que releerlas antes de publicar (§14.3).

### 14.2 Alternativas descartadas

Se conservearon durante la discusión porque son las que mantienen las siglas. Ya
no están sobre la mesa, pero se dejan por si el nombre se replanteara alguna vez:

| Nombre | Siglas | Notas |
|---|---|---|
| **N**uclear **P**rotocol **A**ftermath **D**awn | NPAD | Post-nuclear puro. Sin país, sin marca ajena |
| **N**eo **P**an **A**xis **D**awn | NPAD | Clásico, pequeño, fácil de recordar |
| **N**ihil **P**andemonium **A**nd **D**ust | NPAD | El más agresivo del set |

> Nota de por qué las siglas valen tanto: **"Post-Apocalyptic Disaster" es un
> descriptor de género, no un título distintivo.** Nadie busca "post apocalyptic
> destruction game". Lo que hace único al producto son las cuatro letras. Por
> eso van en portada y no solo en el nombre largo.

### 14.3 Verificación antes de imprimir

Tarea de producción, no de diseño. Pendiente:

- [ ] Buscar el nombre en Steam, itch.io, Google, y registro de marcas
- [ ] Comprobar disponibilidad de dominio
- [ ] Confirmar que las siglas NPAD no colisionan con nada existente
- [ ] Releer la política de contenido por región vigente de la tienda destino

> Las cuatro se hacen en diez minutos y evitan un rediseño de logo completo.

---

## 15. Hitos

| # | Hito | Prueba de éxito |
|---|---|---|
| 0 | **Sensación base** — rectángulo en pantalla, mover + dash + i-frames | El dash se siente bien. **Si no, no seguir.** |
| 1 | **Núcleo** — 1 arma (espada), 1 enemigo, puerta por recuento | Un bucle de 90 s se siente completo |
| 2 | **Vertical slice** — 3 armas, fusión, 4 enemigos, 1 jefe, Ruptura + cut-in | 5 minutos jugables de principio a fin |
| 3 | **Meta** — reliquias, Hub, run summary | El jugador elige replay por una build concreta |
| 4 | **Los 6 niveles** — Vestíbulo, Market Roto, Refinería, Archivo, Clínica, Núcleo + sus subjefes y jefes (§4.2), cartas por nivel (§5.2), mapas compartidos con 2 rutas (§4.4) | Run completa jugable de principio a fin |
| 5 | **Pulido + cinematográficas** — cinemáticas pre/post-subjefe/jefe (§4.6), transiciones de piso (§4.5), i18n (§7.4) | Listo para enseñar a gente |

**Nota de desarrollo (2026-10-02):** cuando se programe, **empezar desde 0**.
Reutilizar únicamente lo ya probado que no contradiga este documento. No llevar
hacia adelante código que asume decisiones revocadas (p.ej., KeyE como tercer
botón, 4 niveles, recuento estático o resolución 480×270). Ver el estado del
prototipo en `../../../game.js` (`game.js:288`, `game.js:374`) como **referente de
bugs**, no como base a preservar.

**Estado real a 2026-10-02:** el hito 0 está **a medias**. `assets/game.js`
tiene mover, dash, i-frames, 3 arquetipos y recuento de oleada, pero **no tiene
hitstop, ni racha, ni time-scale, ni knockback** — es decir, nada de §11, que es
la mitad de la definición de "el dash se siente bien". El bug conocido de doble
conteo de bajas (`game.js:288` y `game.js:374`) hace que las oleadas avancen al
doble de velocidad. Hito 0 **no está cerrado**.

---

## 16. Riesgos

| Riesgo | Impacto | Mitigación |
|---|---|---|
| **El dash no se siente bien** | Crítico | Hito 0 aislado. Iterar solo eso primero |
| **Ilegibilidad de las hordas** | Crítico | Regla de silueta + test con 5 personas que no han visto el juego |
| **La cámara lenta arruina el ritmo** | **Crítico** | Escala por racha, nunca por golpe (§11.1). Time-scale en un solo servicio (§13) |
| **Los cut-ins cansan** | Alto | Presupuesto estricto (§11.4). Interruptor para desactivarlos |
| **Personajes copiados de IP existente** | Alto | Personajes 100% originales (§7.2) |
| **Pixel art fluido cuesta tiempo** | Medio | Placeholders geométricos hasta que el juego sea divertido |
| **Voz japonesa depende de terceros** | Alto | Es la única decisión con dependencia externa (§7.4.4). Localizar primero o confirmar presupuesto antes de compromise |

#### 16.1 Sobre parecerse a la referencia

El riesgo era real y la rev. 2 lo esquivaba inventando una vertical con OVA
administrativo para diferenciarse. **La rev. 3 asume el parecido de frente:** la
referente es un beat 'em up de dos botones y NPAD también, así que la forma de
jugar se va a parecer en el primer minuto. No hay forma de evitarlo sin romper el
género.

Lo propio de NPAD, y donde tiene que estar la diferencia:

| Diferencia propia | Dónde |
|---|---|
| **Niveles verticales** con el dash como salto (§3.4) | Geometría del nivel |
| **El dash recarga con las bajas** y es la barra de poder (§3.2, §3.6) | Economía del recurso |
| **Los cuatro personajes cambian la física del dash**, no sus números (§3.9) | Decisión de run |
| **El impacto escala con la racha** (§11.3) | Sensación |
| **Voz japonesa con subtítulo a elegir** (§7.4) | Presentación |
| **Paleta desaturada con el saturado reservado a peligro** (§7.1) | Lectura |

> Si un jugador que conoce la referencia no puede distinguir NPAD en una
> captura, el problema está en esa tabla, no en la cámara.

---

## 17. Decisiones abiertas

### Cerrado

**Rev. 5 (2026-10-02) — nivel, heroes y especial:**

- [x] **El jugador avanza: nunca se planta** (§4.1)
- [x] **Subjefe a mitad de piso, jefe al final** (§4.1.2)
- [x] **El recuento se cumple subiendo**, con horda por detrás (§4.1.3)
- [x] **Mismo mapa para los 4 héroes**, 2 rutas por tramo (§4.4)
- [x] **Las bajas dan nivel; el nivel da cartas que cambian reglas** (§5.2)
- [x] **Ruptura = barra + cinemática + diálogo especial** (§11.5, §11.8)

**Rev. 4 — cerrado:**

- [x] **1920×1080, suelo GTX 960** (§13)
- [x] **5 arquetipos**, nombres canónicos (§10)

**Rev. 3 (2026-10-02) — cerrado en esta conversación:**

- [x] **Nombre:** Nippon Post-Apocalyptic Disaster, N.P.A.D. (§14)
- [x] **Nivel vertical, no lateral** — el dash es el salto (§3.4)
- [x] **Arte híbrido** — cyberpunk con paleta OVA apagada, saturado solo para
      peligro (§7.1)
- [x] **60 fps en juego, 12 fps en cut-in** (§7.1.1)
- [x] **1920×1080, suelo GTX 960** (§13)
- [x] **6 niveles** para v0: Vestíbulo, Market Roto, Refinería, Archivo,
      Clínica, Núcleo (§4.2)
- [x] **5 arquetipos**, nombres canónicos (§10)
- [x] **Voz japonesa**, subtítulos e interfaz en español o inglés a elegir (§7.4)
- [x] **Sí hay voz en combate** — barks japoneses con presupuesto de 2 voces (§7.4.2)
- [x] **Ruptura**: barra que se llena con las bajas, **cinemática + diálogo
      especial** al dispararla (§11.5, §11.8)
- [x] **Nivel/cartas**: las bajas dan XP, el nivel da **cartas que cambian
      reglas**, nunca números (§5.2)
- [x] **Sin modal al subir de nivel**: anillo de 3 cartas en el mundo, se elige
      con dash, 2.5 s, sin botón de confirmar (§5.2.4)
- [x] **El jugador siempre sube**: el recuento bloquea la puerta, no el
      movimiento; la horda llega por detrás (§4.1.3)
- [x] **Subjefe a mitad de piso, jefe al final** (§4.1.2)
- [x] **Los 6 mapas son los mismos para los 4 héroes**, con 2 rutas por tramo (§4.4)
- [x] **6 niveles**, 6 subjefes, 6 jefes (§4.2)

**Rev. 2 — ya cerrado:**

- [x] **2D, no 3D** — cut-ins pre-renderizados (§7.0)
- [x] **Atacar + Dash**, sin salto, 8 direcciones (§3.4)
- [x] **Los poderes no son un tercer botón** — la barra de dash es la de poder (§3.6)
- [x] **Personajes originales**, diseño propio (§7.2)
- [x] **Impacto escalado por racha**, no uniforme (§11.3)

> ⚠️ **Nota sobre el tercer botón.** La rev. 2 cierra "los poderes no son un
> tercer botón" (§3.6), pero `game.js` tiene una skill en `KeyE` con cooldown
> propio. Eso **contradice** la decisión: o se elimina `KeyE`, o la Ruptura se
> reubica como 4º golpe de la cadena (§3.5) consumiendo una carga de dash. Está
> sin resolver.

### Pendiente

- [ ] **Arma inicial**: ¿katana, daga u otra? Define la run de arranque
- [ ] **Historia**: ¿pura ambientación, o un hilo narrativo entre niveles? (recomendado: mínima, ambiental)
- [ ] **Dificultad por niveles**: ¿fija, o un escalón al final de cada uno?
- [ ] **Dificultad global**: ¿UNICA (recomendada) o 3 niveles (Fácil/Normal/Difícil)? 
  Ver §17.1 (anti-feature-creep sugiere ÚNICA)
- [ ] **Voz en combate**: ¿silencio, o los barks ya decididos en §7.4.2? — *cerrado: hay barks*
- [ ] **Cuántos barks por personaje** y quién los escribe
- [ ] **Proveedor de VO japonés** (§7.4.4) — dependencia externa
- [ ] **Canvas 2D vs GPU** para el hito 2 (§13)
- [ ] **Si la Ruptura sigue siendo `KeyE` o pasa a la cadena de ataque** (ver nota arriba)


### 7.5 Dirección musical — Cyberphunk/Phonk japonés (propuesta)

> Decisión abierta: ayer definimos **2 temas por piso** (12 temas totales) con estética **cyberphunk/phonk** con toques japoneses. Tonalidad: callejero, distópico-administrativo, con peso para hordas.

#### Referencias recomendadas (estilo objetivo)

| Canción | Artista/Referencia | Uso sugerido | Por qué |
|---|---|---|---|
| "Metamorphosis" / tipo phonk oscuro | Kordhell, Scarlxrd | General combate (oleadas densas) | Ritmo agresivo, secciona bien con hordas |
| "Murder in My Mind" estilo | Kordhell / Playaphonk | Subjefes | Build-up tenso, golpea en drops |
| "Tokyo Drift" phonk remix | DJ Smokey / SHADXWBXRN | Pisos 1-2 (Vestíbulo/Market) | Influencia japonesa/callejera |
| "Rave" / cyberphonk | Ghostface Playa, ONIMXRU | Combate sostenido | Energía alta, sin perder legibilidad |
| "NEON BLADE" | Ghostmane / WARGASM | Jefes | Industrial + distorsión, encaja con tono administrativo |
| "SCOPOLAMINE" / phonkwave | SXMPRA | Transiciones/subjefe | Atmosférico y tenso |
| "After Dark" phonk | Mr.Kitty vibes + phonk | Piso 4-5 (Archivo/Clínica) | Más claustrofóbico, creepy-institucional |
| "Devil Eyes" | ZODIVK | Oleadas finales | Intenso, buen loop |
| "Backbone" cyberphonk | Ken Carson tipo o phonkcore | Jefe final (Núcleo) | Picos brutales, cierre épico |
| "JAPANESE DRIFT PHONK" | Tima Belorusskih / varios | Introducciones/pisos | Tinte nipón directo |
| "Nightmare" phonk | Sxmpra, KUTE | Clímax | Pesado, administra energía |
| "Glory" / distorted phonk | RAIZHELL | Ruptura (Ultimate) | Ideal para el momento de corte/cinética |

#### Uso por piso (propuesta 2 canciones/piso)

| Piso | Ambiente | BGM 1 (Combate/oleadas) | BGM 2 (Subjefe/Jefe o tensión) |
|---|---|---|---|
| **P1. Vestíbulo** | Administrativo, frío | Japanese Drift Phonk (ritmo medio) | After Dark Phonk (tensión) |
| **P2. Market Roto** | Caótico, denso | Devil Eyes (loop agresivo) | Scopolamine (build-up) |
| **P3. Refinería** | Industrial, calor | Neon Blade (pesado) | Murder in My Mind (subjefe) |
| **P4. Archivo** | Claustrofóbico | Rave/Cyberphonk (sostenido) | Backbone (tenso) |
| **P5. Clínica** | Horror administrativo | Nightmare (distorsionado) | Glory (clímax) |
| **P6. Núcleo** | Apocalíptico | Backbone (progresivo) | Glory (fase 2 jefe, ruptura) |



#### 7.5.1 BGM de Menú/Título

| Título sugerido | Autor | Género | Uso |
|---|---|---|---|
| **Tokyo Underground** / estilo Japanese Phonk chill | Tima Belorusskih (estilo atmosférico) | Japanese Drift Phonk / Lo-fi Phonk | Pantalla de título, menú principal (loop suave, sin presión) |
| **Nocturne** / cyberphonk atmosférico | SXMPRA | Phonkwave / Cyberphonk | Menú/selección de personaje (tensión latente, encaja con tono administrativo) |
| **Rainfall Phonk** | Kordhell (versión atmosférica) | Dark Phonk Chill | Idle en hub (run summary, opciones) |

**Recomendación para inicio:** *Japanese Drift Phonk - Slow Edit / Tokyo Underground vibe*. Ritmo medio-lento (70–90 BPM), con pads nebulosos y chops japoneses. Transmite "torre cerrada desde hace 39 años" sin romper la energía que promete el juego.
**Aplicación al prototipo HTML/JS:** en `index.html` el menú de inicio (messageBox) debe tener música ambiente. Propuesta: cargar pista "Japanese Drift Phonk - Tokyo Underground" (instrumental, 70–90 BPM, loop seamless). Al pulsar Enter (iniciar), hacer fade-out de 0.5s y crossfade a BGM del primer piso (P1 BGM1). Esto respeta el tono híbrido cyberpunk + OVA y crea continuidad narrativa.



#### Notas de implementación (con game feel)

- **Loop seamless**: todas deben poder loopearse sin corte (combate sostenido).
- **Stems opcionales** (ideal): percusión + bass + atmos para poder **subir intensidad con la racha** (§11.3) — layering dinámico.
- **Menor prioridad en voz/lyrics**: preferir instrumentales o loops con chops japoneses/vocal chops. En combate BGM sin voces largas para no competir con barks japoneses (§7.4.2).
- **Transiciones**: crossfade suave entre oleada → subjefe (0.5–0.8s) y corte seco controlado en cinemáticas (para dar peso).
- **Energy curve**: subir BPM/intensidad con racha (no con HP enemigo). Encaja con "la agresividad recarga" (§3.2).

> **Recomendación práctica:** priorizar **instrumentales** (dark phonk/cyberphonk) para evitar líos de subtítulos/VO. Buscar referencias en YouTube/AudioLibrary/Envato Elements, Uppbeat, Soundraw o Epidemic Sound con tags: `dark phonk`, `cyberphonk`, `japanese phonk`, `phonk loop`, `dystopian industrial`.

### 7.6 Pantalla de título — Diseño gráfico (referencia)

**Referencia de arte:** `assets/title-reference.png` (screen.png de "2d_anime_action_video_game_cinematic_title_splash_screen_for_npad_nippon_post") — 1376x768. **Solo referencia visual (layout)**. El prototipo actual usa `assets/title-screen.png` y un HUD minimalista en HTML/Canvas.

**Estructura del menú (decidido):**
- Título NPAD (logo)
- MENÚ PRINCIPAL: [INICIAR JUEGO] / [SELECCIONAR PERSONAJES] / [MODO DE JUEGO] / [OPCIONES] / [SALIR]
  - MODO DE JUEGO: [SINGLE PLAYER] / [CO-OP 2P] (pantalla compartida, vertical) — §12.1
- SELECCIONAR PERSONAJES: 4 héroes (Rika, Goro, Ren, Yui), siluetas distinguibles, preview animado
- OPCIONES: [IDIOMA DE TEXTO: Español · English] (§7.4), Volumen (BGM/SFX/VO), Pantalla, Controles (rebind opcional), [Saltar cinemáticas: Sí/No] (§4.6.3)

**Notas de implementación:**
- Prototipo HTML (index.html) es temporal (Hito 0). En Godot 4 se migrará a UI Theme con paleta de `game/Core/Palette.cs` (sin neon Stitch B, solo colores A).
- Música título: Japanese Drift Phonk atmosférico (§7.5.1), fade-out 0.5s al iniciar.
- El diseño gráfico de la referencia tiene movimiento/atmósfera (cinemático). Para menú interactivo se simplifica: fondo estático con parallax ligero, UI CRT con biseles duros (sin blur/shadows), legible.

### 7.7 Audio: voces, SFX y diálogos

#### Voces (personajes y enemigos)
| Tipo | Voz | Notas |
|---|---|---|
| **Héroes (Rika, Goro, Ren, Yui)** | Japonés, femenino/masculino acorde a personaje. Actuación sobria para barks (combate). | Solo japonés (§7.4). Barks cortos (0.3–0.8s). Evitar "shouts heroicos" excesivos. Enfatizar esfuerzo (dash, recibir daño). |
| **Subjefes / Jefes** | Japonés, tono administrativo/amenazante, contenido. | Más pausado en intros/outros de cinemáticas (§4.6). Menor cantidad de palabras, mayor peso. |
| **Enemigos base** | Sin voces largas. Solo gritos cortos (0.2–0.4s). | Se prioriza legibilidad sobre personalidad. Evitar crowd barks simultáneos. |

#### Efectos especiales (SFX)
| Efecto | Recomendado | Uso |
|---|---|---|
| **Dash** | Whoosh corto, aire/velocidad | Feedback inmediato. Sin reverbero |
| **Ataque (hit)** | Impacto cuerpo-acero, crisp | Diferenciar según arma (opcional) |
| **Parry/block feel** | Click metálico sutil | Legibilidad |
| **Daño recibido** | Impacto seco + cloth | No ensordecer |
| **Muerte enemigo** | Caída + impacto | Sirve para ritmo |
| **Dash-hit / Dash-attack** | Whoosh + hit combinado | Refuerza "atraviesa horda" (§3.2) |
| **Ruptura (Ultimate)** | Swell + impacto + corte | Cinemático breve (§11.5) |
| **Puerta/nivel up** | Click/servo + UI | Transiciones |
| **Hitstop feedback** | Percusión micro (silencio relativo) | Refuerza peso (§11.1) |

#### Diálogos (ja/es/en) — estructura propuesta
Crear tabla única `dialogue_table.csv` / `res://data/dialogue.json` con campos: `id, type(scene|boss_intro|boss_outro|subboss_intro|subboss_outro|epilogue|first_time), character, ja, es, en, duration_ms, skippable, priority`.

**Primeros bloques a escribir:**
- Prólogo (4 personajes) — intros minimalistas
- Intros/outros 6 subjefes + 6 jefes (12+12=24) + epílogo (1) = 25 (§4.6)
- "First time" hints (barks de habilidad nueva) — solo subtitulados cuando aplica (§7.4.2)
- Ruptura barks — nombre corto en ja + subt ES/EN opcional según timing

**Notas:** VO solo ja. Subtítulos ES/EN elegibles en título (§7.6). En combate **no** subtitular barks de ataque/daño/dash. Subtitular solo *poder* y *habilidad nueva* (§7.4.2). Máx 2 líneas, 42 chars. Katakana/romaji para nombres propios.

### 7.8 Historias por personaje (prólogo corto)

> **Idea:** al seleccionar personaje, se ve un **micro-prólogo** (sprite estático + VO) mostrando su motivo para subir el Ward. Esto da identidad sin inflar cinemáticas por run.

| Personaje | Título | Idea breve (ES) | Voz (ja) sugerida | Subt ES/EN |
|---|---|---|---|---|
| **Rika Tsukimi** — *La Hoja* | "Lo que aún queda" | Quedó atrapada buscando a alguien. Sube para cortar el bucle antes de olvidar quién era. | Femenina, contenida, resuelta (japonés nativo) | `ja: "まだ名前を覚えている。…絶対に、消させはしない。"` · `es: "Aún recuerdo su nombre... No dejaré que me lo borren."` · `en: "I still remember their name... I won't let it be erased."` |
| **Goro Arashi** — *El Yunque* | "Puerta cerrada" | Guardia del Ward. Juró que nadie más entraría. Ahora es el único que puede salir cerrando el núcleo. | Masculina, grave, áspera (japonés nativo) | `ja: "俺がこの扉を作った。最後に、俺が閉める。"` · `es: "Yo puse estas puertas. Yo las cerraré por última vez."` · `en: "I built these doors. I'll close them one last time."` |
| **Ren Hayashi** — *El Relámpago* | "Interés propio" | Entró por curiosidad. Se dio cuenta que si nadie sube, nadie saldrá. Le basta con ser el que lo intente. | Masculina, juvenil, impulsivo (japonés nativo) | `ja: "誰も行かねえなら…俺が行く。"` · `es: "Si nadie va... iré yo."` · `en: "If no one's going... I'll go."` |
| **Yui Nakamura** — *El Eco* | "Los que repiten" | Oyó a los atrapados repetir lo mismo durante años. No quiere ser otro eco. Quiere cortar la repetición. | Femenina, calmada, melancólica (japonés nativo) | `ja: "もう、誰かの残響にはなりたくない。"` · `es: "Ya no quiero ser el eco de nadie más."` · `en: "I don't want to be someone else's echo anymore."` |

**Aplicación:** al elegir personaje → 5–8s micro-cinemática (puede ser **skip** desde run 2). Usa mismo sistema VO+subtítulos (§7.4). No alarga run, añade contexto.

### 7.9 Diálogos: Subjefes y Jefes (japonés VO + subtítulos ES/EN)

> **Principio:** Todo diálogo va en **japonés** para VO. Los subtítulos se muestran en **español** o **inglés** según selección en título (§7.6). En combate solo se subtitulan *poder* y *habilidad nueva* (§7.4.2). En **intros/outros** de subjefes/jefes **sí** se subtitulan.

**Casting sugerido:** voces japonesas con tono institucional/distópico. Subjefes: fríos, burocráticos (eco de sistema). Jefes: más personales, con peso.

#### 7.9.1 Subjefes (6 pisos)

| Piso | Subjefe | Voz (ja) | Intro JA | Intro ES | Intro EN | Outro JA | Outro ES | Outro EN |
|---|---|---|---|---|---|---|---|---|
| **P1 Vestíbulo** | *RECAUDADOR* (burocracia) | Masculino, neutro, mecánico | `「受付は、既に終了しております。」` | *"La recepción ya ha finalizado."* | *"Reception has already closed."* | `「定員超過。対象を排除します。」` | *"Límite excedido. Procedo a eliminar objetivo."* | *"Capacity exceeded. Removing target."* |
| **P2 Market Roto** | *INVENTARIANTE* | Femenino, frío, monótono | `「棚卸しは、予定より延長されます。」` | *"El inventario se alargará más de lo previsto."* | *"Inventory count extended beyond schedule."* | `「欠損品、確認。処分。」` | *"Artículo dañado confirmado. Eliminación."* | *"Damaged item confirmed. Disposal."* |
| **P3 Refinería** | *SOBRECARGA* | Masculino, gutural contenido | `「圧力、許容値を超過。」` | *"Presión por encima del umbral permitido."* | *"Pressure exceeding safety threshold."* | `「緊急遮断…失敗。」` | *"Corte de emergencia... fallido."* | *"Emergency cutoff... failed."* |
| **P4 Archivo** | *ARCHIVISTA* | Femenino, susurrante, clínico | `「あなたの記録は、既に破棄候補です。」` | *"Tu expediente ya figura para su eliminación."* | *"Your file is already marked for deletion."* | `「アクセス権、剥奪。」` | *"Privilegios de acceso revocados."* | *"Access privileges revoked."* |
| **P5 Clínica** | *AUTOPSISTA* | Masculino, desapegado | `「患者番号：不明。処置を開始。」` | *"Nº de paciente: desconocido. Inicio de procedimiento."* | *"Patient ID: unknown. Commencing procedure."* | `「異常検体、廃棄対象。」` | *"Muestra anómala. Clasificada para desecho."* | *"Anomalous specimen marked for disposal."* |
| **P6 Núcleo** | *GUARDIÁN* | Masculino, grave, metálico | `「立入禁止区域。侵入者を排除。」` | *"Zona prohibida. Eliminando intruso."* | *"Restricted zone. Removing intruder."* | `「封鎖維持…不能。」` | *"Imposible mantener el sellado."* | *"Seal cannot be maintained."* |

#### 7.9.2 Jefes (6 pisos)

| Piso | Jefe | Voz (ja) | Intro JA | Intro ES | Intro EN | Outro JA | Outro ES | Outro EN |
|---|---|---|---|---|---|---|---|---|
| **P1 Vestíbulo** | *CONSERJE* | Masculino, cansado, irónico | `「誰かがまだ、上へ行くのか。」` | *"¿Todavía queda alguien que suba?"* | *"Is there still someone trying to climb?"* | `「行け。もう、俺はここで十分だ。」` | *"Ve. Yo ya he cumplido aquí."* | *"Go. I've done enough here."* |
| **P2 Market Roto** | *CAJERO* | Masculino, histérico contenido | `「値引きなんか、もうねえ。」` | *"Ya no quedan rebajas."* | *"No more discounts left."* | `「金は要らねえ…ただ眠らせてくれ。」` | *"Ya no quiero dinero... solo dormir."* | *"I don't want money anymore... just let me sleep."* |
| **P3 Refinería** | *FUNDIDOR* | Masculino, ronco, furioso contenido | `「火は、まだ燃えている。」` | *"El fuego aún arde."* | *"The fire still burns."* | `「やっと…消せる。」` | *"Por fin... puedo apagarlo."* | *"At last... I can put it out."* |
| **P4 Archivo** | *CENSORA* | Femenino, gélida, vengativa | `「歴史から消される覚悟はあるか。」` | *"¿Tienes valor para ser borrado de la historia?"* | *"Are you prepared to be erased from history?"* | `「記録の中で、自由になれ。」` | *"Sé libre, al menos en los registros."* | *"Be free, at least in the records."* |
| **P5 Clínica** | *DIRECTORA* | Femenino, serena, triste | `「私達は、延命していただけだった。」` | *"Solo prolongábamos lo inevitable."* | *"We were only delaying the inevitable."* | `「子どもたちを…頼む。」` | *"Cuida... de los que aún quedan."* | *"Please... look after those who remain."* |
| **P6 Núcleo** | *FRACTURA* | Andrógino/distorsionado (doble capa) | `「時は一つになるべきだった。」` | *"El tiempo debió ser uno solo."* | *"Time was meant to be one."* | `「裂け目を…閉じろ。」` | *"Cierra... la grieta."* | *"Close... the rift."* |

**Reglas aplicadas:** VO **100% japonés**. Subtítulos ES/EN elegibles en menú título. En combate: **solo** *poder* y *habilidad nueva* se subtitulan (§7.4.2). Intros/outros sí. Máx 2 líneas, 42 caracteres. Nombres propios no traducidos. Timing manda (§7.4.4).
