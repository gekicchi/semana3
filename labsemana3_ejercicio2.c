#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 50
int i=0;

typedef struct
{
	char Nombre[MAX];
	int Nivel;			// de 1 a 100
	int Equipo;			// 1 o 2
	int Salud;			// de 0 a 100
	int Ataque;			// de 1 a 100
	int Puntaje;
} Jugador;

int main()
{
	int cantidad=0;
	Jugador jg1={"",10,1,70,50,0}, jg2={"",12,2,60,54,0}, jg3={"",9,1,12,48,0}, jg4={"",14,2,40,60,0}, jg5={"",11,1,69,34,0},
	jg6={"",14,2,42,55,0}, jg7={"",10,1,66,12,0}, jg8={"",7,2,89,20,0}, jg9={"",98,1,100,100,100}, jg10={"",15,2,100,75,0};
	Jugador *jugadores[10] = {malloc(sizeof(jg1)), malloc(sizeof(jg2)), malloc(sizeof(jg3)), malloc(sizeof(jg4)), malloc(sizeof(jg5)),
	malloc(sizeof(jg6)), malloc(sizeof(jg7)), malloc(sizeof(jg8)), malloc(sizeof(jg9)), malloc(sizeof(jg10))};
	
	printf("Cantidad de Jugadores: ");
	scanf("%d",&cantidad);
	
	for (i=0; i<cantidad; i++)
	{
		printf("---JUGADOR %d---\n",i+1);
		printf("Nombre: ");
		scanf("%s",&jugadores[i]->Nombre);
	}
	printf("\n\n");
	
	for (i=0; i<cantidad; i++)
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
