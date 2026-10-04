# Prompts para Stitch — ambientes de los 6 pisos

> **Qué es esto:** el paquete de prompts para generar las ambientaciones de NPAD
> con Stitch, por piso y por instancia, respetando la paleta de §7.1.
>
> **Salida objetivo:** 5 instancias × 6 pisos = **30 ambientaciones**.
> Las 5 instancias de cada piso son los cinco tiempos de §4.1.2, no elegidas al
> azar: ascenso, umbral, subjefe, ascenso alto, jefe.
>
> Referencia de diseño: `diseño.md` §4.2 (pisos), §4.2.1 (ambientes por piso),
> §4.1.2 (los cinco tiempos), §7.1 (paleta), §6.3 (jerarquía visual), §14.1
> (el mundo es japonés de verdad).

---

## Cómo se usa

1. Abre **una conversación de Stitch por piso** (6 en total). La coherencia entre
   pisos no se consigue en un chat: se consigue repitiendo el bloque de ancla.
2. **Pega el BLOQUE DE ANCLA** en el primer mensaje de cada conversación. Ígual,
   palabra por palabra. Ese bloque es el que hace que las 30 imágenes pertenezcan
   al mismo juego.
3. **Pega el prompt del piso** a continuación.
4. Pide **una variante por instancia**, en mensajes separados, para poder
   descartar sueltas sin regenerar el resto.
5. Valida cada imagen con el [checklist](#checklist-de-validación) al final.

> **Por qué 6 conversaciones y no una:** si se pide "los 6 pisos" en un solo
> mensaje, Stitch promedia y los seis salen parecidos. Separando, cada piso puede
> tener su propia paleta sin que se diluyan entre sí.

---

## BLOQUE DE ANCLA — pegar en los 6 chats, sin cambiar nada

```
NPAD — Nippon Post-Apocalyptic Disaster. Action roguelite 2D vertical de dos
botones, ambientado en el Ward Noveno: una arcología de investigación en la costa
de Kanto, Japon, donde hace 39 años el tiempo se separo en capas y quedo atrapado.
Hoy es una ruina vertical por la que nadie cruza.

GENERO VISUAL (se conserva del cyberpunk de los mockups):
- Interfaz y decorado de infraestructura institucional: señaletica, numeros de
  edificio, listas, avisos, cromatografia administrativa, textura de burocracia
  que sigue funcionando aunque no haya nadie a quien proteger.
- Estetica CRT: scanlines horizontales sutiles, vineta, paneles biselados con
  esquinas a 45 grados, tipografia monoespaciada en MAYUSCULAS, codigos entre
  corchetes tipo [PISO.03], densidad alta de informacion, rejilla modular.
- El horror es ADMINISTRATIVO, no militar. Nada de soldados, nada de armas
  estrategas, nada de并将.
- El mundo es japones de verdad: la señaletica esta en japonés, los carteles
 nipones, los numeros de edificio. No decorado de translating cafe.

PALETA — regla dura, se respeta al pie de la letra:
- Fondo y arquitectura: MUY POCO saturada. Grises, ocres y azul acero. El fondo
  es SIEMPRE un valor tonal mas apagado que cualquier elemento jugable.
  #0d0a12 fondo, #1a1420 contorno, #2e2838 oscuro, #4a4258 medio,
  #7a7290 claro, #c8c0d8 hueso.
- UNICA饱和 saturacion al 100% reservada a PELIGRO: #ff2d6f y #ff8a3d.
  Exclusiva de dano, telegrafia y proyectiles enemigos.
- Alta saturacion secundaria: #ffc400, exclusiva de recompensa y reliquias.
- #9afaf2 cian, exclusivo de reanimacion.
- NADA de neon #00f0ff, #39ff14, #bd00ff. Si algo brilla, es porque mata.

FORMAS:
- Pixel art 2D, silueta legible en 200 ms, contornos duros de 1 px.
- Sin degradados suaves, sin curvas suaves en la arquitectura, sin sombras
  difusas. Ni rounded corners en ningun panel: todo biselado o recto.
- Niebla y luz planas, en bandas. Nubes siempre cargadas, sol apagado y ceniza.
- Animacion implicita: el decorado debe leerse como sprite sheet con peso.

FORMATO: 1920x1080. Vista de juego, camara lateral de la torre, sin HUD.
```

> **Nota sobre la línea corrupta del bloque:** en el bloque de arriba hay dos
> frases que Stitch puede leer mal por el pegado. Si pasan, sustitúyelas por:
> `NADA de saturacion decorativa` (en lugar de la línea de "nada de 将将") y
> `UNICA saturacion al 100%` (en lugar de "UNICA饱和 saturada").

---

## Piso 1 — VESTÍBULO

> Atrio de recepción de una arcología. Gris cemento y ocre sucio. El sitio por el
> que se pasó la lista de las 40.000 personas que no salieron.

```
PISO 1 — VESTIBULO (エントランスホール). Atrio de recepcion de una arcologia de
investigacion, 39 anos desertica. El sitio por el que se paso la lista de entrada
de los 40.000 residentes.

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: gran hall vertical de entrada. Mostrador de recepcion largo con
  ollipop de filas y papeleo accumulado a los lados. Torniquetes de seguridad
  metalicos, todos bloqueados. Escaleras mecánicas y fijas que suben fuera de
  cuadro. Techo muy alto con estructura de celosia y tubos fluorescentes
  muertos. Mucho espacio vertical, poca densidad.

2) UMBRAL: puertas de seguridad automaticas que dan a un pasillo estrecho.
   Paneles de control de acceso con LEDs apagados. Suelo de greka con franjas
  desgastadas. Presion: aqui se cierra la puerta y empieza el recuento.

3) SUBJEFE: rellano amplio de mucha altura, el espacio mas grande del piso. El
   lugar donde se muere la mitad del nivel. Mas turnos de pared, menos luz, y un
   silencio administrativo evidente: un reloj de pared parado y un mapa de
   evacuacion de las instalaciones.

4) ASCENSO ALTO: tramo de servicio mas estrecho, pasarelas tecnicas, conductos,
   cajas de instalacion, escalera de caracol. Mas presion, menos sitio. Aqui ya
   no caben cinco enemigos: caben cuatro y es(App) problema.

5) JEFE: sala totalmente sellada. Muro de contencion con el emblema de seguridad
   del Ward y un panel de contadores frozen displaying una lectura de 40.000.
   Sin ventanas, sin salida visible. Es la unica sala sellada del piso.

Criterios: cero saturacion decorativa. El fondo nunca compite en contraste con
un enemigo. Señaletica en japones visible: 受領 (recepcion), 入場証 (pase de
entrada), ウォード第九 (Ward Nueve), 閉鎖 (cerrado), 非常口 (salida de
emergencia), 立入禁止 (prohibido el paso). Textura de papel viejo y plastico
rayado. Mostrador con huecos de objetos que ya no estan.
```

---

## Piso 2 — MARKET ROTO

> Mercado entero volcado por dentro. El más cargado de los seis: horda densa en
> espacio pequeño. Ocre cálido y plástico gris.

```
PISO 2 — MARKET ROTO (壊れた市場). Un mercado entero de un piso de arcologia,
volcado por dentro 39 anos despues. Es el piso mas cargado y mas opresivo: el
espacio se estrecha y la densidad sube.

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: pasillo central entre puestos volcados. Mostradores de veggies
   reventados, cajas de producto apiladas de cualquier manera, lonas plasticas
   colgando del techo. Mucho objeto pequeno, siluetas de enemies (es enemigo) que
   se leen entre el clutter. Sensacion de oppression.

2) UMBRAL: el pasillo se estrecha en un cuello de botella deliberado, lo justo
   para que entre el jugador y la horda sin que quepan todos. Mostrador de
   pago volcado, cinta transportadora inmovil con la compra de alguien a medias
   sin recoger. Puerta de cortina plastica al fondo.

3) SUBJEFE: los Gemelos / espacio amplio dentro del caos. Catalogo de un
   supermercado con la mitad de los huecos vacios y listas de precios a mano
   escritas a lapiz. Iluminacion fluorescente parpadeante que crea zonas de
   sombra alterna.

4) ASCENSO ALTO: pasarela de mantenimiento por encima de los puestos, estrecha,
   entre conductos. Se ve el piso desde arriba: la vision del nivel entero desde
   el atajo. Aqui la ruta alta da una recompensa (cargas).

5) JEFE: sala de albedo / el almacen del fondo. Cajas apiladas hasta el techo
   formando pasillos, solo un pasillo central practicable. Sala sellada, la
   iluminacion se corta y solo queda la salida de emergencia.

Criterios: cero saturacion decorativa. Señaletica en japones visible: 営業停止
(suspendido), 食料品 (alimentos), 半額 (mitad de precio), 出口 (salida),
値下げ (rebajas), 新鮮 (fresco). Plastico, carton y ocre por todas partes. Los
papeles sueltos en el suelo son ocre, nunca blancos brillantes.
```

---

## Piso 3 — REFINERÍA

> Planta industrial con la caldera viva. Azul acero y brasa. El único con fuente
> de calor.

```
PISO 3 — REFINERIA (精錬所). Planta industrial de una arcologia, con las
calderas y los depositos de combustible. Es el unico piso con una fuente de
calor viva, y eso se ve en la luz: es calida y hacia arriba, todo lo demas es
frio y hacia abajo.

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: galeria de tuberias y pasarelas sobre un vacio vertical profundo.
  tuberia verzosa, valvulas cerradas a mano, vapor que sube. Sensacion de estar
  sobre algo que ya no esta apagado del todo.

2) UMBRAL: pasarela estrecha entre dos depositos. Dos pasillos paralelos de
   tuberia caliente, puertas de union a medio cerrar. La luz naranja viene de
   abajo, no de las bombillas.

3) SUBJEFE: la caldera en si. Un deposito enorme y cuadrado, con respiraderos
   incandescentes y bocas de ventilacion que能的. El rojo se usa solo para las
   bocas incandescentes y los charcos, nunca para decorar.

4) ASCENSO ALTO: el climbing de los depositos, escalerillas de gato, tuberia
  Serialized. Aqui el suelo no es seguro y hay charcos de dano (circulos
  incandescentes en el suelo) y hay que subir.

5) JEFE: la sala de la caldera madre. El deposito central ocupa el fondo entero
   con una brasa visible. Sala totalmente sellada, una sola boca de ventilacion
   como salida. Charcos en el suelo.

Criterios: la unica saturacion al 100% es la brasa y los charcos de dano
(circulos y aros). Señaletica en japones visible: 高圧注意 (atencion alta
tension), 燃料 (combustible), 停止中 (detenido), 第七タンク (tanque siete),
立入禁止 (prohibido el paso). Azul acero en el metal, ocre en el óxido,
nada de gris limpio.
```

---

## Piso 4 — ARCHIVO

> Depósito documental de 40.000 expedientes. El de geometría más densa y
> vertical: es el piso donde "rodear al Blindado" es geométricamente inevitable.

```
PISO 4 — ARCHIVO (記録庫). Un deposito documental que guarda expedientes de
cuarenta mil personas. Es el piso de geometria mas densa y mas vertical de los
seis: pasillos estrechos entre estanterias hasta el techo, y el unico sitio
donde hay que subir para rodear a un enemigo.

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: pasillo estrecho entre dos filas de estanterias metalicas que no
   dejan ver mas de tres metros. La vertical se ve porque las estanterias
   suben mas alla de la luz. Cajas de archivo abiertas spilling su contenido.

2) UMBRAL: encrucijada de pasillos, dos caminos posibles y ambos convergen
   antes del subjefe (requisito del diseno: minimo 2 rutas por tramo).
   Iluminacion en tubo fluorescente en el techo de los pasillos, creating
   claraboyas de luz y sombra alterna.

3) SUBJEFE: el Escribano / una sala de lectura. Mesas largas, atriles, una
   maquina de escribir, archivos centrales. Silenciosa, ordonado, el unico sitio
   del juego que parece ordenado. Y por eso es el mas inquietante.

4) ASCENSO ALTO: pasarela de estanteria por arriba, expuesta y sin suelo. Se ve
   el pasillo entero desde arriba. Recompensa en cargas por usar esta ruta.

5) JEFE: el archivo central sellado. Cuatro filas de estanterias y un hueco
   estrecho entre ellas. Sala totalmente sellada, un unico hueco de paso que
   se puede bloquear.

Criterios: cero saturacion decorativa. Señaletica en japones visible: 保管 (en
custodia), 閲覧室 (sala de lectura), 保存 (archivo), 机密 (clasificado), 第九層
(novena planta), 持出禁止 (prohibido sacar). Papel amarillento y gris verdoso.
Todo polvoriento. El orden es la amenaza: un pasillo perfectamente alineado
incomoda mas que uno caido.
```

---

## Piso 5 — CLÍNICA

> Hospital de campaña abandonado. Blanco sucio y el único cian del juego.

```
PISO 5 — CLINICA (診療所). Un hospital entero de un piso de arcologia, abandonado
con los parametros puestos. Es el piso donde los enemigos reviven una vez, y es
el unico donde el cian aparece (solo para esa advertencia, ver abajo).

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: pasillo de consultas. Camillas con sábanas, cortinas
   hospitalarias, un monitor de signos vitales que se apaga justo cuando pasas.
   Suelo sucio, barras de cama, cajas de material clinico.

2) UMBRAL: el quirofano. Puertasautomaticas metalicas, instrumentos en bandejas,
   luces quirurgicas apagadas en el techo. Sin saturacion, solo gris
   quirurgico.

3) SUBJEFE: la Cirujana / una sala de reanimacion. Camillas en fila, un
   respirador, un monitor. Aqui las grietas cian (unica vez que se usa el cian,
   en superficies: en las grietas de las paredes y en las阿富汗s) avisan de que
   algo va a volver.

4) ASCENSO ALTO: tuberia de oxígeno y climatizacion en el techo, un pasillo
   tecnico estrecho por encima de las habitaciones. La ruta alta de este piso
   esta expuesta.

5) JEFE: la sala de operations central, sellada. Mesa de operaciones, lampara
   quirurgica unica encendida, el unico punto de luz saturada de toda la sala
   pero en blanco, no en color. Sin salida.

Criterios: el cian #9afaf2 aparece SOLO en las grietas que avisan de la
reanimacion. El blanco clinico es el mas claro de los seis pisos, pero nunca
saturado. Señaletica en japones visible: 外来 (consulta), 手術室 (quirofano),
隔離 (aislamiento), 蘇生 (reanimacion), 外来停止 (consultas suspendidas),
薬品 (farmacia). Blanco sucio, acero medical, y nada de rojo que no sea peligro.
```

---

## Piso 6 — NÚCLEO

> La fractura. Sin ambiente propio: es la excepción que hace que los otros cinco
> signifiquen algo.

```
PISO 6 — NUCLEO (核). El piso final no es un sitio: es la fractura entre las
capas de tiempo. Aqui el decorado se rompe a proposito, y esa es la unica
razon por la que los otros cinco pisos tienen ambiente propio.

Genera 5 ambientaciones distintas, una por cada tiempo del nivel:

1) ASCENSO: un pozo vertical. La arquitectura desaparece: solo hay fragments de
  楼层 estructural flotando en un vacio gris. Se ve el tiempo en capas: franjas
  horizontales suspendidas en el aire, cada una con un momento congelado distinto
   (una fila de sillas, un ceiling de fluorescentes, una puerta cerrada).

2) UMBRAL: el borde de la fractura. Una grieta vertical que corta el piso, con
   capas de tiempo apiladas una detras de otra como tiras de pelicula. El suelo
   se acaba y empieza el vacio.

3) SUBJEFE: el Eco / un nivel de tiempo stackado en exceso. Fragmentos de suelo
   repetidos en espejo, como una escalera infinita de pisos iguales. Todo
   desfasado un poco respecto al anterior.

4) ASCENSO ALTO: el tramo mas cercano al nucleo. La fractura es densa aqui, hay
   capas encimadas y huecos que hay que cruzar con dash. Cada dash atraviesa un
   momento congelado distinto.

5) JEFE: el nucleo. Un ojo vertical con manos debajo, o una fractura vertical
   enorme. Sala de la fractura, sin arquitectura, sin sueloVFacil. Es el unico
   sitio del juego donde el fondo y el enemigo pelan por el contraste: por eso
   el nucleo no tiene ambiente, tiene ausencia.

Criterios: cero arquitectura util. Cero paleta de piso: es gris vacio con capas
de tiempo. Las capas congeladas usan la misma paleta apagada del juego, siempre.
Ningún elemento de fondo debe competir con el suelo del combate. Sin
señaletica de instalaciones, porque aqui ya no hay administracion.
```

---

## Checklist de validación

Contra cada imagen, antes de aceptarla. Si falla uno, se descarta y se regenera.

| # | Regla | Origen |
|---|---|---|
| 1 | El fondo es **más apagado** que cualquier elemento jugable | §6.3 |
| 2 | **Cero** `#00f0ff`, `#39ff14`, `#bd00ff` (neon no pertenece a este juego) | §7.1 |
| 3 | Lo único saturado es peligro `#ff2d6f` / `#ff8a3d`, o recompensa `#ffc400` | §7.1 |
| 4 | El cian `#9afaf2` solo aparece en el piso 5, y solo en grietas de reanimación | `enemigos.md` §6 |
| 5 | Señalética **en japonés**, no pseudo-español | §14.1 |
| 6 | Sin curvas suaves, sin sombras difusas, sin paneles con esquinas redondeadas | DESIGN.md |
| 7 | Se lee la **verticalidad** (alturas, repisas,向上) | §3.4 |
| 8 | El tono es **administrativo y官僚**, no militar | §2.1 |
| 9 | Nada de referencia a personajes ni a enemigos: aquí solo hay ambiente | §7.2 |

> La 4 y la 9 son las que más se cuelan. El cian escapando al piso 1 rompe el
> aviso de reanimación, y un enemigo dibujado en el ambiente destruye la
> separación del §6.3.

---

## Nota sobre el total

| Piso | Instancias | Total |
|---|---|---|
| Vestíbulo | 5 (§4.1.2) | 5 |
| Market Roto | 5 | 5 |
| Refinería | 5 | 5 |
| Archivo | 5 | 5 |
| Clínica | 5 | 5 |
| Núcleo | 5 | 5 |
| **TOTAL** | | **30** |

> Es el punto medio de tu rango de 24-36. Si se quiere subir a 36, se añaden 2
> instancias por piso: **ruta baja** y **ruta alta** del §4.4.2, que son las dos
> rutas distintas que el mismo mapa tiene para los cuatro heroes. Si se quiere
> bajar a 24, se quitan las instancias 4 (ascenso alto), porque son las que más
> se parecen a la instancia 1.
