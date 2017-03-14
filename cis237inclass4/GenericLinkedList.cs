using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class GenericLinkedList<T> : IGenericLinkedList<T>
    {
        //Make node class
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        //A couple of pointers to the head and the tail of the
        //linked list
        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                //To check whether or not it is empty we can check
                //to see if the head pointer is null. If so, there
                //are no nodes in the list, so it must be empty.
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        //This has a big O of O(1)
        public void AddToFront(T Data)
        {
            //Make a new variable to also reference the head of the list
            Node oldHead = _head;
            //Make a new node and assign it to the head variable
            _head = new Node();
            //Set the data on the new node
            _head.Data = Data;
            //Make the next property of the new node point to the old head
            _head.Next = oldHead;
            //Increment the size of the list
            _size++;
            //Ensure that if we are adding the very first node to the list
            //that the tail will be pointing to the new node we create
            if (_size == 1)
            {
                _tail = _head;
            }
        }

        //This has a big O of O(1)
        public void AddToBack(T Data)
        {
            //Make a pointer to the tail called old tail
            Node oldTail = _tail;
            //Make a new node and assign it to the tail variable
            _tail = new Node();
            //Assign the data and set the next pointer
            _tail.Data = Data;
            _tail.Next = null;

            //Check to see if the list is empty. If so, make the head
            //point to the same location as the tail.
            if (IsEmpty)
            {
                _head = _tail;
            }
            //We need to take the oldTail and make it's Next property
            //point to the tail that we just created.
            else
            {
                oldTail.Next = _tail;
            }
            //Increment the size
            _size++;
        }

        //This has a big O of O(1)
        public T RemoveFromFront()
        {
            //If it is empty throw an error
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            //Let's get the data to return
            T returnData = _head.Data;
            //Move the head pointer to the next in the list.
            _head = _head.Next;
            //Decrease the size
            _size--;
            //Check to see if we just removed the last node from the list
            if (IsEmpty)
            {
                _tail = null;
            }
            //return the returnData we pulled out from the first node
            return returnData;
        }

        //Remove from the back is not as easy. It requires more work
        //This has a big O of O(N)
        public T RemoveFromBack()
        {
            //Check for empty, throw exception if it is
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            //Get the return data right off the bat.
            T returnData = _tail.Data;

            //Check to see if we are on the last node
            //If so, we can just set the head and tail to null since we want
            //to remove the only node remaining in the list
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            //Else, we need to traverse the list and stop right before we
            //reach the tail
            else
            {
                //Create a temporary node to use to 'walk' down the list
                Node current = _head;

                //Keep moving forward until the current.Next is
                //equal to the tail.
                //Keep looping while current.Next != _tail
                while (current.Next != _tail)
                {
                    //Set the current pointer to the current pointer's next
                    //node.
                    current = current.Next;
                }

                //I am now in position to do some work
                //Set the tail to the current position
                _tail = current;
                //Make the last node that we are removing go away
                //by setting tail's next property to null
                _tail.Next = null;
            }

            //Return our return data
            return returnData;
        }

        public void Display()
        {
            Console.WriteLine("The list is:");
            //Setup a currentNode to walk the list
            //start it at the head node
            Node currentNode = _head;
            //loop through the nodes until we hit null
            //which will signify the end of the list
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                //Move to the next node
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
        }

    }
}
