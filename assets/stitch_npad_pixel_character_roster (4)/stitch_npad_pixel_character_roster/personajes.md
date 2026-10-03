# FICHA DE PERSONAJES — NPAD

> Documento de construcción visual. Complementa a `DISEÑO.md` §3.9.
> **Objetivo:** dar a un ilustrador toda la información necesaria para dibujar a
> los cuatro sin tener que preguntar nada, y para que las siluetas se
> distingan entre sí a **24 px de alto**.

> ⚠️ **Estos cuatro son personajes originales.** Los nombres son japoneses por
> coherencia con el mundo (§2.1), no referencias a ninguna serie existente.

---

## 0. Regla madre — las cuatro siluetas

En un juego de hordas (§6.1) el jugador identifica al personaje en **200 ms**.
Para que eso funcione, las cuatro siluetas **no pueden parecerse** ni en un
fotograma. Cada una tiene una marca que solo ella tiene:

| Personaje | Marca única | Se lee como... |
|---|---|---|
| **Rika** | El **haori** ondeando detrás | Una vela |
| **Goro** | El **escudo** atado a la espalda | Una puerta |
| **Ren** | Las **vendas** y el **amarillo** | Un cohete |
| **Yui** | El **moño alto** y el **trazador** | Una torre |

> Test de aceptación obligatorio: reducir el sprite a **silueta negra** de
> 24 px. Los cuatro deben seguir siendo distinguibles.

---

## 1. Parámetros técnicos comunes

| Parámetro | Valor |
|---|---|
| Resolución del sprite | **48 x 48 px** (cuerpo), se dibuja a 2x y se reduce |
| Altura en pantalla | **24 px** de alto en juego |
| Escala de píxel | 1 sprite px = 1/2 px en el lienzo de trabajo |
| Perspectiva | **3/4 lateral**, mirando a la derecha |
| Animación mínima | 4 direcciones x 4 acciones x 8 frames |
| Formato | PNG con alfa, **atlas** compartido |
| Anti-aliasing | **Prohibido** en pixel art |

> Las cifras de animación son un **mínimo de trabajo**, no un objetivo. El
> referente (Steel Maiden) transmite "tacto" con 6-12 frames por acción (§7.1).

### Paleta maestra (compartida por los cuatro)

Se reutiliza para que los cuatro parezcan del mismo juego:

| Rol | Hex | Uso |
|---|---|---|
| Sombra profunda | `#1a1420` | Contornos, fondo de pelo |
| Oscuro | `#2e2838` | Ropa secundaria |
| Medio | `#4a4258` | Ropa principal |
| Claro | `#7a7290` | Luces de ropa |
| Hueso | `#c8c0d8` | Blancos, Metales claros |
| Blanco | `#f4f0ff` | Blancos puros |
| **Peligro** | `#ff2d6f` | **Exclusivo de amenazas** (§6.3) |
| **Alerta** | `#ffc400` | **Exclusivo de premios y reliquias** |

> **Regla dura:** `#ff2d6f` y `#ffc400` **nunca** se usan en un personaje. Si
> un enemigo brilla en esos dos colores, el jugador sabe al instante que tiene
> que moverse. Si el personaje los usara, ese sistema de aviso se rompe.

---

## 2. RIKA TSUKIMI — *La Hoja*

### 2.1 Construcción

| Medida | Píxeles (a 48x48) |
|---|---|
| Altura total | 42 px |
| Altura de cabeza | 9 px |
| Ancho de hombros | 13 px |
| Ancho de cintura | 8 px |
| Largo de katana | 30 px |
| Moño alto (cuello) | +4 px sobre la cabeza |

**Proporción:** ~6 cabezas de alto. Delgada, sin volumen. Pose de guardia baja,
katana sostenida a la cadera en diagonal.

### 2.2 Paleta exclusiva

| Elemento | Hex |
|---|---|
| Pelo | `#e04a5a` (rojo apagado) |
| **Haori** | `#e8e2ee` (el más claro del elenco) |
| Yukata | `#3c3648` |
| Vendas | `#f4f0ff` |
| Piel | `#f0c8a8` |
| Hoja | `#c0d8e8` con filo `#f4f0ff` |

### 2.3 Animaciones (mínimo)

| Acción | Frames | Nota |
|---|---|---|
| Idle | 8 | Respiración + **haori ondeando** |
| Correr | 8 | El pelo y el haori van con retardo (2 frames) |
| Tajo | 6 | 3 frames de anticipación, arco de `#c0d8e8` |
| Dash-ataque | 6 | **Estela de la hoja visible**, es su firma |
| Ruptura | 12 | Corte en cruz, destello `#f4f0ff` |
| Herida | 4 | Retroceso + pelo al viento |

### 2.4 Lo que la hace única en pantalla

El **haori** es lo único en el elenco que ondea. Cuando Rika se mueve, es el
primero pixel que el ojo detecta. Por eso su peluquería es un mecanismo, no un
adorno: **es su indicador de posición en combate.**

---

## 3. GORO ARASHI — *El Yunque*

### 3.1 Construcción

| Medida | Píxeles (a 48x48) |
|---|---|
| Altura total | 44 px |
| Altura de cabeza | 7 px (pequeña, hundida) |
| Ancho de hombros | **22 px** (el doble que Rika) |
| Ancho de cintura | 18 px |
| Escudo en espalda | 14 x 20 px |
| Maza | 26 px de mango |

**Proporción:** ~5 cabezas de alto. **Cabeza hundida entre los hombros.** La
proporción es el opuesto de Rika: ella es larga y estrecha, él es corto y
ancho. A 24 px de alto, ambos ocupan el mismo sitio pero **no se parecen**.

### 3.2 Paleta exclusiva

| Elemento | Hex |
|---|---|
| Placas oxidadas | `#8a6a4a` |
| Acero viejo | `#5a5448` |
| Tela encerada | `#6a5a42` |
| Casco | `#4a4238` |
| Manos | `#d8a878` |
| Brasa del horno (guante) | `#ff8a3d` |

### 3.3 Animaciones (mínimo)

| Acción | Frames | Nota |
|---|---|---|
| Idle | 6 | **Pesado.** apenas se mueve. 2 frames por ciclo |
| Caminar | 8 | Un paso cada 4 frames. El escudo se balancea |
| Golpe de maza | 8 | **Carga visible**, arco enorme, 3 frames de anticipación |
| Dash-carga | 6 | Se agarra el suelo y arrastra. No es un dash, es una embestida |
| Ruptura | 14 | El más largo de los cuatro. Onda de `#ff8a3d` |
| Herida | 4 | **No se mueve.** El impacto se ve por la brasa, no por él |

### 3.4 Lo que la hace única en pantalla

**El escudo en la espalda.** Cuando Goro está de espaldas o en un plano medio,
se ve una silueta de 20 px de alto detrás de él que ningún otro tiene. Y el
`#ff8a3d` del guante es el único **calor** de todo el elenco en un mundo de
grises: el ojo lo detecta antes que la silueta.

---

## 4. REN HAYASHI — *El Relámpago*

### 4.1 Construcción

| Medida | Píxeles (a 48x48) |
|---|---|
| Altura total | 40 px |
| Altura de cabeza | 10 px (la mayor del elenco) |
| Ancho de hombros | 11 px |
| Largo de daga | 14 px (corta) |
| Cinta del mango | 6 px |

**Proporción:** ~4.5 cabezas de alto. **Cabeza grande**, cuerpo pequeño. Es un
niño de la estilización anime: la cabeza se lleva el 25% de la altura. A 24 px, la
cabeza es visiblemente enorme. Es lo que lo hace parecer joven.

### 4.2 Paleta exclusiva

| Elemento | Hex |
|---|---|
| Chaqueta / cinta | `#ffc400` (amarillo señalización) |
| Ropa interior | `#2a2434` |
| Vendas | `#f4f0ff` |
| Zapatillas | `#e04a5a` |
| Piel | `#f0c8a8` |
| Hojas | `#e8e2ee` |

### 4.3 Animaciones (mínimo)

| Acción | Frames | Nota |
|---|---|---|
| Idle | 8 | **Nunca quieto.** Temblor de manos visible |
| Correr | 10 | El más rápido. Ciclo de 10, no de 8 |
| Tajo doble | 6 | Dos cortes con 1 frame de separación |
| Dash | 4 | **Solo 4 frames.** Estela `#ffc400` |
| Ruptura | 10 | Remate giratorio, estela circular |
| Herida | 4 | Cae hacia atrás, se le nota la cara de sorpresa |

### 4.4 Lo que la hace única en pantalla

**El amarillo `#ffc400`.** Es el único personaje que tiene un color que no
aparece en ningún otro sitio del juego. Cuando hay que encontrarlo en una
pantalla llena, se busca el amarillo. Su problema (ser de alto contraste) es
justo su utilidad: **es el punto de referencia del elenco.**

> Nota de diseño: por eso Ren tiene la cabeza grande. El contraste de color lo
> encuentra, y la cabeza enorme confirma que es él y no un enemigo con el mismo
> tono. Nunca uses `#ffc400` en un enemigo (§1).

---

## 5. YUI NAKAMURA — *La Distancia*

### 5.1 Construcción

| Medida | Píxeles (a 48x48) |
|---|---|
| Altura total | 43 px |
| Altura de cabeza | 8 px |
| Ancho de hombros | 14 px |
| Moño alto | +5 px sobre la cabeza (el más alto) |
| Largo del rifle | 34 px |
| Cartucheras | 8 px |

**Proporción:** ~5.5 cabezas. **Erguida, con los hombros rectos y la cabeza
alta.** Moño de 5 px: es la marca que la distingue de Rika (que lleva coleta).

### 5.2 Paleta exclusiva

| Elemento | Hex |
|---|---|
| Uniforme | `#5a6472` (gris azulado) |
| Chaleco | `#3c4450` |
| Guantes | `#c8c0d8` |
| Cabello | `#8a8296` |
| Piel | `#e8c0a0` |
| **Trazador** | `#ff2d6f` (único uso en el elenco) |

### 5.3 Animaciones (mínimo)

| Acción | Frames | Nota |
|---|---|---|
| Idle | 6 | **Rígida.** No se balancea. El rifle no se mueve |
| Correr | 8 | Con el rifle **horizontal**, no al hombro |
| Disparo | 4 | 1 frame de fogonazo + retroceso del torso |
| Tele-dash | 4 | **Solo destello de entrada y salida.** Sin desplazamiento |
| Ruptura | 12 | Ráfaga, el haz `#ff2d6f` cruza la pantalla |
| Herida | 4 | Se le ve por el gesto. La única que cambia de expresión |

### 5.4 Lo que la hace única en pantalla

**El trazador `#ff2d6f` en el arma**, no en el cuerpo. Es la única excepción a la
regla de contraste del elenco: Yui es la más apagada de las cuatro y aun así se
ve, porque **el color está en lo que te mata**.

Consecuencia de juego: si ves un `#ff2d6f` volando hacia ti, sabes que viene
Yui, y sabes que lleva detrás. Esa información **solo existe si mantienes el
trazador único en ella**. Un proyectil rojo idéntico al de los enemigos la
haría ilegible (§6.2).

---

## 6. Tabla resumen

| | Rika | Goro | Ren | Yui |
|---|---|---|---|---|
| Altura | 42 | **44** | **40** | 43 |
| Hombros | 13 | **22** | 11 | 14 |
| Color clave | Pelo rojo | Brasa `#ff8a3d` | **Amarillo `#ffc400`** | Trazador `#ff2d6f` |
| Silueta | Haori | Escudo | Cabeza + vendas | Moño + rifle |
| Cifras del poder | Atraviesa y daña | Aguanta + cruza | Nunca sin dash | Alcance + teletransporte |
| Frames idle | 8 | 6 | 8 | 6 |
| Peso visual | Ligera | **Pesada** | Ligera | Media |

> ⚠️ **Revisar la coherencia de alturas.** Las cuatro deben ocupar el mismo
> espacio en pantalla por legibilidad, pero con proporciones **distintas**.
> Goro es alto Y ancho; Ren es bajo y cabeza enorme. Lo que se iguala es el
> área, no las proporciones.

---

## 7. Sobre las siluetas de los enemigos

Los enemigos **no** pueden parecerse a los personajes (§6.1). Reglas:

- Los cuatro personajes van siempre en la **mitad baja** de la pantalla
  (plataforma baja), los enemigos en la **vertical**. No se cruzan nunca.
- Ningún enemigo usa `#ffc400`, `#ff8a3d` ni `#ff2d6f`.
- Ningún enemigo tiene una marca de ropa reconocible (moño, haori, vendas).
- Los personajes **siempre tienen contorno `#1a1420` de 1 px.** Los enemigos
  también, pero los enemigos llevan contorno doble para separar la silueta.

---

## 8. Checklist antes de programar

- [ ] Silueta negra de los cuatro a 24 px: **distinguibles sin color**
- [ ] Los cuatro en el mismo espacio en pantalla (área, no proporciones)
- [ ] Ningún personaje usa los colores de peligro ni de alerta
- [ ] Cada uno tiene **una sola** marca de ropa reconocible
- [ ] Test a 5 personas sin contexto: "¿cuál es cuál?" sin fallar
- [ ] Un enemigo no se confunde con un personaje a 24 px
