#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#define MAX 50
int i=0;

typedef struct
{
	char Nombre[MAX];	// max 50 caracteres
	int Nivel;			// de 1 a 100
	int Equipo;			// 1 o 2
	int Salud;			// de 0 a 100
	int Ataque;			// de 1 a 100
	int Puntaje;		// de 0 a 100
} Jugador;

int main()
{
	srand(time(NULL));
	int cantidad=0, eleccionMenu=0, eleccionSubmenu=0;
	int equipo1=0, equipo2=0;
	int puntajeE1=0, puntajeE2=0;
	Jugador jg1, jg2, jg3, jg4, jg5, jg6, jg7, jg8, jg9, jg10;
	
	// arreglo de 10 punteros
	Jugador *jugadores[10] = {malloc(sizeof(jg1)), malloc(sizeof(jg2)), malloc(sizeof(jg3)), malloc(sizeof(jg4)), malloc(sizeof(jg5)),
	malloc(sizeof(jg6)), malloc(sizeof(jg7)), malloc(sizeof(jg8)), malloc(sizeof(jg9)), malloc(sizeof(jg10))};
	
	do{
		printf("Cantidad de Jugadores por Equipo: ");
		scanf("%d",&cantidad);
		if (cantidad < 1 || cantidad > 5)
			printf("INGRESE VALORES ENTRE 1 Y 5");
	} while (cantidad < 1 || cantidad > 5);
	
	cantidad*=2;
	
	for (i=0; i<cantidad; i++) // recibe el nombre de cada jugador, genera aleatoriamente el resto de stats
	{
		printf("---JUGADOR %d---\n",i+1);
		printf("Nombre: ");
		scanf("%s",&jugadores[i]->Nombre);
		
		jugadores[i]->Nivel = (rand()%100)+1;
		jugadores[i]->Equipo = (rand()%2)+1;
		
		if (jugadores[i]->Equipo == 1)
			equipo1++;
		else
			equipo2++;
		
		if (equipo1 > cantidad/2)
		{
			jugadores[i]->Equipo = 2;
			equipo1--;
			equipo2++;
		}
			
		jugadores[i]->Salud = rand()%101;
		jugadores[i]->Ataque = (rand()%100)+1;
		jugadores[i]->Puntaje = (rand()%101);
	}
	printf("\n\n");
	do{
		printf("-----MENU-----\n");
		printf("[1] Ver Estadisticas\t[2] Actualizar Estadisticas\n");
		printf("[3] Determinar Ganador\t[4] Salir\n");
		do{
			printf("Eleccion: ");
			scanf("%d",&eleccionMenu);
			if (eleccionMenu < 1 || eleccionMenu > 4)
				printf("INGRESE VALORES ENTRE 1 Y 4");
		} while (eleccionMenu < 1 || eleccionMenu > 4);
		
		switch (eleccionMenu)
		{
			case 1:
				printf("Que Jugador Quiere Ver?\n");
				do{
					printf("Jugador: ");
					scanf("%d",&eleccionSubmenu);
					if (eleccionSubmenu < 1 || eleccionSubmenu > cantidad);
						printf ("INGRESE VALORES ENTRE 1 Y %d",cantidad);
				} while (eleccionSubmenu < 1 || eleccionSubmenu > cantidad);
				
				printf("---JUGADOR %d---\n",eleccionSubmenu);
				printf("Nombre:  %s\n",jugadores[eleccionSubmenu-1]->Nombre);
				printf("Nivel:   %d\n",jugadores[eleccionSubmenu-1]->Nivel);
				printf("Equipo:  %d\n",jugadores[eleccionSubmenu-1]->Equipo);
				printf("Salud:   %d\n",jugadores[eleccionSubmenu-1]->Salud);
				printf("Ataque:  %d\n",jugadores[eleccionSubmenu-1]->Ataque);
				printf("Puntaje: %d\n",jugadores[eleccionSubmenu-1]->Puntaje);

				break;
				
			case 2:
				printf("Que Jugado Modificara?\n");
				do{
					printf("Jugador: ");
					scanf("%d",&eleccionSubmenu);
					if (eleccionSubmenu < 1 || eleccionSubmenu > cantidad)
						printf("INGRESE VALORES ENTRE 1 Y %d",cantidad);
				} while (eleccionSubmenu < 1 || eleccionSubmenu > cantidad);
				
				printf("---JUGADOR %d---\n",eleccionSubmenu);
				printf("Nombre: ");
				scanf("%s",&jugadores[eleccionSubmenu-1]->Nombre);
				
				do{
					printf("Nivel: ");
					scanf("%d",&jugadores[eleccionSubmenu-1]->Nivel);
					if (jugadores[eleccionSubmenu-1]->Nivel < 1 || jugadores[eleccionSubmenu-1]->Nivel > 100)
						printf("INGRESE VALORES ENTRE 1 Y 100");
				} while (jugadores[eleccionSubmenu-1]->Nivel < 1 || jugadores[eleccionSubmenu-1]->Nivel > 100);
				
				do{
					printf("Salud: ");
					scanf("%d",&jugadores[eleccionSubmenu-1]->Salud);
					if (jugadores[eleccionSubmenu-1]->Salud < 1 || jugadores[eleccionSubmenu-1]->Salud > 100)
						printf("INGRESE VALORES ENTRE 1 Y 100");
				} while (jugadores[eleccionSubmenu-1]->Salud < 0 || jugadores[eleccionSubmenu-1]->Salud > 100);
				
				do{
					printf("Ataque: ");
					scanf("%d",&jugadores[eleccionSubmenu-1]->Ataque);
					if (jugadores[eleccionSubmenu-1]->Ataque < 1 || jugadores[eleccionSubmenu-1]->Ataque > 100)
						printf("INGRESE VALORES ENTRE 1 Y 100");
				} while (jugadores[eleccionSubmenu-1]->Ataque < 1 || jugadores[eleccionSubmenu-1]->Ataque > 100);
				
				do{
					printf("Puntaje: ");
					scanf("%d",&jugadores[eleccionSubmenu-1]->Puntaje);
					if (jugadores[eleccionSubmenu-1]->Puntaje < 1 || jugadores[eleccionSubmenu-1]->Puntaje > 100)
						printf("INGRESE VALORES ENTRE 1 Y 100");
				} while (jugadores[eleccionSubmenu-1]->Puntaje < 0 || jugadores[eleccionSubmenu-1]->Puntaje > 100);
				
				break;
				
			case 3:
				puntajeE1 = 0;
				puntajeE2 = 0;
				
				for (i=0; i<cantidad; i++) // hace un recuento de puntaje
				{
					if (jugadores[i]->Equipo == 1 && jugadores[i]->Salud > 0)
						puntajeE1 += jugadores[i]->Puntaje;
					else if (jugadores[i]->Equipo == 2 && jugadores[i]->Salud > 0)
						puntajeE2 += jugadores[i]->Puntaje;
				}
				
				// resultados del supuesto combate
				if (puntajeE1 > puntajeE2)
					printf("\nEQUIPO 1 HA GANADO EL COMBATE\n");
				else if (puntajeE2 > puntajeE1)
					printf("\nEQUIPO2 HA GANADO EL COMBATE\n");
				else
					printf("\nSE HA PRODUCIDO UN EMPATE\n");
				break;
				
			case 4:
				printf("\n\nADIOS!\n\n");
				break;
		}
		
	} while (eleccionMenu != 4);
	
	return 0;
}
