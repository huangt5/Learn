using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 二叉搜索树与双向链表输入二叉搜索树，转换成一个排序的双向链表。要求不能创建任何新的节点，只能操作指针。
    /// 思路：利用中序遍历，调整当前节点的指针：
    ///     把当前节点和左子树处理后的最后节点对接
    ///     把当前节点和右子树处理后的头结点对接
    /// 注意，返回的头指针可能为空
    /// </summary>
    [TestClass]
    public class E27_ConvertBinarySearchTree {
        [TestMethod]
        public void Main() {
            Util.Tree2.PrintInorder();
            Console.WriteLine();
            var head = ConvertToList(Util.Tree2);
            head.PrintByRight();
        }

        private BinaryTreeNode ConvertToList(BinaryTreeNode tree) {
            if (tree == null) {
                return null;
            }
            var leftHead = ConvertToList(tree.Left);
            var leftLast = leftHead;
            while (leftLast != null && leftLast.Right != null) {
                leftLast = leftLast.Right;
            }

            tree.Left = leftLast;
            if (leftLast != null) {
                leftLast.Right = tree;
            }
            var rightHead = ConvertToList(tree.Right);
            tree.Right = rightHead;
            if (rightHead != null) {
                rightHead.Left = tree;
            }

            return leftHead??tree;
        }

    }
}
