using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 翻转单词顺序
    /// 输入一个英文句子，翻转句子中单词的顺序，单词内字符顺序不变。
    /// 标点符号和普通字母一样处理。
    /// 思路：准备一个翻转所有字符的函数。
    /// 先将全部字符翻转一次，
    /// 再以空格为依据，逐个翻转单词。
    /// </summary>
    [TestClass]
    public class E42_1_ReverseWordsInSequence {
        [TestMethod]
        public void Main() {
            Console.WriteLine(ReverseWords("I am a student."));
            Console.WriteLine(ReverseWords("  I am a  student.  "));
        }

        private string ReverseWords(string str) {
            if (string.IsNullOrEmpty(str)) {
                return str;
            }
            char[] charArray = str.ToCharArray();
            ReverseChars(charArray, 0, charArray.Length-1);
            int start = 0;
            int end = 0;
            for (int i = 0; i < charArray.Length; i++) {
                if (charArray[i] == ' ') {
                    end = i - 1;
                    ReverseChars(charArray, start, end);
                    start = i + 1;
                }
            }
            return new string(charArray);
        }

        private void ReverseChars(char[] str, int start, int end) {
            if (str == null || start >= end) {
                return;
            }
            for (int i = 0; i <= (end-start+1)/2-1; i++) {
                str.Swap(i + start, end - i);
            }
        }
    }
}
