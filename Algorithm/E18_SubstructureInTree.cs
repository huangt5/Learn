using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入两棵二叉树A和B，判断B是不是A的子结构
    /// 思路：
    /// 1：递归遍历A的所有节点，每个节点调用方法2
    /// 2：递归遍历B的所有节点，判断是否每个节点相同
    /// 注意方法2的退出条件
    /// </summary>
    [TestClass]
    public class E18_SubstructureInTree {
        [TestMethod]
        public void Main() {
            BinaryTreeNode tree2 = new BinaryTreeNode(8) {
                Left = new BinaryTreeNode(9),
                Right = new BinaryTreeNode(2)
            };

            Console.WriteLine(HasTreeInside(Util.Tree1, tree2));
        }

        private bool HasTreeInside(BinaryTreeNode tree, BinaryTreeNode targetTree) {
            if (targetTree == null) {
                return true;
            }
            if (tree == null) {
                return false;
            }
            if (IsSameStructure(tree, targetTree)) {
                return true;
            }
            return HasTreeInside(tree.Left, targetTree) || HasTreeInside(tree.Right, targetTree);
        }

        private bool IsSameStructure(BinaryTreeNode tree1, BinaryTreeNode tree2) {
            if (tree2 == null) {
                return true;
            }
            if (tree1 == null) {
                return false;
            }
            if (tree1.Value != tree2.Value) {
                return false;
            }
            return IsSameStructure(tree1.Left, tree2.Left) && IsSameStructure(tree1.Right, tree2.Right);
        }
    }
}
