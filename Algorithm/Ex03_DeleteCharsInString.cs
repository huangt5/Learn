using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    [TestClass]
    public class Ex03_DeleteCharsInString {
        /// <summary>
        /// 在字符串中删除特定的字符
        /// 输入两个字符串，从第一字符串中删除第二个字符串中所有的字符。例如，输入”They are students.”和”aeiou”，则删除之后的第一个字符串变成”Thy r stdnts.”
        /// 思路：用256个bool数组用于第二个字符串的hash
        /// 在第一个字符串中逐个扫描，把后续的字符填补被删除的字符
        /// </summary>
        [TestMethod]
        public void Main() {
            string str1 = "They are students.";
            string str2 = "aeiou";
            DeleteCharsInString(str1.ToCharArray(), str2.ToCharArray());
        }

        public void DeleteCharsInString(char[] input, char[] delete) {
            if (delete == null || input == null) {
                return;
            }
            bool[] marks = new bool[256];
            foreach (char c in delete) {
                marks[c] = true;
            }
            int p1 = -1;
            int p2 = 0;
            while (p2 < input.Length) {
                if (marks[input[p2]] == false) {
                    p1++;
                    input[p1] = input[p2];
                }
                p2++;
            }

            for (int i = 0; i <= p1; i++) {
                Console.Write(input[i]);
            }
        }
    }
}
