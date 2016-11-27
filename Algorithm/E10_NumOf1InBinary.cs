using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 找出整数的二进制表示的1的个数
    /// 思路：
    /// 1)错误：逐个右移判断1的个数，会在输入负数时死循环
    /// 2)用常量1，逐个左移，和输入值做&
    /// 3)输入值减一，再与输入值做&，使得最右边的1变成0，反复操作直至变成0
    /// </summary>
    [TestClass]
    public class E10_NumOf1InBinary {
        [TestMethod]
        public void Main() {
            Console.WriteLine(CountOne_1(9));
            Console.WriteLine(CountOne_1(-1));
            Console.WriteLine(CountOne_1(-2));
            Console.WriteLine(CountOne_1(0));
            Console.WriteLine(CountOne_2(9));
            Console.WriteLine(CountOne_2(-1));
            Console.WriteLine(CountOne_2(-2));
            Console.WriteLine(CountOne_2(0));
        }

        private int CountOne_1(int value) {
            int tag = 1;
            int count = 0;
            while (tag != 0) {
                if ((value & tag) != 0) {
                    count++;
                }
                tag = tag << 1;
            }
            return count;
        }

        private int CountOne_2(int value) {
            int count = 0;
            while (value != 0) {
                value = (value - 1) & value;
                count++;
            }
            return count;
        }
    }
}
