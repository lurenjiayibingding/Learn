using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramworkAssembly
{
    public class MyClass1
    {
    }

    public class TreeNode<T>
    {
        public T Date { get; set; }

        public TreeNode<T> LeftNode { get; set; }

        public TreeNode<T> RightNode { get; set; }

        public TreeNode(T date, TreeNode<T> left, TreeNode<T> right)
        {
            Date = date;
            LeftNode = left;
            RightNode = right;
        }
    }

    public class MyTreee<T>
    {
        public TreeNode<T> Head { get; set; }

        public void Add(TreeNode<T> node)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Head.LeftNode = node;
            }
        }
    }
}
