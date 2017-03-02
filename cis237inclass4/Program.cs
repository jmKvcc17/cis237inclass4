using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            IIntegerLinkedList linkedList = new IntegerLinkedList();

            linkedList.AddMaintainSort(5);
            linkedList.AddMaintainSort(3);
            linkedList.AddMaintainSort(4);
            linkedList.AddMaintainSort(2);
            linkedList.AddMaintainSort(1);

            linkedList.Display();

            linkedList.RemoveMaintainSort(3);
            linkedList.RemoveMaintainSort(1);

            linkedList.AddToFront(3);

            linkedList.Display();

            Console.ReadLine();

        }
    }
}
