// Matías Oyarzún Correa | 21.217.749-0
using System;

namespace labsemana3_ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int eleccionMenu=0, eleccionSubMenu=0, eleccionEquipo=0; // cosas de menus
            int cantidad=0, turnos=0, puntajeEquipo1=0, puntajeEquipo2=0; // utiles en combate y relacionadas a jugadores
            int equipo1=0, equipo2=0; // contador de jugadores por equipo
            Random rd = new Random(); // numeros random
            List<Jugador> JugadoresEquipo1 = new List<Jugador>(){}; // almacena los jugadores del equipo 1
            List<Jugador> JugadoresEquipo2 = new List<Jugador>(){}; // almacena los jugadores del equipo 2

            Console.WriteLine("Bienvenido a la demo de combates.");
            Console.WriteLine("Primero ingrese cuantos jugadores habra por equipo. (max.5)");
            do{
                Console.Write("Cantidad: ");
                cantidad = Convert.ToInt32(Console.ReadLine());
                if (cantidad < 1 || cantidad > 5)
                    Console.WriteLine("INGRESE VALOR ENTRE 1 Y 5");
            } while (cantidad < 1 || cantidad > 5);
            cantidad *= 2;

            Console.WriteLine("Gracias. Ingrese ahora los nombres de cada jugador.");
            for(int i=0; i<cantidad; i++) // pidiendo nombres para los jugadores
            {
                Jugador jg = new Jugador();
                Console.WriteLine($"---JUGADOR {i+1}---");
                Console.Write("Nombre: ");
                jg.Nombre = Console.ReadLine();
                
                // generando estadisticas aleatorias
                jg.Nivel = rd.Next(50,101);
                jg.Salud = 500;
                jg.Ataque = rd.Next(75,126);
                jg.Defensa = rd.Next(75,126);
                jg.Puntaje = 0;
                jg.Equipo = rd.Next(1,3);
                // contadores de cada equipo
                if (jg.Equipo == 1)
                    equipo1++;
                else if (jg.Equipo == 2)
                    equipo2++;
                
                // se asegura que ambos equipos tengan la misma cantidad de jugadores
                if (equipo1 > cantidad/2)
                {
                    jg.Equipo = 2;
                    equipo1--;
                    equipo2++;
                }
                else if (equipo2 > cantidad/2)
                {
                    jg.Equipo = 1;
                    equipo2--;
                    equipo1++;
                }

                // meten a cada jugador a su lista de equipo indicada
                if (jg.Equipo==1)
                    JugadoresEquipo1.Add(jg);
                else
                    JugadoresEquipo2.Add(jg);
                
                Console.WriteLine("JUGADOR CREADO");
            }

            Console.WriteLine("Bien. Ahora le presentaremos el menu principal");
            do{
                Console.WriteLine("-----------------MENU-----------------");
                Console.WriteLine("[1] Comenzar Batalla\t[2] Ver Jugador");
                Console.WriteLine("[3] Modificar Jugador\t[4] Salir");
                do{
                    Console.Write("Eleccion: ");
                    eleccionMenu = Convert.ToInt32(Console.ReadLine());
                    if (eleccionMenu < 1 || eleccionMenu > 4)
                        COnsole.WriteLine("INGRESE VALORES ENTRE 1 Y 4");
                } while (eleccionMenu < 1 || eleccionMenu > 4);
                
                Console.Write("\n\n");

                switch (eleccionMenu)
                {
                    case 1: // Comenzar Batalla
                        Console.WriteLine("---------------------------------------REGLAS---------------------------------------");
                        Console.WriteLine("- Usted decide la cantidad de turnos que durara el combate.(max.10)");
                        Console.WriteLine("- Solo puede atacar a oponentes con +1 de vida.");
                        Console.WriteLine("- Al atacar hay un 75% de probabilidad de acertar.");
                        Console.WriteLine("- Derrotar a un oponente concede una cantidad de 100*(nivel) puntos de experiencia");
                        Console.WriteLine("- El daño es definido como (ataque propio*1.5)-(defensa rival*0.66)");
                        Console.WriteLine("------------------------------------------------------------------------------------");

                        Console.WriteLine("\nCuantos turnos durara el combate?(max.10)");
                        do{
                            Console.Write("Turnos: ");
                            turnos = Convert.ToInt32(Console.ReadLine());
                            if (turnos < 1 || turnos > 10)
                                Console.WriteLine("INGRESE VALORES ENTRE 1 Y 10");
                        } while (turnos < 1 || turnos > 10);

                        for (int i=0; i<JugadoresEquipo1.Count; i++) // todos los jugadores comienzan con 500 de vida y 0 puntos de experiencia
                        {
                            JugadoresEquipo1[i].Salud = 500;
                            JugadoresEquipo2[i].Salud = 500;

                            JugadoresEquipo1[i].Puntaje = 0;
                            JugadoresEquipo2[i].Puntaje = 0;
                        }

                        for (int i=0; i<turnos; i++)
                        {
                            int acierta=0;
                            int ataqueAcertado=0;
                            // turno equipo 1
                            Console.WriteLine($"\n---EQUIPO 1 TURNO {i+1}---");
                            for (int j=0; j<JugadoresEquipo1.Count; j++)
                            {
                                if (JugadoresEquipo1[j].Salud > 0)
                                {
                                    Console.WriteLine($"A quien atacara {JugadoresEquipo1[j].Nombre}?");

                                    for (int k=0; k<JugadoresEquipo2.Count; k++) // muestra los jugadores del equipo 2
                                        Console.Write($"[{k+1}] {JugadoresEquipo2[k].Nombre}\t");

                                    do{
                                        Console.Write("\nEleccion: ");
                                        eleccionSubMenu = Convert.ToInt32(Console.ReadLine());
                                        if (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count)
                                            Console.WriteLine($"INGRESE VALORES ENTRE 1 Y {JugadoresEquipo1.Count}");
                                    } while (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count);

                                    acierta = rd.Next(1,5); // 75% de acertar
                                    if (JugadoresEquipo2[eleccionSubMenu-1].Salud <= 0) // evita atacar a jugadores derrotados
                                        acierta = 4;
                                
                                    if (acierta != 4)
                                    {
                                        ataqueAcertado = ((JugadoresEquipo1[j].Ataque*3/2) - (JugadoresEquipo2[eleccionSubMenu-1].Defensa*2/3));
                                        JugadoresEquipo2[eleccionSubMenu-1].Salud -= ataqueAcertado;
                                        Console.WriteLine($"{JugadoresEquipo2[eleccionSubMenu-1].Nombre} ha recibido {ataqueAcertado} puntos de daño");

                                        if (JugadoresEquipo2[eleccionSubMenu-1].Salud <= 0) // concede puntos si el rival fue derrotado en el turno
                                        {
                                            JugadoresEquipo2[eleccionSubMenu-1].Salud = 0;

                                            Console.WriteLine($"{JugadoresEquipo2[eleccionSubMenu-1].Nombre} ya no puede combatir");
                                            JugadoresEquipo1[j].Puntaje += 100*JugadoresEquipo2[eleccionSubMenu-1].Nivel;
                                            Console.WriteLine($"{JugadoresEquipo1[j].Nombre} recibe {100*(JugadoresEquipo2[eleccionSubMenu-1].Nivel)} puntos de experiencia");
                                        }
                                    }
                                    else
                                        Console.WriteLine($"{JugadoresEquipo1[j].Nombre} ha fallado en atacar");
                                }
                            }

                            // turno equipo 2
                            Console.WriteLine($"\n---EQUIPO 2 TURNO {i+1}---");
                            for (int j=0; j<JugadoresEquipo2.Count; j++)
                            {
                                if (JugadoresEquipo2[j].Salud > 0)
                                {
                                    Console.WriteLine($"A quien atacara {JugadoresEquipo2[j].Nombre}?");

                                    for (int k=0; k<JugadoresEquipo1.Count; k++) // muestra los jugadores del equipo 1
                                        Console.Write($"[{k+1}] {JugadoresEquipo1[k].Nombre}\t");

                                    do{
                                        Console.Write("\nEleccion: ");
                                        eleccionSubMenu = Convert.ToInt32(Console.ReadLine());
                                        if (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo2.Count)
                                            Console.WriteLine($"INGRESE VALORES ENTRE 1 Y {JugadoresEquipo2.Count}");
                                    } while (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo2.Count);

                                    acierta = rd.Next(1,5);
                                    if (JugadoresEquipo1[eleccionSubMenu-1].Salud <= 0) // evita atacar jugadores derrotados
                                        acierta = 4;
                                    
                                    if (acierta != 4)
                                    {
                                        ataqueAcertado = ((JugadoresEquipo2[j].Ataque*3/2) - (JugadoresEquipo1[eleccionSubMenu-1].Defensa*2/3));
                                        JugadoresEquipo1[eleccionSubMenu-1].Salud -= ataqueAcertado;
                                        Console.WriteLine($"{JugadoresEquipo1[eleccionSubMenu-1].Nombre} ha recibido {ataqueAcertado} puntos de daño");

                                        if (JugadoresEquipo1[eleccionSubMenu-1].Salud <= 0) // concede puntos si el rival fue derrotado en el turno
                                        {
                                            JugadoresEquipo1[eleccionSubMenu-1].Salud = 0;

                                            Console.WriteLine($"{JugadoresEquipo1[eleccionSubMenu-1].Nombre} ya no puede combatir");
                                            JugadoresEquipo2[j].Puntaje += 100*JugadoresEquipo1[eleccionSubMenu-1].Nivel;
                                            Console.WriteLine($"{JugadoresEquipo2[j].Nombre} recibe {100*(JugadoresEquipo1[eleccionSubMenu-1].Nivel)} puntos de experiencia");

                                        }
                                    }
                                    else
                                        Console.WriteLine($"{JugadoresEquipo2[j].Nombre} ha fallado en atacar");
                                }
                            }
                        }

                        for (int i=0; i<cantidad/2; i++) // conteo de puntos de cada equipo
                        {
                            puntajeEquipo1 += JugadoresEquipo1[i].Puntaje;
                            puntajeEquipo2 += JugadoresEquipo2[i].Puntaje;
                        }

                        // resultados del combate
                        if (puntajeEquipo1 > puntajeEquipo2)
                        {
                            Console.WriteLine($"EL EQUIPO 1 HA GANADO CON UNA PUNTUACION DE {puntajeEquipo1} CONTRA {puntajeEquipo2}");
                        }
                        else if (puntajeEquipo2 > puntajeEquipo1)
                        {
                            Console.WriteLine($"EL EQUIPO 2 HA GANADO CON UNA PUNTUACION DE {puntajeEquipo2} CONTRA {puntajeEquipo2}");
                        }
                        else
                        {
                            Console.WriteLine($"HA OCURRIDO UN EMPATE, AMBOS EQUIPOS TIENEN {puntajeEquipo1} PUNTOS");
                        }

                        break;

                    case 2: // Ver Jugador
                        Console.WriteLine("A Que Equipo Pertenece el Jugador?");
                        do{
                            Console.Write("Equipo: ");
                            eleccionEquipo = Convert.ToInt32(Console.ReadLine());
                            if (eleccionEquipo != 1 && eleccionEquipo != 2)
                                Console.WriteLine("ELIJA ENTRE EL EQUIPO 1 Y 2");
                        } while (eleccionEquipo != 1 && eleccionEquipo != 2);

                        Console.WriteLine("Que Jugador Quiere Ver?");
                        do{
                            Console.Write("Jugador: ");
                            eleccionSubMenu = Convert.ToInt32(Console.ReadLine());
                            if (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count)
                                Console.WriteLine($"INGRESE VALORES ENTRE 1 Y {JugadoresEquipo1.Count}");
                        } while (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count);

                        // utilizando operador ternario para presentar las estadisticas
                        Console.WriteLine($"---JUGADOR {eleccionSubMenu}---");
                        Console.WriteLine($"Nombre:  {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Nombre : JugadoresEquipo2[eleccionSubMenu-1].Nombre)}");
                        Console.WriteLine($"Equipo:  {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Equipo : JugadoresEquipo2[eleccionSubMenu-1].Equipo)}");
                        Console.WriteLine($"Nivel:   {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Nivel : JugadoresEquipo2[eleccionSubMenu-1].Nivel)}");
                        Console.WriteLine($"Salud:   {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Salud : JugadoresEquipo2[eleccionSubMenu-1].Salud)}");
                        Console.WriteLine($"Ataque:  {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Ataque : JugadoresEquipo2[eleccionSubMenu-1].Ataque)}");
                        Console.WriteLine($"Defensa: {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Defensa : JugadoresEquipo2[eleccionSubMenu-1].Defensa)}");
                        Console.WriteLine($"Puntaje: {(eleccionEquipo==1? JugadoresEquipo1[eleccionSubMenu-1].Puntaje : JugadoresEquipo2[eleccionSubMenu-1].Puntaje)}");
                        Console.Write("\n\n");
                        break;

                    case 3: // Modificar Jugador
                        Console.WriteLine("A Que Equipo Pertenece el Jugador?");
                        do{
                            Console.Write("Equipo: ");
                            eleccionEquipo = Convert.ToInt32(Console.ReadLine());
                            if (eleccionEquipo != 1 && eleccionEquipo != 2)
                                Console.WriteLine("ELIJA ENTRE EL EQUIPO 1 Y 2");
                        } while (eleccionEquipo != 1 && eleccionEquipo != 2);

                        Console.WriteLine("Que Jugador Quiere Modificar?");
                        do{
                            Console.Write("Jugador: ");
                            eleccionSubMenu = Convert.ToInt32(Console.ReadLine());
                            if (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count)
                                Console.WriteLine($"INGRESE VALORES ENTRE 1 Y {JugadoresEquipo1.Count}");
                        } while (eleccionSubMenu < 1 || eleccionSubMenu > JugadoresEquipo1.Count);

                        Console.WriteLine($"---JUGADOR {eleccionSubMenu}---");
                        Console.Write("Nombre: ");
                        if (eleccionEquipo==1)
                            JugadoresEquipo1[eleccionSubMenu-1].Nombre = Console.ReadLine();
                        else
                            JugadoresEquipo2[eleccionSubMenu-1].Nombre = Console.ReadLine();
                        
                        // cada estadistica tiene sus propios parametros que se necesitan validar, se ve horrible lo se
                        Console.Write("(1-100)Nivel: ");
                        if (eleccionEquipo==1) 
                        {
                            do{
                                JugadoresEquipo1[eleccionSubMenu-1].Nivel = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo1[eleccionSubMenu-1].Nivel < 1 || JugadoresEquipo1[eleccionSubMenu-1].Nivel > 100)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 100");
                            } while (JugadoresEquipo1[eleccionSubMenu-1].Nivel < 1 || JugadoresEquipo1[eleccionSubMenu-1].Nivel > 100);
                        }
                        else
                        {
                            do{
                                JugadoresEquipo2[eleccionSubMenu-1].Nivel = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo2[eleccionSubMenu-1].Nivel < 1 || JugadoresEquipo2[eleccionSubMenu-1].Nivel > 100)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 100");
                            } while (JugadoresEquipo2[eleccionSubMenu-1].Nivel < 1 || JugadoresEquipo2[eleccionSubMenu-1].Nivel > 100);
                        }
                        
                        Console.Write("(1-125)Ataque: ");
                        if (eleccionEquipo==1) 
                        {
                            do{
                                JugadoresEquipo1[eleccionSubMenu-1].Ataque = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo1[eleccionSubMenu-1].Ataque < 1 || JugadoresEquipo1[eleccionSubMenu-1].Ataque > 125)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 125");
                            } while (JugadoresEquipo1[eleccionSubMenu-1].Ataque < 1 || JugadoresEquipo1[eleccionSubMenu-1].Ataque > 125);
                        }
                        else
                        {
                            do{
                                JugadoresEquipo2[eleccionSubMenu-1].Ataque = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo2[eleccionSubMenu-1].Ataque < 1 || JugadoresEquipo2[eleccionSubMenu-1].Ataque > 125)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 125");
                            } while (JugadoresEquipo2[eleccionSubMenu-1].Ataque < 1 || JugadoresEquipo2[eleccionSubMenu-1].Ataque > 125);
                        }
                        
                        Console.Write("(1-125)Defensa: ");
                        if (eleccionEquipo==1) 
                        {
                            do{
                                JugadoresEquipo1[eleccionSubMenu-1].Defensa = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo1[eleccionSubMenu-1].Defensa < 1 || JugadoresEquipo1[eleccionSubMenu-1].Defensa > 125)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 125");
                            } while (JugadoresEquipo1[eleccionSubMenu-1].Defensa < 1 || JugadoresEquipo1[eleccionSubMenu-1].Defensa > 125);
                        }
                        else
                        {
                            do{
                                JugadoresEquipo2[eleccionSubMenu-1].Defensa = Convert.ToInt32(Console.ReadLine());
                                if (JugadoresEquipo2[eleccionSubMenu-1].Defensa < 1 || JugadoresEquipo2[eleccionSubMenu-1].Defensa > 125)
                                    Console.WriteLine("INGRESE VALORES ENTRE 1 Y 125");
                            } while (JugadoresEquipo2[eleccionSubMenu-1].Defensa < 1 || JugadoresEquipo2[eleccionSubMenu-1].Defensa > 125);
                        }

                        Console.WriteLine($"JUGADOR {eleccionSubMenu} HA SIDO MODIFICADO");

                        Console.Write("\n\n");
                        break;

                    case 4: // Salir
                        Console.WriteLine("Gracias Por Probar La Demo.");
                        Console.WriteLine("ADIOS!");
                        break;
                }
            } while (eleccionMenu != 4);
        }
    }
}