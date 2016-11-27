using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 从上往下打印二叉树
    /// 从上往下，同一层结点按从左到右顺序打印二叉树
    /// 思路：利用队列，打印一个节点时，把子节点放入队列，从队列取节点递归调用，直至队列为空
    /// 推荐使用循环
    /// </summary>
    [TestClass]
    public class E23_PrintBinaryTreeByLevel {
        [TestMethod]
        public void Main() {
            PrintTreeByLevelRecursive(Util.Tree1);
            Console.WriteLine();
            PrintTreeByLevelLoop(Util.Tree1);
        }

        private void PrintTreeByLevelLoop(BinaryTreeNode tree) {
            if (tree == null) {
                return;
            }
            Queue<BinaryTreeNode> nodesQueue = new Queue<BinaryTreeNode>();
            nodesQueue.Enqueue(tree);
            while (nodesQueue.Count > 0) {
                var node = nodesQueue.Dequeue();
                Console.Write(node.Value + " ");
                if (node.Left != null) {
                    nodesQueue.Enqueue(node.Left);
                }
                if (node.Right != null) {
                    nodesQueue.Enqueue(node.Right);
                }
            }
        }

        private void PrintTreeByLevelRecursive(BinaryTreeNode tree) {
            if (tree == null) {
                return;
            }
            Queue<BinaryTreeNode> nodesQueue = new Queue<BinaryTreeNode>();
            nodesQueue.Enqueue(tree);
            PrintTreeByLevelCore(nodesQueue);
        }

        private void PrintTreeByLevelCore(Queue<BinaryTreeNode> nodesQueue) {
            if (nodesQueue.Count == 0) {
                return;
            }
            BinaryTreeNode node = nodesQueue.Dequeue();
            Console.Write(node.Value + " ");
            if (node.Left != null) {
                nodesQueue.Enqueue(node.Left);
            }
            if (node.Right != null) {
                nodesQueue.Enqueue(node.Right);
            }

            PrintTreeByLevelCore(nodesQueue);
        }
    }
}
