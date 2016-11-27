using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 第一个只出现一次的字符
    /// 在字符串中找出第一个只出现一次的字符。
    /// 思路：创建256个整形数组，用字符值作为下标，扫描字符串得出字符的个数。
    /// </summary>
    [TestClass]
    public class E35_FirstNotRepeatingChar {
        [TestMethod]
        public void Main() {
            // b
            PrintFirstNotRepeatingChar("abaccdeff");
        }

        private void PrintFirstNotRepeatingChar(string str) {
            if (string.IsNullOrEmpty(str)) {
                return;
            }
            int[] counts = new int[256];
            foreach (var c in str.ToCharArray()) {
                counts[c]++;
            }
            for (int i = 0; i < counts.Length; i++) {
                if (counts[i] == 1) {
                    Console.WriteLine((char)i);
                    return;
                }
            }
        }
    }
}
