using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XML_TO_JSON
{
    class ConvertingToJason
    {
        public static StreamWriter writer1;
        public static void SetLocation(string location)
        {
            writer1 = new StreamWriter(location);
            writer1.AutoFlush = true;
        }
        public static Boolean ChildrenAreSame(TreeNode node, int level)
        {
            List<TreeNode> check = node.getChildren();
            if(check.Count()>1 && check[0].getTagName() == check[1].getTagName())
                return true;
            else
                return false;
        }
        public static int noOfChildren(TreeNode node, int level)
        {
            List<TreeNode> number = node.getChildren();
            return number.Count;
        }

        public static string taps(int level)
        {
            string result = "";
            for (int i = 0; i < level; i++) result += "    ";
            return result;
        }

        
        public static string printJasonToFile(TreeNode node, int level)
        {
            string result ="";
            TreeNode p = node.getParent();
            if(!string.IsNullOrEmpty(node.getTagValue()))
            {
                char[] trimmed = {'\n',' ',(char)13};
                if(!ChildrenAreSame(p,level))
                {
                    //Case 1
                    result += taps(level) + "\"" + node.getTagName() + "\": ";
                    Boolean f= double.TryParse(node.getTagValue(),out double n);
                    string data = f?((double)n).ToString():'"'+node.getTagValue().Trim(trimmed)+'"';
                    result += data;
                }
                else
                {
                    //Case 2
                    string value;
                    result += taps(level) + "\"" + node.getTagName() + "\": [\n";
                    for (int i = 0; i < p.getChildren().Count(); i++)
                    {
                        value = p.getChildren()[i].getTagValue().Trim(trimmed);
                        string comma = i<p.getChildren().Count()-1?",":"";
                        Boolean f= double.TryParse(value,out double n);
                        string data = f?((double)n).ToString():string.Format("\"{0}\"",value);
                        data +=comma;
                        result += taps(level+1) + data + "\n";
                    }
                    result += taps(level) + "]";
                }
            }
            else
            {
                if(!ChildrenAreSame(p,level))
                {
                    //Case 3
                    string comma;
                    result += taps(level) + "\"" + node.getTagName() + "\": {\n";
                    List<TreeNode> children = node.getChildren();
                    if(ChildrenAreSame(node,level))
                    {
                        result += printJasonToFile(children[0],level+1) + "\n";
                    }
                    else
                    {
                        for (int i = 0; i < children.Count(); i++)
                        {
                             result += printJasonToFile(children[i],level+1);
                             comma = i<children.Count()-1?",\n":"\n";
                             result += comma;
                        }
                    }
                    result += taps(level) + "}";
                }
                else
                {
                    string comma;
                    //Case 4
                    result += taps(level) + " \"" + node.getTagName() + "\": [\n";
                    for (int i = 0; i < p.getChildren().Count(); i++)
                    {
                        List<TreeNode> children = p.getChildren()[i].getChildren();
                        result += taps(level+1) + "{\n";
                        for (int j = 0; j < children.Count(); j++)
                        {
                            result += printJasonToFile(children[j],level+2);
                            comma = j<children.Count()-1?",\n":"\n";
                            result += comma;
                        }
                        comma = taps(level+1);
                        comma += i<p.getChildren().Count()-1?"},\n":"}\n";
                        result += comma;
                    }
                    result += taps(level) + "]";
                }
            }
            return result;
        }
    }
}