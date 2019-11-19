using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Avance_Proyecto
{
    class Gestionar_Jugadores:Program
    {
        public Gestionar_Jugadores()
        {
            Console.Clear();
            if (Jugadores.Count >= 1 && Contador>=1)
            {
                do
                {
                    Console.WriteLine("MENÚ:\n1. Crear jugadores\n2. Eliminar jugadores\n3. Asignar Equipo\n4. Quitar jugador");
                    opcion = Convert.ToInt32(Console.ReadLine());


                } while (opcion < 1 || opcion > 4);
            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("MENÚ:\n1. Crear jugadores");
                    opcion = Convert.ToInt32(Console.ReadLine());
                } while (opcion != 1);

            }
            if (opcion==1)
            {
                Console.Clear();
                //Comprobar existencia del Jugador en la lista
                do
                {
                    Agregar:
                    Console.WriteLine("Nombre: ");
                    Nombre_jugador = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_jugador, @"[a-zA-Z]");
                    if (Jugadores.Contains(Nombre_jugador.ToUpper()))
                    {
                        Console.WriteLine("{0} ya existe en la lista de Jugadores");
                        goto Agregar;
                    }
                } while (resultado==false);
                //Añadir jugador a la lista "Jugadores"
                Jugadores.Add(Nombre_jugador.ToUpper());
                //Crear Archivo Binario con Nombre de nuevo jugador
                Players = new FileStream($"{Nombre_jugador.ToUpper()}.dat", FileMode.Create, FileAccess.Write);
                btp = new BinaryWriter(Players);
                do
                {
                    Console.WriteLine("Posición de {0}: ", Nombre_jugador);
                    posicion = Console.ReadLine();
                    resultado = Regex.IsMatch(posicion, @"[a-zA-Z]");
                } while (resultado==false);
                Again:
                try
                {
                     
                    Console.WriteLine("Cantidad de goles de {0}: ",Nombre_jugador);
                    cantidad = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception)
                {
                    
                    Console.WriteLine("Ingresar solo números");
                    Console.ReadKey();
                    goto Again;
                }
                btp.Write(Nombre_jugador.ToUpper());
                btp.Write(posicion.ToUpper());
                btp.Write(cantidad);
                Players.Close();
                btp.Close();
                
            }
            if (opcion==2)
            {
                do
                {
                    Pregunta:
                    Console.WriteLine("Ingrese el nombre del jugador a eliminar:");
                    Nombre_jugador = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_jugador, @"[a-zA-Z]");
                    if (Jugadores.Contains(Nombre_jugador))
                    {
                        Jugadores.Remove(Nombre_jugador);
                        File.Delete($"{Nombre_jugador.ToUpper()}.dat");
                    }
                    else
                    {
                        Console.WriteLine("El jugador ingresado NO EXISTE");
                        goto Pregunta;
                    }
                   } while (resultado==false);
            }
            if (opcion==3)
            {
                Console.Clear();
                // Comprobar si jugador existe
                do
                {
                    Jugador:
                    Console.Clear();
                    Console.WriteLine("Elija el jugador:");
                    Nombre_jugador = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_jugador, @"[a-zA-Z]");
                    if (Jugadores.Contains(Nombre_jugador.ToUpper()))
                    {
                        resultado = true;
                    }
                    else
                    {
                        Console.WriteLine("El Jugador ingresado NO EXISTE");
                        goto Jugador;
                    }
                } while (resultado == false);
                //Comprobar si equipo existe
                do
                {
                    Equipo:
                    Console.Clear();
                    Console.WriteLine("Elija el equipo para {0}", Nombre_jugador);
                    Nombre_equipo = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_jugador, @"[a-zA-Z]");
                    
                    if (Equipos.Contains(Nombre_equipo.ToUpper()))
                    {
                        foreach (string objeto in Equipos)
                        {
                            //Añadiendo Jugadores al Equipo Correspondiente
                            if (objeto.ToUpper().Equals(Nombre_equipo.ToUpper()))
                            {
                                Team = new StreamWriter($"{objeto.ToUpper()}.txt", true);
                                Team.WriteLine(Nombre_jugador.ToUpper());
                                Team.Close();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("El equipo ingresado NO EXISTE");
                        goto Equipo;
                    }
                } while (resultado == false);
              
            }

        }
    }
}
