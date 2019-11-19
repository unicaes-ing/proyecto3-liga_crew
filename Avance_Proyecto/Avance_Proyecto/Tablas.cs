using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Avance_Proyecto
{
    class Tablas:Program
    {
        Tabla_Resultado resultado = new Tabla_Resultado();

        public void Lector()
        {
            Console.Clear();
            Team_Read = new StreamReader("5.txt");
            string texto;
            texto = Team_Read.ReadToEnd();
            Console.WriteLine(texto);
            Console.SetCursorPosition(2, 1);
            foreach (string elemento1 in Equipos)
            {
                foreach (string elemento2 in Equipos)
                {
                    if (elemento1.ToUpper().Equals(elemento2.ToUpper()))
                    {
                        //Console.WriteLine($"{elemento1.ToUpper()} vs {elemento2.ToUpper()}:");
                        Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.Open, FileAccess.Read);
                        br = new BinaryReader(Result);
                        todos = new FileStream("VS.dat", FileMode.Create, FileAccess.Write);
                        Write = new BinaryWriter(todos);
                        string letras = br.ReadString();
                        Write.Write(letras);
                        Write.Close();
                        Result.Close();
                        br.Close();
                        
                    }
                    else
                    {
                        //Console.WriteLine($"{elemento1.ToUpper()} vs {elemento2.ToUpper()}:");
                        Result = new FileStream($"{elemento1.ToLower()} vs {elemento2.ToLower()}.dat", FileMode.OpenOrCreate, FileAccess.Read);
                        br = new BinaryReader(Result);
                        todos = new FileStream("VS.dat", FileMode.Create, FileAccess.Write);
                        Write = new BinaryWriter(todos);
                        int Cantidad1 = br.ReadInt32();
                        int Cantidad2 = br.ReadInt32();
                        Write.Write(Cantidad1);
                        Write.Write(Cantidad2);
                        Write.Close();
                        Result.Close();
                        br.Close();
                    }
                    resultado.Cinco();
                    Console.ReadKey();
                }
            }
        }
    }
}
