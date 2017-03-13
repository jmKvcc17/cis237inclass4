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

            // Create a generic linked list for strings
            IGenericLinkedList<string> genericLinkedList = new GenericLinkedList<string>();
            // Here is one for doubles
            IGenericLinkedList<double> doubleLinkedList = new GenericLinkedList<double>();
            // How about one to hold the built in class LinkedList
            // Not sure if you would ever do this, but 
            IGenericLinkedList<LinkedList<int>> inception = new GenericLinkedList<LinkedList<int>>();

            // Let's use the string one we created
            genericLinkedList.AddToFront("1");
            genericLinkedList.AddToFront("2");
            genericLinkedList.AddToFront("3");
            genericLinkedList.AddToFront("4");
            genericLinkedList.AddToFront("5");
            genericLinkedList.Display();
            genericLinkedList.RemoveFromFront();
            genericLinkedList.RemoveFromFront();
            genericLinkedList.Display();


            Console.ReadLine();

        }
    }
}
