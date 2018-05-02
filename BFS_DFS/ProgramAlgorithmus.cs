using namespaceStuktur;
using namespaceUtility;
using System;
using System.Collections;
using System.Collections.Generic;


namespace namespaceAlgorithmus
{
    class Algorithmus
    {
        public void BFS(Node node, List<Node> result)
        {
            
            Queue<Node> queue = new Queue<Node>();
            node.besucht = true;
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                result.Add(node);
                

                foreach (Node n in node.nodeList)
                {
                    if (!n.besucht)
                    {
                        queue.Enqueue(n);
                        n.besucht = true;
                    }
                }
            }
        }

        public void DFS(Node node,List<Node> result)
        {
            
            result.Add(node);

            node.besucht = true;

            foreach (Node n in node.nodeList)
            {
                if (!n.besucht)
                {
                    DFS(n, result);
                }
            }

           
        }

        public void BFS_und_TFS(string path,bool bfs)
        {

            Console.WriteLine("Bereitensuche oder Tiefensuche");

            Algorithmus algorithmus = new Algorithmus();

            List<Node> nodeList = Parse.readFile(path);

            List<List<Node>> resultList = new List<List<Node>>();

            DateTime befor = System.DateTime.Now;

            Node root = null;
            while ((root = checkNodeList(nodeList)) != null)
            {
                List<Node> result = new List<Node>();

                if (bfs) {
                    algorithmus.BFS(root, result);
                } else {
                    algorithmus.DFS(root, result);
                }

                resultList.Add(result);
            }
            DateTime after = System.DateTime.Now;
            TimeSpan ts = after.Subtract(befor);
            Console.WriteLine("\n\n{0}s.", ts.TotalSeconds);



            foreach (List<Node> result in resultList)
            {
                Console.WriteLine("\n");
                foreach (Node n in result)
                {
                    Console.Write(n.id + ",");
                }
            }


            Console.ReadLine();
        }

         Node checkNodeList(List<Node> nodeList)
        {

            Node node = null;
            foreach (Node k in nodeList)
            {

                if (!k.besucht)
                {
                    node = k;
                    break;
                }
            }
            return node;
        }

    }
}