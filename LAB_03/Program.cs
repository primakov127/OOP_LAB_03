using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_03
{
    static class Output
    {
        public static void outInfo(Enrolle x)
        {
            Console.WriteLine(x.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var max = new Enrolle("Max", 18, 344);
            var den = new Enrolle("Denis", 18, 324);
            var ant = new Enrolle("Anton", 18, 318);
            Console.WriteLine(max.GetHashCode());
            Output.outInfo(max);
            
            Enrolle.DisplayCounter();

            var AnonType = new { max.name, max.Age, max.CTPoints }; // Анонимный тип

            //collection<Enrolle> items1 = new collection<Enrolle>();
            //collection<Enrolle> items2 = new collection<Enrolle>();

            //items1.addItem(max);
            //items1.addItem(den);
            //items1.printAll();

            //items2.addItem(max);
            //items2.addItem(den);
            //items2.addItem(ant);
            //items2.printAll();

            //var items3 = items1.Merge(items2);
            //items3.printAll();

            var items = collection<Enrolle>.getInstance();
            var items2 = collection<Enrolle>.getInstance();
            items.addItem(max);
            items.addItem(den);
            items.addItem(ant);
            items.printAll();
            Console.WriteLine(items[1].Age);
            
        }
    }
}
