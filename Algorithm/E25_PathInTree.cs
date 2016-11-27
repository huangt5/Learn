using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 二叉树中和为某一值的路径
    /// 输入二叉树和整数，打印出二叉树中节点值的和为该整数的所有路径。
    /// 定义：根节点往下到叶节点经过的节点形成一条路径
    /// 思路：前序遍历二叉树，递归调用时传入和值和一个stack，stack用于保存路径
    /// </summary>
    [TestClass]
    public class E25_PathInTree {
        [TestMethod]
        public void Main() {
            PrintPath(Util.Tree1, 25);
        }

        private void PrintPath(BinaryTreeNode tree, int targetSum) {
            if (tree == null) {
                return;
            }
            PrintPathCore(tree, 0, targetSum, new Stack<int>());
        }

        private void PrintPathCore(BinaryTreeNode node, int sum, int targetSum, Stack<int> stack) {
            stack.Push(node.Value);
            sum += node.Value;
            if (node.Left == null && node.Right == null) {
                if (sum == targetSum) {
                    PrintPath(stack);
                }
            }

            if (node.Left != null) {
                PrintPathCore(node.Left, sum, targetSum, stack);
            }
            if (node.Right != null) {
                PrintPathCore(node.Right, sum, targetSum, stack);
            }

            stack.Pop();
        }

        private void PrintPath(IEnumerable<int> stack) {
            foreach (var i in stack) {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
