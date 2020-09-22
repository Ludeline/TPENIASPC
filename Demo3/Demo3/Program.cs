using Demo3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            Daughter1 d1 = new Daughter1();
            Mother1 d2 = new Daughter1();

            d1.DoStm1();
            d1.DoSmt4();
            (d1 as Mother1).DoSmt4();
            d1.DoSmt5();
            d1.DoSmt6();
            d1.DoSmt7();

            d2.DoStm1();
            d2.DoSmt4();
            (d2 as Mother1).DoSmt4();
            d2.DoSmt5();
            d2.DoSmt6();
            d2.DoSmt7();

            (d2 as Interface1).DoSmt5();
            (d2 as Interface2).DoSmt7();

            Console.ReadKey();
        }
    }
}
