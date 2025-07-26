# Juego de Gato

* Ingresa el número de jugadores
	* Si es 1, jugarás contra la IA **(Actualmente esta opción no es funcional)**
	* Si es 2, jugarás contra otro jugador (Usando los mismos botones de flechas (arriba, abajo, izquierda, derecha))
* El jugador 1 elige si quiere jugar con 'X' o con 'O'. Dependiendo de la elección, el jugador 2 tendrá la opción contraria elegida por el jugador 1
* La ventana de carga es para mostrar un mensaje aleatorio antes de entrar al juego y una animación de 'cargando... /', no es realmente una pantalla de carga
* El primer turno empieza de forma aleatoria, ya sea que empiece el jugador 1 o el jugador 2
	* La forma de moverse por el tablero es con las flechas del teclado arriba, abajo, izquierda y derecha para ambos jugadores
	* Para escribir tu figura en la casilla, presiona la figura que te corresponda y se escribirá en esa posición
		* Si presionas cualquier otra tecla, saldrá el mensaje de caracter no válido
		* Si presionas la figura del jugador contrario, saldrá el mensaje recordándote que juegas con 'X' o con 'O'
		* Si intentas colocar tu figura en una posición que ya está ocupada, saldrá el mensaje de posición ocupada
* Gana el jugador que logre poner las 3 figuras en línea, ya sea vertical, horizontal o diagonal
	* Muestra una animación de festejo en caso de haber ganador
	* En caso de empate, no muestra ganador
	* En ambos casos se muestra un mensaje preguntando si quieren volver a jugar
		* Si eligen 'S', volverá al inicio donde pregunta el número de jugadores
		* Si eligen 'N', muestra el mensaje '¡Gracias por jugar!' y sale del programa

Cualquier sugerencia, comentario u opinión es bienvenido ;)