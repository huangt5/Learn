using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 数字在排序数组中出现的次数
    /// 统计一个数字在排序数组中出现的次数。
    /// 思路1：利用二分法找到一个数字，然后前后扫描找到长度 O(n)
    /// 思路2：利用二分法找到第一个和最后一个数字，下标相减得到长度 O(logn)
    /// </summary>
    [TestClass]
    public class E38_NumberOfK {
        [TestMethod]
        public void Main() {
            Console.WriteLine(GetNumberOfK(new[] {1, 2, 3, 3, 3, 3, 4, 5}, 3));
        }

        private int GetNumberOfK(int[] arr, int k) {
            if (arr == null || arr.Length == 0) {
                return 0;
            }
            int firstIndex = GetFirstIndex(arr, k, 0, arr.Length - 1);
            int lastIndex = GetLastIndex(arr, k, 0, arr.Length - 1);
            if (firstIndex == -1) {
                return 0;
            }
            return lastIndex - firstIndex + 1;
        }

        private int GetFirstIndex(int[] arr, int k, int start, int end) {
            if (start > end) {
                return -1;
            }
            if (start == end) {
                return start;
            }
            int middle = (start + end)/2;
            if (arr[middle] < k) {
                return GetFirstIndex(arr, k, middle + 1, end);
            } else if (arr[middle] > k) {
                return GetFirstIndex(arr, k, start, middle - 1);
            } else {
                return GetFirstIndex(arr, k, start, middle);
            }
        }

        private int GetLastIndex(int[] arr, int k, int start, int end) {
            if (start > end) {
                return -1;
            }
            if (start == end) {
                return start;
            }
            int middle = (start + end)/2;
            if (arr[middle] < k) {
                return GetLastIndex(arr, k, middle + 1, end);
            } else if (arr[middle] > k) {
                return GetLastIndex(arr, k, start, middle - 1);
            } else {
                return GetLastIndex(arr, k, middle, end);
            }
        }
    }
}