using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 把一个数组的所有奇数放到前半部分，偶数放到后半部分
    /// 思路：类似快速排序，前后两个指针，交换数字
    /// 扩展：传入delegete，排列不同情
    /// </summary>
    [TestClass]
    public class E14_ReorderArray {
        [TestMethod]
        public void Main() {
            Util.Array1.Print();
            ReorderArray(Util.Array1);
            Util.Array1.Print();
        }

        private void ReorderArray(int[] array) {
            if (array == null || array.Length == 0) {
                return;
            }
            int i = 0;
            int j = array.Length - 1;
            while (true) {
                while (array[i]%2 == 1 && i < j) i++;
                while (array[j]%2 == 0 && j > i) j--;

                if (i >= j) {
                    break;
                }

                array.Swap(i,j);
            }
        }
    }
}
