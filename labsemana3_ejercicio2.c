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
	int cantidad=0; // cantidad de jugadores que se ingresaran
	int equipo1=0, equipo2=0; // contadores para equipos balanceados
	Jugador jg1, jg2, jg3, jg4, jg5, jg6, jg7, jg8, jg9, jg10; // 10 posibles jugadores
	
	// arreglo de punteros
	Jugador *jugadores[10] = {malloc(sizeof(jg1)), malloc(sizeof(jg2)), malloc(sizeof(jg3)), malloc(sizeof(jg4)), malloc(sizeof(jg5)),
	malloc(sizeof(jg6)), malloc(sizeof(jg7)), malloc(sizeof(jg8)), malloc(sizeof(jg9)), malloc(sizeof(jg10))};
	
	do{
		printf("Cantidad de Jugadores: ");
		scanf("%d",&cantidad);
		if (cantidad < 1 || cantidad > 10)
			printf("INGRESE VALORES ENTRE 1 Y 10");
	} while (cantidad < 1 || cantidad > 10);
	
	for (i=0; i<cantidad; i++) // ingreso de datos (nombre)
	{
		printf("---JUGADOR %d---\n",i+1);
		printf("Nombre: ");
		scanf("%s",&jugadores[i]->Nombre);
		
		// de aqui para abajo numeros random para el resto de stats
		jugadores[i]->Nivel = (rand()%100)+1;
		jugadores[i]->Equipo = (rand()%2)+1;
		
		if (equipo1 > cantidad/2) // comprueba que haya misma cantidad de jugadores en cada equipo
			jugadores[i]->Equipo = 2;
		
		if (jugadores[i]->Equipo == 1) // contador de jugadores por equipo
			equipo1++;
		else
			equipo2++;
		
		jugadores[i]->Salud = rand()%101;
		jugadores[i]->Ataque = (rand()%100)+1;
		jugadores[i]->Puntaje = rand()%101;
	}
	
	printf("\n\n");
	
	for (i=0; i<cantidad; i++) // imprime todos los jugadores
	{
		printf("---JUGADOR %d---\n",i+1);
		printf("Nombre: %s\n",jugadores[i]->Nombre);
		printf("Nivel: %d\n",jugadores[i]->Nivel);
		printf("Equipo: %d\n",jugadores[i]->Equipo);
		printf("Salud: %d\n",jugadores[i]->Salud);
		printf("Ataque: %d\n",jugadores[i]->Ataque);
		printf("Puntaje: %d\n",jugadores[i]->Puntaje);
	}
	
	return 0;
}
