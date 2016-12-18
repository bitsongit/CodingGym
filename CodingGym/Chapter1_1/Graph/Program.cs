using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GraphLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("Graph.txt");

            Console.WriteLine(g.ToString());
        }
        public class Graph
        {
            private int V;
            private int E;
            private LinkedList<int>[] adj;

            private void BuildGraph(int V)
            {
                this.V = V;
                this.E = 0;
                adj = new LinkedList<int>[V];

                for (int v = 0; v < V; v++)
                    adj[v] = new LinkedList<int>();

            }
            public Graph(String inputFile)
            {
                String[] buildInput = File.ReadAllLines(inputFile);
                BuildGraph(int.Parse(buildInput[0]));
                int E = int.Parse(buildInput[1]);
                for (int e = 0; e < E; e++)
                {
                    string temp = buildInput[e + 2];
                    string [] vals=temp.Split(new char[] { ' ' });
                    addEdge(int.Parse(vals[0]), int.Parse(vals[1]));
                }
            }
            public int GetTotalVertices()
            {
                return this.V;
                
            }
            public int GetTotalEdges()
            {
                return this.E;

            }
            public void addEdge(int v, int w)
            {
                adj[v].AddFirst(w);
                adj[w].AddFirst(v);
                E++;
            }
            public IEnumerable<int> GetAdjacentVertices(int v)
            {
                return adj[v];
            }
            public override String ToString()
            {
                String s = V + " vertices, " + E + " edges\n";
                for (int v = 0; v < V; v++)
                {
                    s = s + v + ": ";
                    foreach(int w in GetAdjacentVertices(v))
                        s=s+w+ " ";
                    s=s+"\n";
                }
                return s;
            }
        }
        public class BreadthFirstPaths
        {
            private Boolean[] marked;
            private int[] edgeTo;
            private int s;

            BreadthFirstPaths(Graph G, int s)
            {
                marked = new Boolean[G.GetTotalVertices()];
                edgeTo = new int[G.GetTotalVertices()];
                this.s = s;

                bfs(G, s);

            }
            private void bfs(Graph G, int s)
            {
                Queue<int> queue = new Queue<int>();
                marked[s] = true;
                queue.Enqueue(s);

                while (queue.Count != 0)
                {
                    int v = queue.Dequeue();
                    foreach (int w in G.GetAdjacentVertices(v))
                    {
                        if (!marked[w])
                        {
                            marked[w] = true;
                            edgeTo[w] = v;
                            queue.Enqueue(w);
                        }
                    }
                }
              }
            public Boolean hasPathTo(int v)
            {
                return marked[v];
            }
            public IEnumerable<int> pathTo(int v)
            {
                if (!hasPathTo(v)) return null;
                Stack<int> path = new Stack<int>();
                for (int x = v; x != s; x = edgeTo[x])
                    path.Push(x);
                path.Push(s);

                return path;

            }
        }
        public class DepthFirstPaths
        {
            private Boolean[] marked;
            private int[] edgeTo;
            private int s;

            DepthFirstPaths(Graph G, int s)
            {
                marked = new Boolean[G.GetTotalVertices()];
                edgeTo = new int[G.GetTotalVertices()];
                this.s = s;

                dfs(G, s);
            }
            private void dfs(Graph G, int v)
            {
                marked[v] = true;
                foreach (int w in G.GetAdjacentVertices(v))
                {
                    if (!marked[v])
                    {
                        marked[v] = true;

                        edgeTo[w] = v;
                        dfs(G, w);
                    }
                }
            }
            public Boolean hasPathTo(int v)
            {
                return marked[v];
            }
            public IEnumerable<int> pathTo(int v)
            {
                if (!hasPathTo(v)) return null;
                Stack<int> path = new Stack<int>();
                for(int x=v;x!=s;x=edgeTo[x])
                {
                    path.Push(x);
                }
                path.Push(s);
                return path;
            }
        }
    }
}
