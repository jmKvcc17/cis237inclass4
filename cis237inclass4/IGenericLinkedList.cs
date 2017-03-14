using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    interface IGenericLinkedList<T>// whatevers in the <> can be whatever you want, can have 
        // multiple "types" that are comma separated
    {
        void AddToFront(T Data);
        void AddToBack(T Data);
        T RemoveFromFront();
        T RemoveFromBack();

        void Display();

        bool IsEmpty { get; }
        int Size { get; }

    }
}
