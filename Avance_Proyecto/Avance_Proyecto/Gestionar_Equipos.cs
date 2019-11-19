using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Avance_Proyecto
{
    class Gestionar_Equipos : Program
    {
        public Gestionar_Equipos()
        {
            Console.Clear();
            if (Contador>=1)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("INGRESE SU OPCIÓN:\n1. Crear equipos\n2. Eliminar equipos");
                    opcion = Convert.ToInt32(Console.ReadLine());

                } while (opcion < 1 || opcion > 2);

            }
            else
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("INGRESE SU OPCIÓN:\n1. Crear equipos");
                    opcion = Convert.ToInt32(Console.ReadLine());
                } while (opcion < 1 || opcion > 1);
            }

            if (opcion==1)
            {
                
            Repetir:
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del equipo");
                    Nombre_equipo = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_equipo, @"[a-zA-Z]");
                } while (resultado == false || Nombre_equipo.Equals(null));


                if (Equipos.Contains(Nombre_equipo.ToUpper()))
               
                {
                    Console.WriteLine("Equipo ingresado YA EXISTE");
                    Console.ReadKey();
                    goto Repetir;
                }
                Contador++;
                Equipos.Add(Nombre_equipo.ToUpper());
                Console.ReadKey();
                
            }
            if (opcion == 2)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del equipo");
                    Nombre_equipo = Console.ReadLine();
                    resultado = Regex.IsMatch(Nombre_equipo, @"[a-zA-Z]");
                } while (resultado == false || Nombre_equipo.Equals(null));


                if (Equipos.Contains(Nombre_equipo.ToUpper()))
                {
                    Equipos.Remove(Nombre_equipo.ToUpper());
                    File.Delete($"{Nombre_equipo.ToUpper()}.txt");
                    Console.WriteLine("EQUIPO ELIMINADO CON ÉXITO...");
                    Contador--;
                }
                else Console.WriteLine("EL EQUIPO INGRESADO NO EXISTE");
                Console.ReadKey();
            }
        }
    }
}
