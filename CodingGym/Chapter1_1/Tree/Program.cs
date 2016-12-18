using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            
            //Build the random tree - building is in BST mode - though spiral order is agnostic about the ordering
            tree.AddNode(10);
            tree.AddNode(5);
            tree.AddNode(6);
            tree.AddNode(20);
            tree.AddNode(25);
            tree.AddNode(2);

            tree.PrintInSpiralOrder();

            Console.Read();
        }
        public class Tree
        {

            private Node root;

            public class Node
            {
                Int32 m_item;
                Node m_left;
                Node m_right;

                public Node(int item)
                {
                    m_item = item;
                    m_left = m_right = null;
                }
                public Int32 Item
                {
                    get
                    {
                        return m_item;
                    }
                    set
                    {
                        m_item = value;
                    }
                }

                public Node Left
                {
                    get
                    {
                        return m_left;
                    }
                    set
                    {
                        m_left = value;
                    }
                }

                public Node Right
                {
                    get
                    {
                        return m_right;
                    }
                    set
                    {
                        m_right = value;
                    }
                }
            }

            public void AddNode(Int32 item)
            {
                root = AddNode(root, item);

            }
            private Node AddNode(Node node, Int32 item)
            {
                if (node == null)
                {
                    node = new Node(item);
                }
                else
                {
                    if (item <= node.Item)
                        node.Left = AddNode(node.Left, item);
                    else
                        node.Right = AddNode(node.Right, item);
                }
                return node;
            }

            
            public void PrintInSpiralOrder()
            {
                PrintInSpiralOrder(root);
            }
            private void PrintInSpiralOrder(Node node)
            {
                Stack<Node> s1 = new Stack<Node>();
                Stack<Node> s2 = new Stack<Node>();
                Node temp;

                if(node!=null)
                    s1.Push(node);
                
                while (s1.Count != 0 || s2.Count != 0)
                {
                    if (s1.Count != 0)
                    {
                        while (s1.Count != 0)
                        {
                            temp = s1.Pop();
                            Console.Write(" " + temp.Item);
                            
                            if (temp.Left != null)    // Left - Right Order
                                s2.Push(temp.Left);
                            if (temp.Right != null)
                                s2.Push(temp.Right);

                        }

                     }
                    else
                    {
                        while (s2.Count != 0)
                        {
                            temp = s2.Pop();
                            Console.Write(" " + temp.Item);

                            if (temp.Right != null)  // Right -Left Order
                                s1.Push(temp.Right);
                            if (temp.Left != null)
                                s1.Push(temp.Left);

                        }

                    }

                }
            }
        }
    }
}

/* test cases :

Functional Cases:
 * 1. Tree is Null
 * 2. Tree contains 1 node : base cases : 2 ,3 nodes.
 * 3. Tree is complete tree
 * 4. Skewed Right Tree
 * 5. Skewed Left Tree
 * 6. Tree contains Large number of nodes ~100 
 * 7 . Negative cases - Tree deletion of nodes followed by printing spiral order - similar conjoining cases
 * 8. Pass the incorrect Node type - but since the abstraction is inside - so not a candidate here
 * 
 Performance Cases:
 * 1. Trending of the algorithm ~ 100 - 10000 - order (million) nodes
 * 
 * 
 * `
Cases can cover up of Security Cases [not able to think the interesting cases other than corner cases mentioned above], API semantics [guidelines], 

*/