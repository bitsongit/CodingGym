using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// InOrder Successor : Good one : Method 2 : http://www.geeksforgeeks.org/archives/9999
namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            while (true)
            {
                
                Int32 option = GetOptions();

                # region User Options
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Operation : Add Node");
                        Console.WriteLine("Add Node Value To Be Inserted : ");

                        try
                        {

                            int input = Int32.Parse(Console.ReadLine());
                            while (input >= 1 && input < 100)
                            {
                                tree.AddNode(input);
                                input = Int32.Parse(Console.ReadLine());
                            }
                        }
                        catch
                        {
                            goto default;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Operation : Inorder Traversal");
                        tree.printInorder();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Operation : Inorder Traversal Iteratively");
                        tree.PrintInOrderIteratively();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Operation : Size of the Tree");
                        Console.WriteLine("{0}", tree.Size());
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Operation : Spiral Form Level Order Traversal");
                        tree.PrintInSpiralOrder();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Operation : Least Common Ancestor of two values");
                        
                        Console.WriteLine(" {0}",tree.LeastCommonAncestor(Int32.Parse(Console.ReadLine()),Int32.Parse(Console.ReadLine())));
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Operation : Number of Leaves in the Tree");
                        Console.WriteLine(" {0}", tree.GetLeafCount());
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Operation : Is Tree Height Balanced");
                        Console.WriteLine(" {0}",tree.IsHeightBalanced());
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Operation : Is Sum Exists");
                        Console.WriteLine(" {0}",tree.IsSumPathExists(Int32.Parse(Console.ReadLine())));
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Operation : Maximum Width of the Tree");
                        Console.WriteLine(" {0}",tree.MaxWidth());
                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("Operation : Is Tree Foldable");
                        Console.WriteLine(" {0}",tree.IsFoldable());
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("Print nodes at k distance from root");
                        Int32 k = Int32.Parse(Console.ReadLine());
                        tree.PrintNodesAtGivenDistance(k);
                        break;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("Operation : Postorder Traversal Iteratively");
                        tree.PrintPostOrderIteratively();
                        break;
                    case 14:
                        Console.Clear();
                        Console.WriteLine("Operation : Weighted Traversal ");
                        tree.InWeightedOrder();
                        break;
                    case 15:
                        Console.Clear();
                        Console.WriteLine("Operation : Right Side View ");
                        tree.RightSideView();
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Operation : ReEnter Valid Option");
                        break;


                }
                #endregion


                Console.ReadLine();
            }

           
        }
        private static int GetOptions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nA PlayGround to interact with Tree Data Structure");
            
            Console.WriteLine("\n1. Add Node in the Tree");
            Console.WriteLine("2. Inorder Traversal");
            Console.WriteLine("3. Inorder Traversal Iteratively");
            Console.WriteLine("4. Size of the Tree");
            Console.WriteLine("5. Spiral Form Level Order Traversal");
            Console.WriteLine("6. Least Common Ancestor of two values");
            Console.WriteLine("7. Number of Leaves in the Tree");
            Console.WriteLine("8. Is Tree Height Balanced");
            Console.WriteLine("9. Is Sum Exists");
            Console.WriteLine("10.Maximum Width of the Tree");
            Console.WriteLine("11.Is Tree Foldable");
            Console.WriteLine("12.Print nodes at k distance from root");
            Console.WriteLine("13.Postorder Traversal Iteratively");
            Console.WriteLine("14.Weighted Traversal ");
            Console.WriteLine("15.Right Side View ");

            Console.Write("\n\n\n\n\n\n\n\n\n Enter Option : ");

            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch
            {
                
                return -1;

            }
            
        }
        public class Tree
        {

            private Node root;
            
            public class Node
            {
                Int32 m_item;
                Node m_left;
                Node m_right;
                public Boolean isRightSubTreeProcessed;
                public Node parent;

                public Node(int item)
                {
                    m_item = item;
                    m_left = m_right = parent=null;
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
                root=AddNode(root, item); 
                
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

            public void printInorder()
            { 
                 printInorder(root); 
                 Console.WriteLine(); 
            }
                            
            private void printInorder(Node node)
            { 
                 if (node == null) return;

                 // left, node itself, right 
                 printInorder(node.Left); 
                 Console.Write(node.Item + "  "); 
                 printInorder(node.Right); 
               
            }

            public int Size()
            {
                return Size(root);
            }

            private int Size(Node node)
            {
                if (node == null) return 0;
                else
                {
                    return Size(node.Left) + Size(node.Right) + 1;
                }
            }

            public Boolean IsSameTree(Tree tree2)
            {
                return IsSameTree(root, tree2.root);
            }
            private Boolean IsSameTree(Node root, Node node)
            {
                if (root == null && node == null)
                    return true;
                else if (root != null && node != null)
                    return (root.Item == node.Item) && IsSameTree(root.Left, node.Left) && IsSameTree(root.Right, node.Right);
                else return false;
            }

            public void Mirror()
            {
                Mirror(root);
            }
            private void Mirror(Node node)
            {
                if (node != null)
                {

                    Mirror(node.Left);
                    Mirror(node.Right);

                    Node temp = node.Right;
                    node.Right = node.Left;
                    node.Left = temp;
                }
            }

            //Delete Tree - Go Delete recursively in Post Order

            public void PrintInSpiralOrder()
            {
                PrintInSpiralOrder(root);
            }
            private void PrintInSpiralOrder(Node node)
            {
                Stack<Node> s1=new Stack<Node>();
                Stack<Node> s2=new Stack<Node>();
                Node temp;
                
                if(node!=null)
                    s1.Push(node);

                while (s1.Count!=0 || s2.Count!=0)
                {
                    if (s1.Count!=0)
                    {
                        while (s1.Count!=0)
                        {
                            temp = s1.Pop();
                            Console.Write(" " + temp.Item);
                            if (temp.Left!=null)
                                s2.Push(temp.Left);
                            if (temp.Right!=null)
                                s2.Push(temp.Right);
                        }
                    }
                    else
                    {
                        while (s2.Count!=0)
                        {
                            temp = s2.Pop();
                            Console.Write(" " + temp.Item);
                            if (temp.Right!=null)
                                s1.Push(temp.Right);
                            if (temp.Left!=null)
                                s1.Push(temp.Left);
                        }
                    }
                }
            }

            public int LeastCommonAncestor(int val1, int val2)
            {
                return LeastCommonAncestor(root, val1, val2);
            }
            private int LeastCommonAncestor(Node node, int val1, int val2)
            {
                if (node == null || node.Item == val1 || node.Item == val2)
                {
                    return -1;
                }
                
                if (node.Item > val1 && node.Item < val2)
                {
                    return node.Item;
                }
                if (node.Item < val1 && node.Item < val2)
                {
                    return LeastCommonAncestor(node.Right, val1, val2);
                }
                if (node.Item > val1 && node.Item > val2)
                {
                    return LeastCommonAncestor(node.Left, val1, val2);
                }
                return -1;
            }

            public int GetLeafCount()
            {
                return GetLeafCount(root);
            }
            private int GetLeafCount(Node node)
            {
                if (node == null) return 0;
                if (node.Left ==null && node.Right ==null) return 1;
                else
                {
                    return GetLeafCount(node.Left)+GetLeafCount(node.Right);
                }
            }

            public void PrintInOrderIteratively()
            {
                PrintInOrderIteratively(root);
            }
            private void PrintInOrderIteratively(Node node)
            {
                Node current = node;
                Stack<Node> stack = new Stack<Node>();
                while (true)
                {
                    if (current != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        if (stack.Count != 0)
                        {
                            current = stack.Pop();
                            Console.Write("  " + current.Item);
                            current = current.Right;
                        }
                        else break;
                    }
                }
            }

            public Boolean IsSumPropertyCheck()
            {
                return IsSumPropertyCheck(root);
            }
            private Boolean IsSumPropertyCheck(Node node)
            {
                int ldata = 0;
                int rdata = 0;
                if ((node.Left == null && node.Right == null) || node == null)
                    return true;
                else
                {
                    if (node.Left != null)
                    {
                        ldata = node.Left.Item;
                    }
                    if (node.Right != null)
                    {
                        rdata = node.Right.Item;
                    }
                    return (node.Item == ldata + rdata) && IsSumPropertyCheck(node.Left) && IsSumPropertyCheck(node.Right);
                }
            }

            public Boolean IsHeightBalanced()
            {
                return IsHeightBalanced(root);
            }
            private Boolean IsHeightBalanced(Node node)  // O(n2)
            {
                if (node == null)
                {
                    return true;
                }
                int lh = Height(node.Left);
                int rh = Height(node.Right);

                return (Math.Abs(lh - rh) <= 1) && IsHeightBalanced(node.Left) && IsHeightBalanced(node.Right);
           }
            private Boolean IsHeightBalancedOptimized(Node node)  //O(n)
            {
                if (CheckHeight(node) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            private int Height(Node node)
            {
                if (node == null)
                    return 0;

                return 1 + Math.Max(Height(node.Left), Height(node.Right));
            }
            private int CheckHeight(Node node)
            {
                if (node == null)
                    return 0;
                int lh = CheckHeight(node.Left);
                if (lh == -1)
                    return -1;
                int rh = CheckHeight(node.Right);
                if (rh == -1)
                    return -1;
                if (Math.Abs(lh - rh) > 1)
                    return -1;
                else
                {
                    return Math.Max(lh ,rh) + 1;
                }
            }

            public Boolean IsSumPathExists(int sum)
            {
                return IsSumPathExists(root, sum);
            }
            private Boolean IsSumPathExists(Node node, int sum)
            {

                if (node == null )
                {
                    return (sum==0);
                }
                if (node.Left == null && node.Right == null && (node.Item - sum)==0)
                {
                    return true;
                }
                
                else
                {
                    return IsSumPathExists(node.Left, sum - node.Item) || IsSumPathExists(node.Right, sum - node.Item);
                }
                
            }

            public int MaxWidth()
            {
                return MaxWidth(root);
            }
            private int MaxWidth(Node node)
            {
                int width = 0;
                int height=Height(node);
                int[] count=new int[height];

                int level = 0;
                
                //Fill the count array using Pre order traversal
                MaxWidthRecur(node, count, level);

                //Get the maximum from the count array
                
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] > width)
                        width = count[i];
                }
                return width;

            }
            private void MaxWidthRecur(Node node, int[] count, int level)
            {
                if (node!=null)
                {
                    count[level]++;
                    MaxWidthRecur(node.Left, count, level + 1);
                    MaxWidthRecur(node.Right, count, level + 1);
                }
            }

            public Boolean IsFoldable()
            {
                return IsFoldable(root);
            }
            private Boolean IsFoldable(Node node)
            {
                if (node == null) return true;
                else
                {
                    return IsFoldableRecur(node.Left, node.Right);
                }
                
            }
            private Boolean IsFoldableRecur(Node node1, Node node2)
            {
                if (node1 == null && node2 == null)
                    return true;
                if (node1 == null || node2 == null)
                    return false;
               if (node1.Item == node2.Item)
                return IsFoldableRecur(node1.Left, node2.Right) && IsFoldableRecur(node1.Right, node2.Left);
               
              return false;
            }

            public void PrintNodesAtGivenDistance(int k)
            {
                PrintNodesAtGivenDistance(root, k);
            }
            private void PrintNodesAtGivenDistance(Node node, int k)
            {
                if (node == null)
                {
                    return;
                }
                if (k == 0)
                {
                    Console.Write(" {0}", node.Item);
                    return;
                }
                else
                {
                    PrintNodesAtGivenDistance(node.Left, k - 1);
                    PrintNodesAtGivenDistance(node.Right, k - 1);
                }
            }

            public void PrintPostOrderIteratively()
            {
                PrintPostOrderIteratively(root);
            }
            private void PrintPostOrderIteratively(Node node)
            {
                Node current = node;
                Stack<Node> stack = new Stack<Node>();
                while (true)
                {
                    if (current != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        if (stack.Count != 0)
                        {
                            current = stack.Pop();
                            if (current.isRightSubTreeProcessed==false)
                            {
                                current.isRightSubTreeProcessed = true;
                                stack.Push(current);
                                current = current.Right;
                            }
                            else
                            {
                                Console.Write("  " + current.Item);
                                current = null;
                            }
                     }
                        else break;
                    }
                }
            }

            public Node CreateMinimalBST(int[] array)
            {
                if (array == null)
                    return null;
                root = CreateMinimalBST(array, 0, array.Length-1);
                return root;
            }
            private Node CreateMinimalBST(int [] array, int start, int end)
            {
                if (end < start)
                    return null;
                int mid = start + (end - start) / 2;

                Node node = new Node(array[mid]);
                node.Left = CreateMinimalBST(array, start, mid - 1);
                node.Right = CreateMinimalBST(array, mid + 1, end);
                return node;

            }

            public Boolean CheckBST(Node node)
            {
                return CheckBST(node, int.MinValue, int.MaxValue);
            }
            private Boolean CheckBST(Node node, int min, int max)
            {
                if (node == null)
                {
                    return true;
                }
                if (node.Item < min || node.Item > max)
                {
                    return false;
                }
                if (!CheckBST(node.Left, min, node.Item) || !CheckBST(node.Right, node.Item, max))
                {
                    return false;
                }
                return true;
            }

            public Node InorderSucc(Node node)
            {
                if (node == null)
                    return null;
                //If there is right subtree - go leftmost child
                if (node.Right!=null)
                {
                    return LeftMostChild(node.Right);
                }
                else
                {
                    Node n=node;
                    Node parent=n.parent;
                    //Go up until we are on left instead of right
                    while(parent!=null && n!=parent.Left)
                    {
                        n=parent;
                        parent=n.parent;
                    }
                    return parent;
                }
            }
            public Node LeftMostChild(Node node)
            {
                if(node==null)
                    return null;
                while(node.Left!=null)
                {
                    node = node.Left;
                }
                return node;
            }

            public Boolean IsSubTree(Node T1, Node T2)
            {
                if(T1!=null && T2==null)
                    return true;
                if(T1==null && T2!=null)
                    return false;
                if(T1!=null && T2!=null)
                {
                    if (T1.Item == T2.Item)
                    {
                        return IsSameTree(T1, T2);
                    }
                    return IsSubTree(T1.Left,T2) || IsSubTree(T1.Right,T2);
                }
                return false;
            }

            public void InWeightedOrder()
            {
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();   
                InWeightedOrder(root,0,map);

                foreach (int key in map.Keys)
                {
                    foreach (int l in map[key])
                    {
                        Console.Write(l + " ");
                        
                    }
                    Console.WriteLine();
                }
                
            }
            private void InWeightedOrder(Node node, int weight, Dictionary<int,List<int>> map)
            {
                if (node == null)
                    return;
                if (node.Left != null)
                {
                    InWeightedOrder(node.Left, weight - 1,map);
                }
                

                if (map.ContainsKey(weight))
                {
                    List<int> value;
                    map.TryGetValue(weight, out value);
                    value.Add(node.Item);
                    map.Remove(weight);
                    map.Add(weight, value);
                }
                else
                {
                    List<int> value = new List<int>();
                    value.Add(node.Item);
                    map.Add(weight, value);
                }

                if (node.Right != null)
                {
                    InWeightedOrder(node.Right, weight + 1,map);
                }
            }

            public List<int> RightSideView()
            {
                List<int> result = new List<int>();
                RightSideView(root, result, 0);
                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                return result;
            }

            public void RightSideView(Node curr, List<int> result, int currDepth)
            {
                if (curr == null)
                {
                    return;
                }
                if (currDepth == result.Count())
                {
                    result.Add(curr.Item);
                }

                RightSideView(curr.Right, result, currDepth + 1);
                RightSideView(curr.Left, result, currDepth + 1);

            }

            public Node DeleteNodeInBST(int key)
            {
                return this.DeleteNode(this.root, key);
            }
            private Node DeleteNode(Node root, int key)
            {
                if (root == null || root.Item == key)
                {
                    return this.DeleteRoot(root);
                }

                Node current = root;
                while(true)
                {
                    if (key > current.Item)
                    {
                        if(current.Right == null || current.Right.Item == key)
                        {
                            current.Right = this.DeleteRoot(current.Right);
                            break;
                        }
                        current = current.Right;
                    }
                    else
                    {
                        if (current.Left == null || current.Left.Item == key)
                        {
                            current.Left = this.DeleteRoot(current.Left);
                            break;
                        }
                        current = current.Left;
                    }

                }

                return root;
            }
            private Node DeleteRoot(Node root)
            {
                if (root == null)
                {
                    return null;
                }
                if (root.Right == null)
                {
                    return root.Left;
                }
                if (root.Left == null)
                {
                    return root.Right;
                }

                Node x = root.Right; // root.right should be the new root
                while(x.Left!=null)
                {
                    x = x.Left; // find the left most node
                }
                x.Left = root.Left;

                return root.Right;
            }
        }
    }
}
