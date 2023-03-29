#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 50
int i=0;

typedef struct
{
	char Nombre[MAX];
	int Nivel;
	int Salud;
	int Puntaje;
} Jugador;

int main()
{
	Jugador jugador1={"",0,0,0}, jugador2={"",0,0,0}, jugador3={"",0,0,0};
	Jugador *jugadores[3] = {malloc(sizeof(jugador1)), malloc(sizeof(jugador2)), malloc(sizeof(jugador3))};

	for (i=0; i<3; i++)
	{
		printf("Nombre: ");
		scanf("%s",&jugadores[i]->Nombre);
		printf("Nivel: ");
		scanf("%d",&jugadores[i]->Nivel);
		printf("Salud: ");
		scanf("%d",&jugadores[i]->Salud);
		printf("Puntaje: ");
		scanf("%d",&jugadores[i]->Puntaje);
	}
	
	for(i=0; i<3; i++)
	{
		printf("---JUGADOR %d---\n",i+1);
		printf("Nombre: %s\n",jugadores[i]->Nombre);
		printf("Nivel: %d\n",jugadores[i]->Nivel);
		printf("Salud: %d\n",jugadores[i]->Salud);
		printf("Puntaje: %d\n\n",jugadores[i]->Puntaje);
	}

	return 0;
}
