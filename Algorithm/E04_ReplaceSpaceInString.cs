using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 把字符串中的空格替换成%20
    /// 思路：先计算空格数量，计算出新字符串长度，从后往前检索
    /// </summary>
    [TestClass]
    public class E04_ReplaceSpaceInString {
        [TestMethod]
        public void Main() {
            string str = "we are happy.";
            char[] input = str.ToCharArray();
            input.Print();
            char[] output = ReplaceSpace(input);
            output.Print();
        }

        private char[] ReplaceSpace(char[] input) {
            int spaceCount = input.Count(c => c == ' ');
            char[] output = new char[spaceCount*2+input.Length];

            int j = output.Length - 1;
            for (int i = input.Length - 1; i >=0; i--) {
                if (input[i] == ' ') {
                    output[j--] = '0';
                    output[j--] = '2';
                    output[j--] = '%';
                } else {
                    output[j--] = input[i];
                }
            }
            return output;
        }
    }
}
