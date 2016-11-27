using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class Sort_QuickSortByPartition {
        [TestMethod]
        public void Main() {
            int[] arr = Util.Array1;
            arr.Print();
            QuickSort(arr);
            arr.Print();

            arr = new[] {3, 3, 3, 3, 3, 3, 3};
            QuickSort(arr);
            arr.Print();
        }

        private void QuickSort(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return;
            }
            QuickSort(arr, 0, arr.Length - 1);
        }

        private void QuickSort(int[] arr, int start, int end) {
            if (start >= end) {
                return;
            }
            int index = Partition(arr, start, end);
            if (index > start) {
                QuickSort(arr, start, index - 1);
            }
            if (index < end) {
                QuickSort(arr, index + 1, end);
            }
        }

        /// <summary>
        /// 返回中间值的下标
        /// Partition后，中间值一定在中间
        /// </summary>
        private int Partition(int[] arr, int start, int end) {
            int index = (start + end)/2;
            arr.Swap(index, end);

            int small = start - 1;
            for (index = start; index < end; ++index) {
                if (arr[index] < arr[end]) {
                    small++;
                    if (small != index) {
                        arr.Swap(index, small);
                    }
                }
            }
            small++;
            arr.Swap(small, end);
            return small;
        }
    }
}