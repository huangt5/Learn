using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class E28_2_StringCombination {
        /// <summary>
        /// 输入一个字符串，求其中字符的所有组合
        /// 思路：假设我们想在长度为n的字符串中求m个字符的组合。
        /// 我们先从头扫描字符串的第一个字符。
        /// 针对第一个字符，我们有两种选择：
        /// 一是把这个字符放到组合中去，接下来我们需要在剩下的n-1个字符中选取m-1个字符；
        /// 二是不把这个字符放到组合中去，接下来我们需要在剩下的n-1个字符中选择m个字符。
        /// 这两种选择都很容易用递归实现。
        /// </summary>
        [TestMethod]
        public void Main() {
            StringCombine("abc");
        }

        public void StringCombine(string str) {
            if (string.IsNullOrEmpty(str)) {
                return;
            }
            Stack<char> result = new Stack<char>();
            for (int i = 1; i <= str.Length; i++) {
                StringCombineCore(str.ToCharArray(), 0, i, result);
            }
        }

        private void StringCombineCore(char[] str, int start, int number, Stack<char> result) {
            if (number == 0) {
                foreach (var c in result) {
                    Console.Write(c);
                }
                Console.WriteLine();
                return;
            }

            if (start >= str.Length) {
                return;
            }

            result.Push(str[start]);
            StringCombineCore(str, start + 1, number - 1, result);
            result.Pop();

            StringCombineCore(str, start + 1, number, result);
        }
    }
}
