using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Formatting
{
    class TreeNode
    {
        private string TagName;
        private string TagValue;
        private List<TreeNode> children = new List<TreeNode>();
        private TreeNode parent;
        public TreeNode(string TagName, string TagValue)
        {
            this.TagName = TagName;
            this.TagValue = TagValue;
        }
        public string getTagName() { return TagName; }
        public string getTagValue() { return TagValue; }
        public TreeNode getParent() { return parent; }
        public List<TreeNode> getChildren() { return children; }
        public void setParent(TreeNode parent) { this.parent = parent; }
        // Function to add a child to this node
        public TreeNode addChild(string TagName, string TagValue)
        {
            TreeNode temp = new TreeNode(TagName, TagValue);
            children.Add(temp);
            return temp;
        }
        public TreeNode addChild(TreeNode node)
        {
            children.Add(node);
            return node;
        }
    }
}
