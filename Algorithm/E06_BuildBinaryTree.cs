using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class E06_BuildBinaryTree {
        /// <summary>
        /// 给出二叉树前序 中序遍历结果，重建该二叉树。
        /// 假设结果中没有重复的数字
        /// 思路：前序遍历第一个数字总是树的根节点
        /// 中序遍历中，找到该数字，左右两边分别是左右子树
        /// 得到左右子树的个数后，在前序结果中分为两个子树递归调用
        /// 
        /// 前序遍历 Preorder Traverse
        /// 中序遍历 Inorder Traverse
        /// 后续遍历 Postorder Traverse
        /// </summary>
        [TestMethod]
        public void Main() {
            int[] preorder = new int[]{1,2,4,7,3,5,6,8};
            int[] inorder = new int[]{4,7,2,1,5,3,8,6};

            BinaryTreeNode root = BuildBinaryTree(preorder, 0, preorder.Length-1, inorder, 0, inorder.Length - 1);
            root.PrintPreorder();
            Console.WriteLine();
            root.PrintInorder();
        }

        private BinaryTreeNode BuildBinaryTree(int[] preorder, int preOrderStart, int preOrderEnd, int[] inorder, int inorderStart, int inorderEnd) {
            BinaryTreeNode node = new BinaryTreeNode();
            node.Value = preorder[preOrderStart];

            int indexInorder = inorderStart;
            while (inorder[indexInorder] != node.Value) {
                indexInorder++;
            }
            int leftLen = indexInorder - inorderStart;
            int rightLen = inorderEnd - indexInorder;
            if (leftLen > 0) {
                node.Left = BuildBinaryTree(preorder, preOrderStart + 1, preOrderStart + leftLen, inorder, inorderStart, indexInorder - 1);
            }
            if (rightLen > 0) {
                node.Right = BuildBinaryTree(preorder, preOrderEnd - rightLen + 1, preOrderEnd, inorder, indexInorder + 1, inorderEnd);
            }

            return node;
        }
    }
}
