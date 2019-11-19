using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;


namespace Avance_Proyecto
{
    class Ingresar_Resultado:Program
    {
        List<string> Elementos1 = new List<string>();
        List<string> Elementos2 = new List<string>();
        Random Gol1_Random = new Random();
        Random Gol2_Random = new Random();
        Random jugador_Random = new Random();
        Random cantidad_goles1 = new Random();
        Random cantidad_goles2 = new Random();
        int goles1, goles2;
        string[] Jugador = new string[Equipos.Count];
        Tabla_posiciones tabla = new Tabla_posiciones();

        public void Añadir1(string objeto1)
        {
            Team_Read = new StreamReader($"{objeto1.ToUpper()}.txt");
            string texto;
            do
            {
                texto = Team_Read.ReadLine();

                if (texto != null)
                {
                    Elementos1.Add(texto);
                }
            } while (texto != null);
            Team_Read.Close();
        }

        public void Añadir2(string objeto2)
        {
            Team_Read = new StreamReader($"{objeto2.ToUpper()}.txt");
            string texto;
            do
            {
                texto = Team_Read.ReadLine();

                if (texto != null)
                {
                    Elementos2.Add(texto);
                }
            } while (texto != null);
            Team_Read.Close();
        }

        public void Suma(string nombre)
        {
            Players = new FileStream($"{nombre.ToUpper()}.dat", FileMode.Open, FileAccess.Read);
            brp = new BinaryReader(Players);
            Total_Goles = brp.ReadInt32() + Cantidad_Goles;
            Players.Close();
            brp.Close();
        }

        public void Lector_Archivo(string objeto)
        {
            Team_Read = new StreamReader($"{objeto.ToUpper()}.txt");
            string texto;
            do
            {
                texto = Team_Read.ReadLine();
                if (texto != null)
                {
                    for (int i = 0; i < Jugador.Length; i++)
                    {
                        Jugador[i] = texto;
                    }
                }
            } while (texto != null);
            Team_Read.Close();
        }
        public void Random()
        {
            foreach (string elemento1 in Equipos)
            {
                foreach (string elemento2 in Equipos)
                {
                    if (elemento1.ToUpper().Equals(elemento2.ToUpper()))
                    {
                        Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.Create, FileAccess.Write);
                        bwr = new BinaryWriter(Result);
                        bwr.Write("X");
                        Result.Close();
                        bwr.Close();
                    }
                    else
                    {
                        Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.Create, FileAccess.Write);
                        bwr = new BinaryWriter(Result);
                    Resultado1:
                        Gol1 = Gol1_Random.Next(0, 6);
                        if (Gol1<0)
                        {
                            Console.WriteLine("NO SE PERMITEN NÚMEROS NEGATIVOS");
                            goto Resultado1;
                        }
                        if (Gol1==0)
                        {

                        }
                        else
                        {
                            //Elegir aleatoriamente jugador del primer equipo
                            Lector_Archivo(elemento1);
                            //Cantidad de goles aleatorios anotados por el jugador
                            do
                            {
                                int posicion = jugador_Random.Next(Jugador.Length);
                                string nombre_Jugador = Jugador[posicion];
                                goles1 = cantidad_goles1.Next(0, 2);
                                Suma(nombre_Jugador);
                            } while (goles1 <= Gol1);
                        }
                        Thread.Sleep(2000);
                        Resultado2:
                        Gol2 = Gol2_Random.Next(0, 6);
                        if (Gol2<0)
                        {
                            Console.WriteLine("NO SE PERMITEN NÚMEROS NEGATIVOS");
                            goto Resultado2;
                        }
                        if (Gol2==0)
                        {

                        }
                        else
                        {
                            //Elegir aleatoriamente jugador del segundo equipo
                            Lector_Archivo(elemento2);
                            //Cantidad de goles aleatorios anotados por el jugador
                            do
                            {
                                int posicion = jugador_Random.Next(Jugador.Length);
                                string nombre_Jugador = Jugador[posicion];
                                goles2 = cantidad_goles1.Next(0, 2);
                                Suma(nombre_Jugador);
                            } while (goles2 <= Gol2);
                        }
                        tabla.Tabla_Posiciones(elemento1, elemento2);
                        bwr.Write(Gol1);
                        bwr.Write(Gol2);
                        Result.Close();
                        bwr.Close();

                    }
                }
            }
        }
        public Ingresar_Resultado()
        {
            
            Console.Clear();
            do
            {
                Console.WriteLine("1. Ingresar Resultado\n2. Generar Resultado");
                opcion = Convert.ToInt32(Console.ReadLine());
            } while (opcion<1 || opcion>2);

            if (opcion==1)
            {
                foreach (string elemento1 in Equipos)
                {
                    foreach (string elemento2 in Equipos)
                    {
                       
                        if (elemento1.ToUpper().Equals(elemento2.ToUpper()))
                        {
                            Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.Create, FileAccess.Write);
                            bwr = new BinaryWriter(Result);
                            todos = new FileStream("VS.dat", FileMode.OpenOrCreate, FileAccess.Write);
                            Write = new BinaryWriter(todos);
                            bwr.Write("X");
                            Write.Write("X");
                            todos.Close();
                            Write.Close();
                            Result.Close();
                            bwr.Close();

                        }
                        else
                        {
                            Console.Write($"{elemento1.ToUpper()} vs {elemento2.ToUpper()}:\n");
                            Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.Create, FileAccess.Write);
                            bwr = new BinaryWriter(Result);
                            todos = new FileStream("VS.dat", FileMode.OpenOrCreate, FileAccess.Write);
                            Write = new BinaryWriter(todos);
                        //Ingreso de goles del primer Equipo
                        Registro1:
                            do
                            {
                                Console.Write("Cantidad de goles para {0}: ", elemento1.ToUpper());
                                Gol1 = Convert.ToInt32(Console.ReadLine());
                                resultado = Regex.IsMatch(Gol1.ToString(), @"[a-zA-Z]");
                                Console.WriteLine();
                            } while (resultado == true);

                            //Ingreso de Jugador y cantidad de goles que anotó
                            if (Gol1<0)
                            {
                                Console.WriteLine("NO SE PERMITEN NÚMEROS NEGATIVOS");
                                goto Registro1;
                            }
                            if (Gol1==0)
                            {

                            }
                            else
                            {
                                do
                                {
                                Regresar1:
                                    Console.Clear();
                                    Console.Write("Ingresar jugador que anotó en el partido: ");
                                    Nombre_jugador = Console.ReadLine();
                                    Añadir1(elemento1);

                                    if (Elementos1.Contains(Nombre_jugador.ToUpper()))
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ingrese la cantidad de goles que anotó {0}", Nombre_jugador);
                                            Cantidad_Goles = Convert.ToInt32(Console.ReadLine());
                                            total += Cantidad_Goles;
                                            Suma(Nombre_jugador);
                                            resultado = Regex.IsMatch(Cantidad_Goles.ToString(), @"[a-zA-Z]");
                                        } while (resultado == true);
                                    }
                                    else goto Regresar1;
                                } while (total < Gol1);

                            }
                            
                            //Ingreso de goles para segundo equipo
                            Registro2:
                            do
                            {
                                Console.Write("Cantidad de goles para {0}: ", elemento2.ToUpper());
                                Gol2 = Convert.ToInt32(Console.ReadLine());
                                resultado = Regex.IsMatch(Gol2.ToString(), @"[a-zA-Z]");
                                Console.WriteLine();
                            } while (resultado == true);

                            //Ingreso de Jugador y cantidad de goles que anotó
                            if (Gol2<0)
                            {
                                Console.WriteLine("NO SE ACEPTAN NÚMEROS NEGATIVOS");
                                goto Registro2;
                            }
                            if (Gol2==0)
                            {

                            }
                            else
                            {
                                do
                                {
                                Regresar2:
                                    Console.Clear();
                                    Console.Write("Ingresar jugador que anotó en el partido: ");
                                    Nombre_jugador = Console.ReadLine();
                                    Añadir2(elemento2);
                                    if (Elementos1.Contains(Nombre_jugador.ToUpper()))
                                    {
                                        do
                                        {
                                            total = 0;
                                            Cantidad_Goles = 0;
                                            Console.Clear();
                                            Console.WriteLine("Ingrese la cantidad de goles que anotó {0}", Nombre_jugador);
                                            Cantidad_Goles = Convert.ToInt32(Console.ReadLine());
                                            total += Cantidad_Goles;
                                            Suma(Nombre_jugador);
                                            resultado = Regex.IsMatch(Gol1.ToString(), @"[a-zA-Z]");
                                        } while (resultado == true);
                                    }
                                    else goto Regresar2;
                                } while (total < Gol2);
                            }
                            tabla.Tabla_Posiciones(elemento1, elemento2);
                            bwr.Write(Gol1);
                            bwr.Write(Gol2);
                            Write.Write(Gol1); Write.Write(Gol2);
                            todos.Close();
                            Write.Close();
                            Result.Close();
                            bwr.Close();
                        }
                    }
                }
            }

            if (opcion==2)
            {
                Random();
            }
           
        }
    }
}
