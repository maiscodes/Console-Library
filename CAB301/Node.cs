using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class for an individual node in the movie binary search tree. 
    /// </summary>
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Movie Movie { get; set; }

        public Node()
        {
            Movie = null;
            LeftNode = null;
            RightNode = null;
        }
    }
}
