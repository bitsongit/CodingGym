using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                LinkedList list = new LinkedList();

                for (int i = 1; i <= 7; i++)
                    list.Add(i);

                list.PrintList();

                Random ran = new Random();
                Int32 item = ran.Next(1, 8);
                //Delete item 
                Console.WriteLine();
                Console.WriteLine("Deleting random item : {0} ", item);
                list.Delete(item);

                list.PrintList();
                
                Console.WriteLine("Item {0} Deleted Successfully ", item);

                Console.WriteLine("Reversing the Linked List ");
                list.Reverse();

                list.PrintList();
                Console.ReadLine();

                list = null;
            }
        }
    }
    public class LinkedList
    {
        private int N;          // size of the stack
        private Node first;     // top of stack

        // helper Node class
        public class Node
        {
            Int32 m_item;
            Node m_next;

            public Int32 Item
            {
                get { return m_item; }
                set { m_item = value; }
            }

            public Node Next
            {
                get { return m_next; }
                set { m_next = value; }
                  
            }
        }
        
        public void Add(int item)
        {
            Node oldfirst = first;
            first = new Node();

            first.Item = item;
            first.Next = oldfirst;
            N++;
        }

        public Boolean Delete(int item)
        {
            Node current = first;
            Node prev=current;

            if (first.Item == item)
            {
                first = first.Next;
                N--;

                return true;
            }
            
            while (current != null)
            {
                if (current.Item == item)
                {
                    prev.Next = current.Next;
                    current = null;

                    N--;
                    return true;
                }

                prev = current;
                current = current.Next;

            }

            return false;
        }

        public Int32 Count
        {
            get { return N; }
        }

        public void PrintList()
        {
            Node current = first;

            Console.WriteLine("Printing Linked List : ");
            while (current !=null)
            {
                Console.Write("{0} ", current.Item);
                current = current.Next;
            }
            Console.WriteLine();
        }

        public Node Reverse()
        {
            Node oldfirst = first;
            
            if (first.Next == null)
            {
                return oldfirst;
            }

            first = first.Next;
            Reverse().Next = oldfirst;
            oldfirst.Next = null;
            return oldfirst;
        }

        //public Node MergeList(Node firstList, Node secondList)
        //{
        //    if (firstList == null && secondList == null)
        //        return null;
        //    if (firstList != null && secondList == null)
        //        return firstList;
        //    if (secondList != null && firstList == null)
        //        return secondList;

        //    if (firstList != null && secondList != null)
        //    {
        //        Node first_current = firstList;
        //        Node second_current=secondList;
        //        Node newList = new Node();
        //        Node new_currentList = newList;
        //        Node node;
        //        while (first_current != null && secondList != null)
        //        {
        //            if (first_current.Item <= second_current.Item)
        //            {
        //                node = new Node();
        //                node.Item = first_current.Item;
        //                node.Next = null;
        //                first_current = first_current.Next;
        //            }
        //            if (first_current.Item > second_current.Item)
        //            {
        //                node = new Node();
        //                node.Item = second_current.Item;
        //                node.Next = null;
        //                second_current = second_current.Next;
        //            }
        //            newList.Next = node;
        //        }

        //    }

        }
 }
