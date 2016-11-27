using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 把数组排成最小的数
    /// 输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印出能凭借出来的所有数中最小的一个
    /// 思路：把数字转成字符串，然后实现一个特殊comparer对两个数字的拼接进行比较，对数组进行排序
    /// 注意，会有大数问题
    /// </summary>
    [TestClass]
    public class E33_SortArrayForMinNumber {
        [TestMethod]
        public void Main() {
            // Expect: 321323
            PrintMinNumber(new []{3, 32, 321});
        }

        private void PrintMinNumber(int[] arr) {
            var list = arr.ToList();
            list.Sort(new NumberComparer());
            foreach (var i in list) {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        private class NumberComparer : IComparer<int> {
            public int Compare(int x, int y) {
                string strX = x.ToString();
                string strY = y.ToString();
                int xy = int.Parse(strX + strY);
                int yx = int.Parse(strY + strX);
                if (xy == yx) {
                    return 0;
                }
                if (xy < yx) {
                    return -1;
                }
                return 1;
            }
        }
    }
}
