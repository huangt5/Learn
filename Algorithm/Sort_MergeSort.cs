using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 分解：将当前区间一分为二，即求分裂点
    /// 求解：递归地对两个子区间R[low..mid]和R[mid+1..high]进行归并排序
    /// 组合：将已排序的两个子区间R[low..mid]和R[mid+1..high]归并为一个有序的区间R[low..high]。递归的终结条件：子区间长度为1（一个记录自然有序）
    /// 时间: O(nlog2n) O(nlog2n) O(nlog2n) 
    /// 空间: O(n)
    /// 稳定
    /// </summary>
    [TestClass]
    public class Sort_MergeSort {
        [TestMethod]
        public void Main() {
            Util.Array1.Print();
            MergeSort(Util.Array1);
            Util.Array1.Print();
        }

        private void MergeSort(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return;
            }
            MergeSort(arr, 0, arr.Length - 1);
        }

        private void MergeSort(int[] arr, int start, int end) {
            if (start >= end) {
                return;
            }

            int middle = (start + end)/2;
            MergeSort(arr, start, middle);
            MergeSort(arr, middle + 1, end);
            MergeSortCore(arr, start, middle, end);
        }

        private void MergeSortCore(int[] arr, int start, int middle, int end) {
            int[] temp = new int[end - start + 1];
            int i = start;
            int j = middle + 1;
            int idxTmp = 0;
            while (i <= middle && j <= end) {
                if (arr[i] <= arr[j]) {
                    temp[idxTmp++] = arr[i++];
                } else {
                    temp[idxTmp++] = arr[j++];
                }
            }
            while (i <= middle) {
                temp[idxTmp++] = arr[i++];
            }
            while (j <= end) {
                temp[idxTmp++] = arr[j++];
            }
            for (int k = 0; k < temp.Length; k++) {
                arr[start + k] = temp[k];
            }
        }
    }
}