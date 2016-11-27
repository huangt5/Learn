using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 数组中只出现一次的数字
    /// 一个整型数组里除了两个数字外，其他的数字都出现了两次。找出这两个数字。
    /// 要求时间为O(n)，空间为O(1)
    /// 
    /// 思路：逐个异或数组中的数组，可以使得相同的两个数字抵消，和0做异或等于原来的值。
    /// 1)先把左右数字异或，得出一个非0的二进制值，找到1在其中的位置
    /// 2)把所有数字以该位为1或0分为2组
    /// 3)把两个分组的数组全部异或，可以直接得到只出现一次的值
    /// </summary>
    [TestClass]
    public class E40_NumbersAppearOnce {
        [TestMethod]
        public void Main() {
            FindNumberAppearOnce(new[] {2, 4, 3, 6, 3, 2, 5, 5});
            FindNumberAppearOnce(new[] {2, 4, 3, 8, 3, 2, 5, 5});
        }

        private void FindNumberAppearOnce(int[] arr) {
            if (arr == null || arr.Length < 2) {
                return;
            }
            if (arr.Length%2 != 0) {
                throw new Exception("invalid input");
            }

            int tmp = 0;
            foreach (var value in arr) {
                tmp ^= value;
            }
            int mark = 1;
            while ((mark & tmp) == 0) {
                mark = mark << 1;
            }

            int a = 0;
            int b = 0;

            foreach (var value in arr) {
                if ((value & mark) == 0) {
                    a ^= value;
                } else {
                    b ^= value;
                }
            }

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}