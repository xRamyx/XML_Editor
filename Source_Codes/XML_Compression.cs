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
        static int current_bit = 0;
        static byte bit_buffer;

        //output string buffer
        static string compressed_output = "";
        static string decompressed_output = "";

        //to adjust the number of occurunces of a character to be encoded
        public const int THRESHOLD = 0;
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
        private static void WriteBit(int bit)
        {
            //concatenates every 7 bits in a buffer then saves the whole output in a global string compressed_output
            //7 bits not 8 as if the output character is 8 bits it will be stored in 2 bytes (UTF16) by default
            //at de compression , the MSB will not be considered
            bit_buffer <<= 1;
            if (bit == 1)
                bit_buffer |= 0x1;

            current_bit++;
            if (current_bit == 7)
            {
                compressed_output += (char)(byte)bit_buffer;
                current_bit = 0;
                bit_buffer = 0;
            }
        }
        //Flush is used to complete the last byte in file if it wasnt already complete 
        private static void Flush()
        {
            while (current_bit != 0)
                WriteBit(0);
        }
        public static void Compress(string input_path, string output_path)
        {
            int file_size = 0;
            char[] file_string = new char[20000];//max 20kb
            StreamReader streamReader = new StreamReader(input_path);
            int idx = 0;
            while (streamReader.Peek() != -1)
            {
                file_size++;
                file_string[idx++] = (char)streamReader.Read();
            }

            int[] char_map = new int[128];
            for (int i = 0; i < file_size; i++)
            {
                char_map[file_string[i]]++;
            }

            //We must add characters and the characters frequencies (key) at the top of the compressed output file for decompression 
            //the key ended by three dollar signs
            char[] file_characters = new char[128];
            char[] file_characters_freq = new char[128];
            int file_index = 0;

            for (int i = 0; i < 128; i++)
            {
                if (char_map[i] > THRESHOLD)
                {   //copy characters in output
                    file_characters[file_index] = (char)(byte)i;
                    compressed_output += (char)(byte)i;
                    file_characters_freq[file_index++] = (char)char_map[i];
                }
            }
            compressed_output += "$$";//to separate frequency and characters

            //write the frequencies
            for (int i = 0; i < file_index; i++)
            {
                compressed_output += (char)file_characters_freq[i];
            }
            compressed_output += "$$$";//to separate the compressed file from key

            GetHuffmanCodes(file_characters, file_characters_freq, file_index);

            int[] huffman_results_map = new int[128];
            for (int i = 0; i < huffman_codes_index; i++)
            {
                if (huffman_codes_arr[i] > 1)// not code but character
                {
                    huffman_results_map[huffman_codes_arr[i]] = i + 1; // huffmanarr[i] contains character ascii , i+1 is the index of the char code in the huffman_arr  
                }
            }
            for (int i = 0; i < file_string.Length; i++)
            {

                int j = huffman_results_map[file_string[i]]; // j contains index of first bit in the characters code
                while (huffman_codes_arr[j] <= 1 && j < huffman_codes_index)//write bits of code of the character until u find next character in huffman_arr
                {
                    WriteBit(huffman_codes_arr[j++]);
                }
            }


            StreamWriter x = new StreamWriter(output_path,false);
            x.Write(compressed_output);
            x.Close();
        }
         private static void decode(Node root, ref int idx, string str)
        {
            if (root == null)
            {
                return;
            }

            // found a leaf node
            if (root.left == null && root.right == null)
            {
                decompressed_output += root.ch;
                return;
            }

            idx++;

            if (str[idx] == '0')
                decode(root.left, ref idx, str);
            else if (str[idx] == '1')
                decode(root.right, ref idx, str);
        }

        private static int[] get_bits(int n)
        {
            int[] bits = new int[7];
            for (int i = 0; n > 0; i++)
            {
                bits[i] = n % 2;
                n = n / 2;
            }
            return bits;
        }

        public static void decompress(string input_path, string output_path)
        {
            string text_in_bits = "";//will contain all input text in bits

            string text = File.ReadAllText(input_path, Encoding.UTF8);

            char[] freq_key = new char[text.Length];//max possible value
            char[] char_key = new char[text.Length];
            int text_index = 0;
            while (text[text_index] != '$' || text[text_index + 1] != '$')
            {
                char_key[text_index] = text[text_index];
                text_index++;
            }
            int size = text_index;
            text_index += 2;//skip 2 dollar signs
            int idx = 0;
            int real_file_size = 0;
            while (text[text_index] != '$' || text[text_index + 1] != '$' || text[text_index + 2] != '$')//check for 3 dollar signs delimiter
            {
                real_file_size += text[text_index];
                freq_key[idx++] = text[text_index++];
            }
            Node root;
            root = createHuffmanTree(char_key, freq_key, size);

            //here starts the real file content
            text_index += 3;

            int[] _byte = new int[7];

            for (int i = text_index; i < text.Length; i++)
            {
                _byte = get_bits(text[i]);
                for (int j = 6; j >= 0; j--)//remove MSB
                {
                    if (_byte[j] == 1)
                        text_in_bits += '1';
                    else
                        text_in_bits += '0';
                }
            }
            int dum = -1;

            for (int i = 0; i < real_file_size - 1; i++)
            {
                decode(root, ref dum, text_in_bits);
            }
            StreamWriter x = new StreamWriter(output_path,false);
            x.Write(decompressed_output);
            x.Close();

        }
        
    }
}
