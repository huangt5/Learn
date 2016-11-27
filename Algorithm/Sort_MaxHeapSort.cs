using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 堆排序的主要用途,是在形成和处理优先级队列方面
    /// 步骤:
    ///   初始化 从非叶子结点自下而上构建Heap
    ///   交换出根节点后，自上而下再次构建Heap(Size递减)
    /// 时间: O(nlog2n) O(nlog2n) O(nlog2n) 
    /// 空间: O(1)
    /// 不稳定
    /// </summary>
    [TestClass]
    public class Sort_MaxHeapSort {
        [TestMethod]
        public void Main() {
            Util.Array1.Print();
            MaxHeapSort(Util.Array1);
            Util.Array1.Print();
        }

        private void MaxHeapSort(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return;
            }

            // Initiate heap
            for (int i = arr.Length/2-1; i >= 0; i--) {
                MaxHeapify(arr, arr.Length, i);
            }

            // From top to down exchange
            for (int i = arr.Length - 1; i >0; i--) {
                arr.Swap(0, i);
                MaxHeapify(arr, i, 0);
            }
        }

        private void MaxHeapify(int[] arr, int heapSize, int current) {
            int left = current*2 + 1;
            int right = current*2 + 2;
            int large = current;
            if (left < heapSize && arr[left] > arr[large]) {
                large = left;
            }
            if (right < heapSize && arr[right] > arr[large]) {
                large = right;
            }

            if (large != current) {
                arr.Swap(large, current);
                MaxHeapify(arr, heapSize, large);
            }
        }
    }
}
