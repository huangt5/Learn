using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 数组中的逆序对
    /// 在数组中的两个数字如果前面一个数字大于后面的数字，则这两个数字组成一个逆序对。
    /// 输入一个数组，求出这个数组的逆序对的总数。
    /// 思路：利用O(n)的空间，是时间变为O(nlogn)。
    /// 类似合并排序算法递归
    /// </summary>
    [TestClass]
    public class E36_InversePairs {
        [TestMethod]
        public void Main() {
            Console.WriteLine(GetSubInversePairsCount(new[] {7, 5, 6, 4}));
        }

        private int GetSubInversePairsCount(int[] arr) {
            if (arr == null || arr.Length < 2) {
                return 0;
            }
            return MergeAndCountInversePairs(arr, 0, arr.Length - 1);
        }

        private int MergeAndCountInversePairs(int[] arr, int start, int end) {
            if (start >= end) {
                return 0;
            }
            int middle = (start + end)/2;
            int leftCount = MergeAndCountInversePairs(arr, start, middle);
            int rightCount = MergeAndCountInversePairs(arr, middle + 1, end);
            int count = MergeSubArray(arr, start, middle, end);
            return count + leftCount + rightCount;
        }

        private int MergeSubArray(int[] arr, int start, int middle, int end) {
            int[] tmp = new int[end - start + 1];
            int index = tmp.Length - 1;
            int i = middle;
            int j = end;
            int count = 0;
            while (i >= start && j >= middle + 1) {
                if (arr[i] <= arr[j]) {
                    tmp[index--] = arr[j--];
                } else {
                    for (int k = j; k >= middle + 1; k--) {
                        Console.WriteLine("[{0},{1}]", arr[i], arr[k]);
                        count++;
                    }
                    tmp[index--] = arr[i--];
                }
            }
            while (i >= start) {
                tmp[index--] = arr[i--];
            }
            while (j >= middle + 1) {
                tmp[index--] = arr[j--];
            }
            for (int k = 0; k < tmp.Length; k++) {
                arr[start + k] = tmp[k];
            }
            return count;
        }
    }
}