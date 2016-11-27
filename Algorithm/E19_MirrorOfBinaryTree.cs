using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入二叉树，输出它的镜像
    /// 思路：递归遍历每个节点，交换节点的左右子节点
    /// </summary>
    [TestClass]
    public class E19_MirrorOfBinaryTree {
        [TestMethod]
        public void Main() {
            Util.Tree1.PrintInorder();
            Console.WriteLine();
            GetTreeMirror(Util.Tree1).PrintInorder();
        }

        private BinaryTreeNode GetTreeMirror(BinaryTreeNode tree) {
            if (tree == null) {
                return null;
            }
            var leftTree = tree.Left;
            var rightTree = tree.Right;
            tree.Left = GetTreeMirror(rightTree);
            tree.Right = GetTreeMirror(leftTree);
            return tree;
        }
    }
}
