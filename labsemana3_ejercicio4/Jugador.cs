using System;

namespace labsemana3_ejercicio4
{
    class Jugador
    {
        // atributos
        private string _Nombre; // no tiene limite
        private int _Equipo;    // se elige aleatorio entre 1 y 2
        private int _Nivel;     // al generarse es entre 50 y 100, al modificar entre 1 y 100
        private int _Salud;     // se genera con 500, solo se puede modificar en combate
        private int _Ataque;    // al generarse es entre 75 y 125, al modificarse entre 1 y 125
        private int _Defensa;   // al generarse es entre 75 y 125, al modificarse entre 1 y 125
        private int _Puntaje;   // se genera con 0, solo se puede modificar en combate

        // get-sets
        public string Nombre { get{return this._Nombre;} set{this._Nombre=value;} }
        public int Equipo { get{return this._Equipo;} set{this._Equipo=value;} }
        public int Nivel { get{return this._Nivel;} set{this._Nivel=value;} }
        public int Salud { get{return this._Salud;} set{this._Salud=value;} }
        public int Ataque { get{return this._Ataque;} set{this._Ataque=value;} }
        public int Defensa { get{return this._Defensa;} set{this._Defensa=value;} }

        public int Puntaje { get{return this._Puntaje;} set{this._Puntaje=value;} }

        // constructores
        public Jugador()
        {
            this._Nombre = "AAA";
            this._Equipo = 0;
            this._Nivel = 0;
            this._Salud = 0;
            this._Ataque = 0;
            this._Defensa = 0;
            this._Puntaje = 0;
        }

        public Jugador(string nombre, int equipo, int nivel, int salud, int ataque, int defensa, int puntaje)
        {
            this._Nombre = nombre;
            this._Equipo = equipo;
            this._Nivel = nivel;
            this._Salud = salud;
            this._Ataque = ataque;
            this._Defensa = defensa;
            this._Puntaje = puntaje;
        }
    }
}