using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Formatting
{
    class Tree
    {
        private TreeNode root = null;
        private TreeNode current_parent = null;
        public Tree(TreeNode root = null)
        {
            this.root = root;
        }
        public TreeNode getRoot()
        {
            return root;
        }

        // Function to insert a node into the tree
        public void insert(string TagName, string TagValue)
        {
            // First time entering the tree to add a node
            if (root == null)
            {
                // Add this node and set it as the Root and the Current Parent
                root = new TreeNode(TagName, TagValue);
                current_parent = root;
            }
            // Normal case for adding a node
            else
            {
                // Add the node under the Current Parent and set the Current Parent to this new node
                TreeNode temp = current_parent.addChild(TagName, TagValue);
                temp.setParent(current_parent);
                current_parent = temp;
            }
        }

        // Function to move up the heriarchy in a tree in case tag is closed
        public void move_parent_up()
        {
            current_parent = current_parent.getParent();
        }
    }
}
