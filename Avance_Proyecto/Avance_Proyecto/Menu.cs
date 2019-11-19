using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Avance_Proyecto
{
    class Menu:Program
    {
        public int menu;

        public Menu()
        {
        Ingresar:
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("MENÚ\n1. Gestionar Equipos\n2. Gestionar Jugadores\n3. Mostrar Liga" +
                        "\n4. Ingresar Resultado\n5. Tabla de Resultados\n6. Tabla de posiciones");
                    menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Gestionar_Equipos equipos = new Gestionar_Equipos();
                            break;
                        case 2:
                            Gestionar_Jugadores jugador = new Gestionar_Jugadores();
                            break;
                        case 3:
                            Mostrar_Liga liga = new Mostrar_Liga();
                            break;
                        case 4:
                            Ingresar_Resultado result = new Ingresar_Resultado();
                            break;
                        case 5:
                            
                            break;
                        case 6:
                            Tabla_posiciones posicion = new Tabla_posiciones();
                            posicion.Imprimir();
                            
                            break;
                    }
                } while (menu != -1);
            }
            catch (Exception)
            {

                goto Ingresar;
            }
            
                
        }
    }
}
