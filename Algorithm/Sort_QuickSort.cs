using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 快速排序法
    /// 核心：分治法（Divide and conquer）
    /// 首先取一个数据（通常选用中间数据）作为关键数据，然后将所有比它小的数都放到它前面，所有比它大的数都放到它后面，这个过程称为一趟快速排序。
    /// 初始状态 {49 38 65 97 76 13 27}
    /// 进行一次快速排序之后划分为 {27 38 13} 49 {76 97 65} 成为两个pivot
    /// 递归完成剩余2个pivot的快速排序
    /// 
    /// 平均 O(nlogn) O(nlogn) O(n2)
    /// 空间 O(logn)
    /// 不稳定
    /// 较复杂
    /// </summary>
    [TestClass]
    public class Sort_QuickSort {
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

            int middleValue = arr[(start + end)/2];
            int i = start - 1;
            int j = end + 1;
            while (true) {
                while (arr[++i] < middleValue) ;
                while (arr[--j] > middleValue) ;
                if (i >= j) {
                    break;
                }
                arr.Swap(i, j);
            }

            QuickSort(arr, start, i - 1);
            QuickSort(arr, j + 1, end);
        }
    }
}