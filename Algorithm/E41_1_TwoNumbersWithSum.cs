using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 和为s的两个数字
    /// 输入一个递增排序的数组和一个数字s，在数组中查找两个数字，
    /// 使他们的和正好是s。如果有多对数字的和等于s，输出任意一对。
    /// 思路：头尾设置2个指针
    /// 如果和大于s，尾部指针向前推一个
    /// 如果和小于s，头部指针先后推一个
    /// 时间为O(n)
    /// </summary>
    [TestClass]
    public class E41_1_TwoNumbersWithSum {
        [TestMethod]
        public void Main() {
            FindTwoNumbersWithSum(Util.Array2, 15);
        }

        private void FindTwoNumbersWithSum(int[] arr, int s) {
            if (arr == null || arr.Length == 0) {
                return;
            }
            int i = 0;
            int j = arr.Length - 1;
            while (i < j) {
                if (arr[i] + arr[j] == s) {
                    Console.Write(arr[i] + " " + arr[j]);
                    return;
                }
                if (arr[i] + arr[j] < s) {
                    i++;
                } else {
                    j--;
                }
            }
        }
    }
}
