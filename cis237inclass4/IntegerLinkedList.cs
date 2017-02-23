using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class IntegerLinkedList : IIntegerLinkedList
    {
        protected class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        // A couple of pointers to the head and the tail
        // of the linked list
        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                // To check whether or not it is empty we can check
                // to see if the head pointer is null. If so, there 
                // are no nodes in the list, so it must be empty.
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

        public void AddMaintainSort(int IntegerData)
        {
            // Make a new node
            Node newNode = new Node();
            // Assign the passed in data to it
            newNode.Data = IntegerData;

            // Check to see if the list is empty, or 
            // the node we are adding is les than
            // the current head
            if (IsEmpty || _head.Data >= newNode.Data)
            {
                // Set the newNode's next property to the head pointer
                newNode.Next = _head;
                // Set the head pointer to the new node
                _head = newNode;
                // Check to see if tail is null, if so, set it to head
                // so that head and tail point to the same location
                if (_tail == null)
                {
                    _tail = _head;
                }

            }
            // Else, we want to add a node to a list that is not
            // empty, and the node we want to add is at least after
            // the first one.
            else
            {
                // Setup a node pointer to "walk" through the list
                Node currentNode = _head;

                // Linear search to find the correct spot
                while (currentNode.Next != null && 
                    currentNode.Next.Data < newNode.Data)
                {
                    // Move down the list one node
                    // Set the currentNode to currentNode's next node
                    currentNode = currentNode.Next;
                }

                // Make the newNode's next property point to the
                // current nodes next property.
                newNode.Next = currentNode.Next;
                // Set the currentNode's next to the newNode
                currentNode.Next = newNode;

                // Check to see if the tail was the same as the
                // currentNode. If it is, the current node "was"
                // the tail, but is no longer. Now the new node
                // has become the tail, so we need to move that
                // tail pointer.
                if (_tail == currentNode)
                {
                    _tail = newNode;
                }
            }
            // Increment the size
            _size++;

        }

        public int RemoveMaintainSort(int RemoveData)
        {
            // If empty throw exception
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            // Make integer to hold the returnData
            int returnData;

            // If the head and the tail point to the same place
            // or the data in the head is the data we want to remove
            if (_head == _tail || _head.Data == RemoveData)
            {
                // Set the returnData
                returnData = _head.Data;
                // Make the head point to the head node's next node
                _head = _head.Next;

                // If the head is null, then the list
                // must be empty and the tail should become
                // null as well
                if (_head == null)
                {
                    _tail = null;
                }
                
            }
            // Else we are removing somewhere past the first node
            else
            {
                Node currentNode = _head;

                // While we are not at the end of the list
                // and the currentNode's data is not what we 
                // want to remove
                while (currentNode.Next != _tail &&
                    currentNode.Next.Data != RemoveData)
                {
                    currentNode = currentNode.Next;
                }

                // If the currentNode's Next node's data is what
                // I want to remove, lets remove it.
                if (currentNode.Next.Data == RemoveData)
                {
                    // Since it's what we want, let's set it
                    returnData = currentNode.Next.Data;

                    // If the currentNode's next node is the tail
                    // we need to set the tail to the currentNode
                    if (currentNode.Next == _tail)
                    {
                        _tail = currentNode;
                    }

                    // Need to set the current node's next property
                    // to the current node's next node's next
                    // This does the work of skipping over the one
                    // we are removing
                    currentNode.Next = currentNode.Next.Next;

                }
                // Else we went all the way to the end without 
                // finding it, so throw an exception
                else
                {
                    throw new Exception("Item not found");
                }
            }
            // Decrement the size
            _size--;
            // return the retunData
            return returnData;
        }

        public void Display()
        {
            Console.WriteLine("The list is: ");

            // Setup a currentNode to walk the list
            // start it at the head node
            Node currentNode = _head;
            // loop through the nodes until we hit null
            // which will signify the end of the list
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                // Move to the next node
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
        }
    }
}
