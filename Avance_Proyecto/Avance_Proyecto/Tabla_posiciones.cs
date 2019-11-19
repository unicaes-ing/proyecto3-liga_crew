using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Avance_Proyecto
{
    class Tabla_posiciones:Program
    {
        public void Tabla_Posiciones(string elemento1, string elemento2)
        {
            Datos_Equipo1 = new FileStream($"{elemento1.ToUpper()}.dat", FileMode.OpenOrCreate, FileAccess.Write);
            bwe1 = new BinaryWriter(Datos_Equipo1);
            Datos_Equipo2 = new FileStream($"{elemento2.ToUpper()}.dat", FileMode.OpenOrCreate, FileAccess.Write);
            bwe2 = new BinaryWriter(Datos_Equipo2);
            PJ1++; PJ2++;
            
            if (Gol1 > Gol2)
            {
                PG1++;
                PP2++;
                P1 += 3;
            }
            
            if (Gol1 == Gol2)
            {
                PE1++; PE2++;
                P1 += 1;
                P2 += 1;
                
            }
            if (Gol1 < Gol2)
            {
                PP1++;
                PG2++;
                P2 += 3;
                
            }
            //Datos Primer Equipo
            bwe1.Write(PJ1); bwe1.Write(PG1); bwe1.Write(PE1); bwe1.Write(PP1); 
            GF1 += Gol1; GC1 += Gol2; DG1 = GF1 - GC1;
            bwe1.Write(GF1);
            bwe1.Write(GC1);
            bwe1.Write(DG1);
            bwe1.Write(P1);
            bwe1.Close();
            Datos_Equipo1.Close();
            //Datos Segundo Equipo
            bwe2.Write(PJ2); bwe2.Write(PG2); bwe2.Write(PE2); bwe2.Write(PP2);
            GF2 += Gol2; GC2 += Gol1; DG2 = GF2 - GC2;
            bwe2.Write(GF2);
            bwe2.Write(GC2);
            bwe2.Write(DG2);
            bwe2.Write(P2);
            bwe2.Close();
            Datos_Equipo2.Close();
        }
        public void Imprimir()
        {
            int izq = 10;
            int top = 3;
            Console.Clear();
            Team_Read = new StreamReader("9.txt");
            string texto = Team_Read.ReadToEnd();
            Console.WriteLine(texto);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("{0,-11}{1,-8}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}",
                "Equipos","PJ","PG","PE","PP","GF","GC","DG","P");
            foreach (string elemento1 in Equipos)
            {
                Console.SetCursorPosition(izq, top);
                Datos_Equipo1 = new FileStream($"{elemento1.ToUpper()}.dat", FileMode.Open, FileAccess.Read);
                bre1 = new BinaryReader(Datos_Equipo1);
                int partidos = bre1.ReadInt32();
                int ganados = bre1.ReadInt32();
                int empatados = bre1.ReadInt32();
                int perdidos = bre1.ReadInt32();
                int favor = bre1.ReadInt32();
                int contra = bre1.ReadInt32();
                int diferencia = bre1.ReadInt32();
                int puntos = bre1.ReadInt32();
                Console.WriteLine("{0}       {1}        {2}       {3}       {4}       {5}       {6}        {7} ",
                    partidos, ganados, empatados, perdidos, favor, contra, diferencia, puntos);
                top+=2;
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
