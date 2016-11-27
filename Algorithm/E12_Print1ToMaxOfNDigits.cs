using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm {
    /// <summary>
    /// 输入数字n，按顺序打印从1到最大n位十进制数
    /// 思路：考虑大数，用字符串数组
    /// </summary>
    [TestClass]
    public class E12_Print1ToMaxOfNDigits {
        [TestMethod]
        public void Main() {
            PrintAll(3);
        }

        private void PrintAll(int n) {
            if (n <= 0) {
                return;
            }

            char[] value = new char[n];
            for (int i = 0; i < value.Length; i++) {
                value[i] = '0';
            }

            while (!Increase(value)) {
                Print(value);
            }
        }

        private void Print(char[] value) {
            if (value == null) {
                return;
            }
            bool startPrint = false;
            for (int i = 0; i < value.Length; i++) {
                if (!startPrint && value[i] != '0') {
                    startPrint = true;
                }
                if (startPrint) {
                    Console.Write(value[i]);
                }
            }
            Console.WriteLine();
        }

        private bool Increase(char[] number) {
            int carry = 1;
            for (int i = number.Length - 1; i >= 0; i--) {
                int value = (number[i] - '0') + carry;
                if (value > 9) {
                    value -= 10;
                    carry = 1;
                } else {
                    carry = 0;
                }
                number[i] = (char)('0' + value);
                if (carry == 0) {
                    break;
                }
            }
            return carry > 0;
        }
    }
}