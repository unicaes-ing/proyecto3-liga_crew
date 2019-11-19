using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Avance_Proyecto
{
    class Tabla_Resultado:Program
    {
        
        public void Cinco()
        {
            todos = new FileStream("VS.dat", FileMode.Open, FileAccess.Read);
            Read = new BinaryReader(todos);
            var item1 = Read.Read();
            var item2 = Read.Read();
            var item3 = Read.Read();
            var item4 = Read.Read();
            var item5 = Read.Read();
            Console.WriteLine("{0,-5} {1,-5} {2,-5} {3,-5} {4,-5}",
                item1,item2,item3,item4,item5);
            Console.ReadKey();
        }



    }
}
