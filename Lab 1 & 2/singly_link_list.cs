using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

/* 
LinkList is Data Structure data store data in the form of nodes.
Every node contains two things:

    => Data 
    => Address of next node 

One head node stores the address of first node 

As we know object data of class stores at heap memory. The object it self stores in stack and contains the address of heap to point out its value.

So we make link list to connect them. Every object contains own data and ref of other other object, and the chain is produced
*/

class Node
{
    public int data;
    public Node next;

    public static int Counter = 0;

    public Node(int Data)
    {
        this.data = Data;
        next = null;
        Counter++;

    }
}

class Program
{
    static void Main()
    {
        Node firstNode = new Node(1);
        Node secondNode = new Node(2);
        Node thirdNode = new Node(3);

        Node head = firstNode;
        firstNode.next = secondNode;
        secondNode.next = thirdNode;

//==================================================================================

        // Insert Node at Start

        Node InsertAtStart(Node head, int data)
        {
            Node newStartNode = new Node(data);
            newStartNode.next = head;
            head = newStartNode;
            Console.WriteLine($"\n{newStartNode.data} Inserted at start");
            return head;
        }

        head = InsertAtStart(head, 90);

//==================================================================================


        // Insert at end

        void InsertAtEnd(Node head, int data)
        {
            Node newEndNode = new Node(data);

            Node current = head;

            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newEndNode;
            Console.WriteLine($"\n{newEndNode.data} Inserted at end");
        }

        InsertAtEnd(head, 100);


//==================================================================================


        //Insert at after specific data value

        void InsertAfterData(int data)
        {
            Node AfterDataNode = new Node(25);
            Node current = head;
            while (current.data != data) // If we want before specific data value then we can use current.next.data != data
            {
                current = current.next;
            }

            AfterDataNode.next = current.next;
            current.next = AfterDataNode;
            Console.WriteLine($"\n{AfterDataNode.data} Inserted after Data = {data}\n");

        }
        InsertAfterData(2);


//==================================================================================


        // Insert At Middle 

        Node InsertAtMiddle(Node head, int data, int position)
        {
            if (position == 1)
            {
                return InsertAtStart(head, data);
            }
            else if (position <= Node.Counter)
            {
                Node middleNode = new Node(data);
                Node current = head;
                int loopCounter = 1;

                while (current.next != null && loopCounter < position - 1)
                { 
                    current = current.next;
                    loopCounter++;
                }
                middleNode.next = current.next;
                current.next = middleNode;
                Console.WriteLine($"\n{middleNode.data} Inserted at position {position}\n");

                return head;
            }
            else if (position == Node.Counter + 1)
            {
                InsertAtEnd(head, data);
                return head;
            }
            else
            {
                Console.WriteLine("\nposition is out of range...\n");
                return head;
            }
        }

        head = InsertAtMiddle(head, 900, 5);


//==================================================================================


        traversingLinkList();


        // Deletion In Link List at beginning

        Node DeleteAtStart(Node head)
        {
            if (head == null)
            {
                Console.WriteLine("There is no List / List is Empty...");
                return head;
            }
            else
            {
                head = head.next;
                Node.Counter--;
                Console.WriteLine($"\nDeleted at 1st position\n");

                return head;
            }
        }
        head = DeleteAtStart(head);

//==================================================================================



        // Deletion at end 
        Node DeleteAtEnd(Node head)
        {
            if (head == null)
            {
                Console.WriteLine("There is no List / List is Empty...");
                return head;
            }
            else if (head.next == null)  // May be we have one object in link list
            {
                head = null;
                Node.Counter--;
                Console.WriteLine($"\nDeleted at last position\n");

                return head;

            }
            else   // if we have more than one object 
            {
                Node current = head;
                while (current.next.next != null)
                {
                    current = current.next;
                }
                current.next = null;
                Node.Counter--;
                Console.WriteLine($"\nDeleted at last position\n");

                return head;

            }

        }
        head = DeleteAtEnd(head);


//==================================================================================


        //Delete After Specific value

        void DeleteAfterValue(int value)
        {
            Node current = head;
            while(current.data != value)
            {
                current = current.next;
            }
            current.next = current.next.next;
            Console.WriteLine($"\nDeleted after value {value}\n");
            Node.Counter--;
        }

        DeleteAfterValue(2);


//==================================================================================


        //Deletion at Middle

        Node DeleteAtMiddle(Node head, int position)
        {
            if (position == 1)
            {
                return DeleteAtStart(head);
            }
            else if (position < Node.Counter)
            {
                Node current = head;
                for (int i = 1; i < position - 1; i++)
                {
                    current = current.next;
                }
                current.next = current.next.next;

                Node.Counter--;
                Console.WriteLine($"\nDeleted at position {position}\n");
                return head;
            }
            else if (position == Node.Counter)
            {
                return DeleteAtEnd(head);
            }
            else
            {
                Console.WriteLine("\nposition is out of range...\n");
                return head;
            }
        }

        head = DeleteAtMiddle(head, 4);


//==================================================================================


        // Traversing through LinkList

        void traversingLinkList()
        {

            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;

            }
        }
        traversingLinkList();



//==================================================================================================

        // REVERSE LINK LIST

        Node reverseLinkList(Node head)
        {
            Node previous = null;
            Node current = head;
            Node next = null;

            while(current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next; 
            } 

            return previous;
        }
        Console.WriteLine("\nReversing Link List\n");
        head = reverseLinkList(head);
        traversingLinkList();
    }



}
