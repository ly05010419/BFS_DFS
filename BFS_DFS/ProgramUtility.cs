using namespaceStuktur;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace namespaceUtility
{
    class Parse
    {
        public static List<Node> readFile(string path) {
            List<Node> nodeList = new List<Node>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String lineStr;

            int nodeCount = 0;
            while ((lineStr = sr.ReadLine()) != null)
            {
                if (nodeCount == 0)
                {
                    initNode(int.Parse(lineStr), nodeList);
                }
                else
                {
                    string[] word = Regex.Split(lineStr, "\t");

                    if (word.Length>3) {
                        int sonIndex = 0;
                        foreach (string s in word)
                        {
                            if (s == "1")
                            {
                                Node vater = nodeList[nodeCount - 1];
                                Node son = nodeList[sonIndex];
                                vater.nodeList.Add(son);
                            }
                            sonIndex++;
                        }

                    } else {
                        createNode(int.Parse(word[0]), int.Parse(word[1]), nodeList);
                        createNode(int.Parse(word[1]), int.Parse(word[0]), nodeList);
                    }
                }

                nodeCount++;
            }
            return nodeList;
        }

        static void initNode(int nodeCount,List<Node> nodeList) {
            for (int i = 0; i < nodeCount; i++)
            {
                Node node = new Node("" + i);
                nodeList.Add(node);
            }
        }
     
        static void createNode(int vaterIndex, int sonIndex, List<Node> nodeList)
        {
            Node vater = nodeList[vaterIndex];
            Node son = nodeList[sonIndex];
            vater.nodeList.Add(son);
        }

        public static void resetNodeList(List<Node> nodeList)
        {
            foreach (Node n in nodeList)
            {
                n.besucht = false;
            }
        }
    }
}