using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入一个字符串，打印字符的所有排列
    /// 思路：把字符串看成2部分，第一部分是第一个字符，第二部分是后面所有字符。
    /// 首先求所有可能出现在第一个位置的字符，即把第一个字符和后面所有字符交换。
    /// 固定好第一个字符后，求后面所有字符的排列。递归过程
    /// </summary>
    [TestClass]
    public class E28_StringPermutation {
        [TestMethod]
        public void Main() {
            char[] input = new[] {'a', 'b', 'c'};
            StringPermutation(input);
            Console.WriteLine();
            char[] input2 = new[] { 'a', 'b', 'c', 'd' };
            StringPermutation(input2);
            Console.WriteLine();
        }

        private void StringPermutation(char[] input) {
            if (input == null || input.Length == 0) {
                return;
            }
            StringPermutation(input, 0);
        }

        private void StringPermutation(char[] input, int start) {
            if (start == input.Length - 1) {
                Console.WriteLine(input);
            } else {
                for (int i = start; i < input.Length; i++)
                {
                    input.Swap(start, i);
                    StringPermutation(input, start + 1);
                    input.Swap(start, i);
                }
            }
        }
    }
}