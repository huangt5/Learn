using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 冒泡排序
    /// 时间O(n2)
    /// 空间O(1)
    /// 稳定
    /// </summary>
    [TestClass]
    public class Sort_Bubble {
        [TestMethod]
        public void Main() {
            Util.Array1.Print();
            BubbleSort(Util.Array1);
            Util.Array1.Print();
        }

        private void BubbleSort(int[] arr) {
            if (arr == null || arr.Length == 0) {
                return;
            }
            for (int i = 0; i < arr.Length; i++) {
                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[j] < arr[i]) {
                        arr.Swap(i, j);
                    }
                }
            }
        }
    }
}