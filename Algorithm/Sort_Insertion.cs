using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 插入排序
    /// 时间O(n2)
    /// 空间O(1)
    /// 稳定
    /// </summary>
    [TestClass]
    public class Sort_Insertion {
        [TestMethod]
        public void Main() {
            Util.Array1.Print();
            InsertionSort(Util.Array1);
            Util.Array1.Print();
        }

        private void InsertionSort(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return;
            }
            for (int i = 0; i < arr.Length; i++) {
                int tmp = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > tmp) {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = tmp;
            }
        }
    }
}
