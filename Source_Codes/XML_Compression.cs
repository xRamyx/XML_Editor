using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Compression
{

    class XML_Compression
    {
        /*********************************GLOBAL VARIABLES*******************************/
        // global array to store huffman codes and the associated characters
        // maximum hoffman code size is 19 , suppose worst case that we have 128 characters
        // each character is 19 digits code size , then codes array should be (19*128)+128=2560
        static int[] huffman_codes_arr = new int[2560];
        static int huffman_codes_index = 0;
        // these variables are used to write code bits in the output file in the WriteBit function
        // they are not static as it is used in flushing too
        //output string buffer
        /************************************CLASSES*************************************/
        public class Node
        {

            public char ch;
            public int frequency;
            public Node left, right;
            public Node(char c, int n)
            {
                left = right = null;
                ch = c;
                frequency = n;
            }
            public bool isLeaf()

            {
                if (left == null && right == null)
                    return true;
                else
                    return false;
            }
        }

        /**********************************************FUNCTIONS****************************/

        //this function is passed the root of the huffman tree and any array to hold the result of recursion (code of a certain character)
        private static void getCodes(Node root, int[] arr, int top)
        {
            if (root.left != null)
            {

                arr[top] = 0;
                getCodes(root.left, arr, top + 1);
            }

            // Assign 1 to right edge and recur
            if (root.right != null)
            {

                arr[top] = 1;
                getCodes(root.right, arr, top + 1);
            }

            // If this is a leaf node, then
            // it contains one of the input
            // characters, the code for this character is saved in arr[]
            // get the code from arr[] to the global huffman_codes_arr[] and save the associated
            // character before it
            if (root.isLeaf())
            {
                huffman_codes_arr[huffman_codes_index++] = (int)root.ch;
                for (int i = 0; i < top; i++)
                {
                    huffman_codes_arr[huffman_codes_index++] = arr[i];
                }
            }
        }
        private static Node createHuffmanTree(char[] data, char[] freq, int size)
        {
            Node left, right, sum;
            var tree = new PriorityQueue<Node, int>(); // Min Heap priority queue

            // fill the queue with nodes of characters and their frequencies
            for (int i = 0; i < size; i++)
            {
                tree.Enqueue(new Node(data[i], freq[i]), freq[i]);//frequency determines priority
            }
            while (tree.Count != 1)
            { // at end of creation of tree,only 1 element will be left which is the root
                left = tree.Peek();
                tree.Dequeue();

                right = tree.Peek();
                tree.Dequeue();
                //default character of a non-leaf node is $
                sum = new Node('$', left.frequency + right.frequency);
                sum.left = left;
                sum.right = right;

                tree.Enqueue(sum, sum.frequency);
            }
            return tree.Peek(); // return root of tree
        }

        private static void GetHuffmanCodes(char[] data, char[] freq, int size)
        {
            int[] code_arr = new int[19]; //just a dummy array for recursion in get code function, 19 is the maximum huffman code size,
            Node root = createHuffmanTree(data, freq, size);
            getCodes(root, code_arr, 0);
        }
        
    }
}
