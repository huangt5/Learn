using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 二叉搜索树的后序遍历序列
    /// 输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历的结果。
    /// 假设输入数组的任意两个数字都不相同
    /// 思路：后序遍历意味着，最后一个值为根节点
    /// 利用搜索树，可以用根节点把数组分为左右两部分
    /// 递归调用判断左右两部分是否都满足条件
    /// </summary>
    [TestClass]
    public class E24_SquenceOfBST {
        [TestMethod]
        public void Main() {
            Console.WriteLine(CheckSequenceOfBST(new []{5,6,7,9,11,10,8}));
            Console.WriteLine(CheckSequenceOfBST(new []{7,4,6,5}));
        }

        private bool CheckSequenceOfBST(int[] arr) {
            if (arr == null) {
                return true;
            }
            return CheckSequenceOfBST(arr, 0, arr.Length - 1);
        }

        private bool CheckSequenceOfBST(int[] arr, int start, int end) {
            if (start >= end) {
                return true;
            }
            int middle;
            for (middle = start; middle <= end-1; middle++) {
                if (arr[middle] > arr[end]) {
                    break;
                }
            }
            for (int i = middle + 1; i <= end-1; i++) {
                if (arr[i] <= arr[end]) {
                    return false;
                }
            }
            return CheckSequenceOfBST(arr, start, middle - 1) && CheckSequenceOfBST(arr, middle, end - 1);
        }
    }
}
