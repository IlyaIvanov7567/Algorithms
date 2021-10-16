using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode leftChild { get; set; }
        public TreeNode rightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }
}
