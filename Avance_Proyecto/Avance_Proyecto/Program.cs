using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Avance_Proyecto
{
    class Program
    {
        //Variables Gestionar Equipos
        public static List<string> Equipos = new List<string>();
        public static string Nombre_equipo;
        public static StreamWriter Team;
        public static StreamReader Team_Read;
        public static FileStream Datos_Equipo1;
        public static BinaryWriter bwe1;
        public static BinaryReader bre1;
        public static FileStream Datos_Equipo2;
        public static BinaryWriter bwe2;
        public static BinaryReader bre2;

        // Variables Gestionar Jugadores
        public static List<string> Jugadores = new List<string>();
        public static string Nombre_jugador, posicion;
        public static int cantidad;
        public static FileStream Players;
        public static BinaryWriter btp;
        public static BinaryReader brp;
        public static int Total_Goles;

        //Variables Ingresar Resultados
        public static FileStream Result;
        public static BinaryWriter bwr;
        public static BinaryReader br;
        public static int Cantidad_Goles,Gol1,Gol2,total=0;
        public static FileStream todos;
        public static BinaryWriter Write;
        public static BinaryReader Read;


        //Variables Tabla de Posiciones
        public static int PJ1, PG1, PE1, PP1, GF1, GC1, DG1, P1 = 0;
        public static int PJ2, PG2, PE2, PP2, GF2, GC2, DG2, P2 = 0;

        //Variables generales
        public static int opcion,Contador=0;
        public static Boolean resultado;


        static void Main(string[] args)
        {
            Menu opciones = new Menu();
        }
    }
}
