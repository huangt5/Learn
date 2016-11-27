using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 二叉树深度
    /// 输入一个二叉树，求该数深度。从根节点到叶节点依次经过形成一个路径，最长路径为树的深度。
    /// 思路：树只有一个根结点，那么深度为1，
    /// 如果根节点只有左子树而没有右子树，那么树的深度为左子树深度加1，反之亦然。
    /// 如果左右子树都有，那么树的深度为左右子树深度较大值加1。利用递归完成
    /// </summary>
    [TestClass]
    public class E39_1_TreeDepth {
        [TestMethod]
        public void Main() {
            Console.WriteLine(GetTreeDepth(Util.Tree1));
        }

        private int GetTreeDepth(BinaryTreeNode tree) {
            if (tree == null) {
                return 0;
            }
            int leftDepth = GetTreeDepth(tree.Left);
            int rightDepth = GetTreeDepth(tree.Right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
