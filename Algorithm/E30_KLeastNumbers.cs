using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 最小的K个数
    /// 输入n个整数，找出其中最小的k个数
    /// 思路1：利用快速排序的Partition，Partition返回第一部分end指针
    /// 当返回的index为k-1时，左边k个数为最小的几个
    /// 缺点：需要改变数组内容
    /// 思路2：使用一个容器保存最小的k个数，如果下一个数比容器中最大的数小，进行交换。容器可以使用最大堆或红黑树实现，是的最终时间为O(nlogk)
    /// 可以适用SortedSet
    /// </summary>
    [TestClass]
    public class E30_KLeastNumbers {
        [TestMethod]
        public void Main() {
            int[] arr = new[] {4, 5, 1, 6, 2, 7, 3, 8};
            var results = GetKLeastNumbers(arr, 4);
            results.Print();

            arr = new[] { 4, 5, 1, 6, 2, 7, 3, 8 };
            results = GetKLeastNumbers2(arr, 4);
            results.Print();
        }

        public int[] GetKLeastNumbers2(int[] arr, int k) {
            if (k <= 0) {
                return null;
            }
            if (arr == null || arr.Length <= k) {
                return arr;
            }
            int[] heap = new int[k];
            for (int i = 0; i < k; i++) {
                heap[i] = arr[i];
            }
            // Initialize heap
            for (int i = k/2-1; i >=0; i--) {
                MaxHeapify(heap, i);
            }
            for (int i = k; i < arr.Length; i++) {
                if (arr[i] < heap[0]) {
                    heap[0] = arr[i];
                    MaxHeapify(heap, 0);
                }
            }
            return heap;
        }

        private void MaxHeapify(int[] arr, int current) {
            int left = current*2 + 1;
            int right = current*2 + 2;
            int large = current;
            if (left < arr.Length && arr[left] > arr[large]) {
                large = left;
            }
            if (right < arr.Length && arr[right] > arr[large]) {
                large = right;
            }
            if (large != current) {
                arr.Swap(large, current);
                MaxHeapify(arr, large);
            }
        }

        public int[] GetKLeastNumbers(int[] arr, int k) {
            if (k <= 0) {
                return null;
            }
            if (arr == null || arr.Length <= k)
            {
                return arr;
            }
            int start = 0;
            int end = arr.Length - 1;
            
            while (true) {
                int index = Partition(arr, start, end);
                if (index == k - 1 || start >= end){
                    break;
                }
                if (index < k - 1) {
                    start = index + 1;
                } else if (index > k - 1) {
                    end = index - 1;
                }
            }
            int[] results = new int[k];
            for (int i = 0; i < k; i++) {
                results[i] = arr[i];
            }
            return results;
        }

        private int Partition(int[] arr, int start, int end) {
            int tmp = arr[start];
            int i = start-1;
            int j = end+1;
            while (true) {
                while (arr[++i] < tmp) ;
                while (arr[--j] > tmp) ;
                if (j <= i) {
                    break;
                }
                arr.Swap(i,j);
            }
            return j;
        }
    }
}
