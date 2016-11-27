using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 旋转字符串
    /// 把字符串的前面若干个字符转移到尾部，称为左旋转操作。
    /// 定义一个函数，实现字符串左旋转功能
    /// 思路：和字符翻转类似
    /// 先将整个字符串翻转，再根据需要左旋转的字符个数分为两个数组
    /// 分别把两个数组做字符串翻转
    /// </summary>
    [TestClass]
    public class E42_2_LeftRotateString {
        [TestMethod]
        public void Main() {
            Console.WriteLine(LeftRotateString("abcdefg", 3));
            Console.WriteLine(LeftRotateString("abcdefg", 7));
        }

        private string LeftRotateString(string str, int s) {
            if (s < 0) {
                throw new Exception("Invalid augument.");
            }
            if (s == 0 || string.IsNullOrEmpty(str)) {
                return str;
            }
            char[] charArr = str.ToCharArray();
            ReverseChars(charArr, 0, charArr.Length - 1);
            ReverseChars(charArr, 0, charArr.Length - s - 1);
            ReverseChars(charArr, charArr.Length - s, charArr.Length - 1);
            return new string(charArr);
        }

        private void ReverseChars(char[] str, int start, int end) {
            if (str == null || start >= end) {
                return;
            }
            for (int i = 0; i <= (end - start + 1)/2 - 1; i++) {
                str.Swap(i + start, end - i);
            }
        }
    }
}