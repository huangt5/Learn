using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入一个二叉树，判断该树是不是平衡二叉树。
    /// 如果某二叉树任意结点的左右子树深度相差不超过1，那么就是平衡二叉树
    /// 思路：利用后序遍历，只遍历一遍，可以先得到左右子树深度
    /// </summary>
    [TestClass]
    public class E39_2_BalancedBinaryTree {
        [TestMethod]
        public void Main() {
            Console.WriteLine(IsBalancedBinaryTree(Util.Tree1));
            Console.WriteLine(IsBalancedBinaryTree(Util.Tree2));
        }

        private bool IsBalancedBinaryTree(BinaryTreeNode tree) {
            int depth = 0;
            return IsBalancedBinaryTree(tree, ref depth);
        }

        private bool IsBalancedBinaryTree(BinaryTreeNode tree, ref int depth) {
            if (tree == null) {
                depth = 0;
                return true;
            }

            int leftDepth = 0;
            int rightDepth = 0;
            if (IsBalancedBinaryTree(tree.Left, ref leftDepth) 
                && IsBalancedBinaryTree(tree.Right, ref rightDepth)) {
                if (Math.Abs(leftDepth - rightDepth) <= 1) {
                    depth = Math.Max(leftDepth, rightDepth) + 1;
                    return true;
                }
            }
            return false;
        }

    }
}
