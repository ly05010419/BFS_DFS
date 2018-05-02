using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace namespaceStuktur
{
    class Node
    {
        public String id;

        public List<Node> nodeList;

        public bool besucht = false;

        public Node(String id)
        {
            this.id = id;
            this.nodeList = new List<Node>();
        }
    }
    
}