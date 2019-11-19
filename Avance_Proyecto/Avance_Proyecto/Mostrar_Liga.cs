using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Avance_Proyecto
{
    class Mostrar_Liga:Program
    {
        public Mostrar_Liga()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Mostrar toda La Liga\n2. Mostrar un solo equipo");
                opcion = Convert.ToInt32(Console.ReadLine());
            } while (opcion<1 || opcion>2);

            if (opcion==1)
            {
                Console.Clear();
                Console.WriteLine("EQUIPOS:\n");
                foreach (string objeto in Equipos)
                {
                    Console.Write(objeto.ToUpper()+":");
                    Team_Read = new StreamReader($"{objeto.ToUpper()}.txt");
                    string texto;
                    do
                    {
                        texto = Team_Read.ReadLine();
                        if (texto!=null)
                        {
                            Console.Write(texto+"\t");
                        }
                    } while (texto!=null);
                    Console.WriteLine();
                    Team_Read.Close();
                }
                Console.ReadKey();
            }
            if (opcion==2)
            {
            Repetir:
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del equipo");
                Nombre_equipo = Console.ReadLine();
                if (Equipos.Contains(Nombre_equipo.ToUpper()))
                {
                    Team_Read = new StreamReader($"{Nombre_equipo.ToUpper()}.txt");
                    string texto;
                    Console.Clear();
                    Console.Write(Nombre_equipo.ToUpper()+": ");
                    do
                    {
                        texto = Team_Read.ReadLine();
                        if (texto!=null)
                        {
                            Console.Write(texto+"\t");

                        }

                    } while (texto!=null);
                    Team_Read.Close();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("EL EQUIPO QUE INGRESO NO EXISTE");
                    goto Repetir;
                }
            }
           
        }
    }
}
